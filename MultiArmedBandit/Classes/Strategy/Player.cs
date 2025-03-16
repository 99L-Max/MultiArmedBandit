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
        private readonly Stopwatch _stopWatch = new Stopwatch();
        private readonly Dictionary<Bandit, Thread> _threads = new Dictionary<Bandit, Thread>();

        private int _countProcessedBandits;
        private int _countProcessedDeviation;
        private int _totalCountPoints;
        private Bandit[] _bandits;
        private Queue<Bandit> _waitingBandits;

        public Action<int> ProgressChanged;

        public GameData GameData { get; private set; }
        public int PercentProgress { get; private set; }
        public bool IsPaused { get; private set; } = false;
        public bool IsPlaying { get; private set; } = false;

        public string GameInformation =>
            $"Обработано {_countProcessedBandits} / {_bandits.Length}\n" +
            $"Выполнено {PercentProgress}%\n" +
            $"Время {GameTime}";

        public string GameTime =>
            $"{_stopWatch.Elapsed.Hours:d2}:{_stopWatch.Elapsed.Minutes:d2}:{_stopWatch.Elapsed.Seconds:d2}";

        public Player(in GameData gameData)
        {
            if (!CollectionHandler.CheckArraysSameLength(
                gameData.CountArms,
                gameData.NumberBatches,
                gameData.StartBatchSize,
                gameData.GrowthRateBatchSize,
                gameData.TimeChangeBatch,
                gameData.ParameterUCB))
            {
                throw new ArgumentException("Несоответствие размеров массива.");
            }

            GameData = gameData;
        }

        public void Clear()
        {
            CancelGame();
            ClearBanditsEvents();
            GameData.Regrets?.Clear();
        }

        private void ClearBanditsEvents()
        {
            if (_bandits != null)
                foreach (var b in _bandits)
                {
                    b.DeviationProcessed -= UpdateProgress;
                    b.SimulationFinished -= FinishThread;
                    b.Regrets?.Clear();
                }
        }

        private void UpdateProgress()
        {
            PercentProgress = ++_countProcessedDeviation * 100 / _totalCountPoints;
            ProgressChanged?.Invoke(PercentProgress);
        }

        private int GetIndexBestBandit()
        {
            var minMax = double.MaxValue;
            var indexMinMax = -1;

            for (int i = 0; i < _bandits.Length; i++)
                if (minMax > _bandits[i].MaxRegrets)
                {
                    minMax = _bandits[i].MaxRegrets;
                    indexMinMax = i;
                }

            return indexMinMax;
        }

        private void StartThread()
        {
            if (_waitingBandits.Count > 0)
            {
                var b = _waitingBandits.Dequeue();
                var th = new Thread(() => b.Play(GameData.Deviations, GameData.CountGames));

                b.DeviationProcessed += UpdateProgress;
                b.SimulationFinished += FinishThread;

                _threads.Add(b, th);
                th.Start();
            }
        }

        private void FinishThread(Bandit sender)
        {
            _countProcessedBandits++;

            sender.DeviationProcessed -= UpdateProgress;
            sender.SimulationFinished -= FinishThread;

            _threads.Remove(sender);

            StartThread();

            if (_threads.Count == 0)
                FinishGame();
        }

        private void FinishGame()
        {
            GameData.IndexBestBandit = GetIndexBestBandit();
            GameData.Regrets = CollectionHandler.CreateBanditsRegrets(GameData.Deviations, _bandits.Select(x => x.Regrets));
            GameData.GameResult = $"{_bandits[GameData.IndexBestBandit].GameResult}\nВремя {GameTime}";

            ClearBanditsEvents();
            _stopWatch.Stop();

            IsPlaying = false;
        }

        public void Play()
        {
            if (!IsPlaying)
            {
                IsPlaying = true;
                IsPaused = false;
                PercentProgress = 0;
                GameData.GameResult = string.Empty;

                ClearBanditsEvents();
                _bandits = CollectionHandler.CreateBandits(GameData).ToArray();

                if (GameData.Strategy == Strategy.UCB)
                    for (int i = 0; i < _bandits.Length; i++)
                        (_bandits[i] as BanditUCB).ParameterUCB = GameData.ParameterUCB[i];

                _countProcessedBandits = _countProcessedDeviation = 0;
                _totalCountPoints = GameData.Deviations.Count() * _bandits.Length;
                _waitingBandits = new Queue<Bandit>(_bandits);

                int maxCountThreads = Math.Min(GameData.CountThreads, _waitingBandits.Count);

                while (maxCountThreads-- > 0)
                    StartThread();

                _stopWatch.Restart();
            }
            else
                MessageBox.Show($"Симуляция уже запущена.", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        [Obsolete]
        public void ChangePause()
        {
            if (IsPlaying)
            {
                if (IsPaused)
                {
                    foreach (var th in _threads.Values)
                        if (th.IsAlive) th.Resume();

                    _stopWatch.Start();
                }
                else
                {
                    foreach (var th in _threads.Values)
                        if (th.IsAlive) th.Suspend();

                    _stopWatch.Stop();
                }

                IsPaused = !IsPaused;
            }
        }

        public void CancelGame()
        {
            _stopWatch.Stop();

            foreach (var th in _threads)
            {
                th.Key.DeviationProcessed -= UpdateProgress;
                th.Key.SimulationFinished -= FinishThread;
                th.Value.Abort();
            }

            IsPlaying = IsPaused = false;
        }
    }
}