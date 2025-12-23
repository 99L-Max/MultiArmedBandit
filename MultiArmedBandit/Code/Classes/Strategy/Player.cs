using MultiArmedBandit.Structs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MultiArmedBandit
{
    class Player
    {
        public const double DefaultDeviationsStep = 0.3d;
        public const double MinDeviation = -100d;
        public const double MaxDeviation = 100d;

        private const int MinProgressPercent = 0;
        private const int ProgressMaxPercent = 100;

        [JsonProperty("Bandits")] 
        private Bandit[] _bandits;
        [JsonProperty("GeneralBanditsData")]
        private GeneralBanditsData _generalBanditsData;

        private readonly Stopwatch _stopWatch = new Stopwatch();
        private readonly Dictionary<Bandit, Thread> _runningBanditsThreads = new Dictionary<Bandit, Thread>();

        private int _processedBanditsCount;
        private int _processedDeviationsCount;
        private int _pointsTotalCount;
        private int _percentProgress;
        private Dictionary<Bandit, Thread> _waitingBanditsThreads;

        public Player(GeneralBanditsData generalBanditsData, Bandit[] bandits)
        {
            _bandits = bandits;
            _generalBanditsData = generalBanditsData;
        }

        public event Action<int> ProgressChanged;
        public event Action<bool, string> GameOver;

        [JsonIgnore] public bool IsPaused { get; private set; } = false;
        [JsonIgnore] public bool IsPlaying { get; private set; } = false;
        [JsonIgnore] public int BanditsCount => _bandits.Length;
        [JsonIgnore] public GeneralBanditsData GeneralBanditsData => _generalBanditsData;
        [JsonIgnore] public IEnumerable<Regret[]> Regrets => _bandits?.Select(bandit => bandit.Regrets.ToArray());
        [JsonIgnore] public string GameTime => $"{_stopWatch.Elapsed.Hours:d2}:{_stopWatch.Elapsed.Minutes:d2}:{_stopWatch.Elapsed.Seconds:d2}";

        [JsonIgnore]
        public string GameInformation =>
            $"Обработано {_processedBanditsCount} / {_bandits.Length}\n" +
            $"Выполнено {_percentProgress}%\n" +
            $"Время {GameTime}";

        public void Play(IEnumerable<double> deviations, int gamesCount, int threadsMaxCount)
        {
            if (IsPlaying == false)
            {
                IsPlaying = true;
                IsPaused = false;

                _runningBanditsThreads.Clear();
                _waitingBanditsThreads = _bandits.ToDictionary(bandit => bandit, bandit => new Thread(() => bandit.Play(deviations, gamesCount)));
                _processedBanditsCount = _processedDeviationsCount = 0;
                _pointsTotalCount = deviations.Count() * _bandits.Length;
                _percentProgress = MinProgressPercent;

                int threadsCount = Math.Min(threadsMaxCount, _waitingBanditsThreads.Count);

                for (int i = 0; i < threadsCount; i++)
                    RunNextThread();

                _stopWatch.Restart();
            }
            else
            {
                MessageBox.Show($"Симуляция уже запущена.", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            _stopWatch.Stop();

            foreach (var thread in _runningBanditsThreads)
            {
                thread.Key.DeviationProcessed -= UpdateProgress;
                thread.Key.GameOver -= FinishThread;
                thread.Value.Abort();
            }

            IsPlaying = IsPaused = false;
        }

        public void CancelGame()
        {
            Clear();
            GameOver?.Invoke(false, "Симуляция отменена");
        }

        [Obsolete]
        public void ChangePause()
        {
            if (IsPlaying)
            {
                if (IsPaused)
                {
                    foreach (var thread in _runningBanditsThreads.Values)
                        if (thread.IsAlive)
                            thread.Resume();

                    _stopWatch.Start();
                }
                else
                {
                    foreach (var thread in _runningBanditsThreads.Values)
                        if (thread.IsAlive)
                            thread.Suspend();

                    _stopWatch.Stop();
                }

                IsPaused = !IsPaused;
            }
        }

        public Dictionary<CollectionNames, IEnumerable<object>> GetDataGridViewValues()
        {
            return new Dictionary<CollectionNames, IEnumerable<object>>
            {
                { CollectionNames.ArmsCount, _bandits.Select(bandit => (object)bandit.ArmsCount) },
                { CollectionNames.BatchesCount, _bandits.Select(bandit => (object)bandit.BatchesCount) },
                { CollectionNames.StartBatchSize, _bandits.Select(bandit => (object)bandit.StartBatchSize) },
                { CollectionNames.GrowthRateBatchSize, _bandits.Select(bandit => (object)bandit.GrowthRateBatchSize) },
                { CollectionNames.TimeChangeBatch, _bandits.Select(bandit => (object)bandit.TimeChangeBatch) },
                { CollectionNames.ParameterUCB, _bandits.Select(bandit => bandit is BanditUCB ucb ? (object)ucb.ParameterUCB : 0d) }
            };
        }

        public void SaveGameResult(out bool isSaved)
        {
            FileWriter.Save(this, out isSaved);
        }

        public string GetStringRegretTable()
        {
            string result = string.Empty;

            if (_generalBanditsData.Strategy == Strategy.UCB)
            {
                var parameters = _bandits.Select(bandit => bandit is BanditUCB ucb ? ucb.ParameterUCB : default);
                result += $"d\\a {string.Join(" ", parameters)}\n";
            }

            return result + CollectionHandler.GetRegretTable(Regrets);
        }

        private void UpdateProgress()
        {
            _percentProgress = ++_processedDeviationsCount * ProgressMaxPercent / _pointsTotalCount;
            ProgressChanged?.Invoke(_percentProgress);
        }

        private void RunNextThread()
        {
            if (_waitingBanditsThreads.Count > 0)
            {
                var banditThread = _waitingBanditsThreads.First();

                banditThread.Key.DeviationProcessed += UpdateProgress;
                banditThread.Key.GameOver += FinishThread;

                _runningBanditsThreads.Add(banditThread.Key, banditThread.Value);
                _waitingBanditsThreads.Remove(banditThread.Key);

                banditThread.Value.Start();
            }
        }

        private void FinishThread(Bandit sender)
        {
            _processedBanditsCount++;

            sender.DeviationProcessed -= UpdateProgress;
            sender.GameOver -= FinishThread;

            _runningBanditsThreads.Remove(sender);

            RunNextThread();

            if (_runningBanditsThreads.Count == 0)
                EndGame();
        }

        private void EndGame()
        {
            var indexMinMax = CollectionHandler.GetIndexMinMax(Regrets);

            _generalBanditsData.GameResult = $"{_bandits[indexMinMax].GameResult}\nВремя {GameTime}";
            _stopWatch.Stop();

            IsPlaying = false;
            GameOver?.Invoke(true, GeneralBanditsData.GameResult);
        }
    }
}