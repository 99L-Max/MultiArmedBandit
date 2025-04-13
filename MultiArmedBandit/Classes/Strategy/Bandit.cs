using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiArmedBandit
{
    abstract class Bandit
    {
        private readonly double _sqrtDivDN;
        private readonly double _sqrtMulDN;
        private double _maxPossibleIncome;
        private double _gameIncome;

        protected readonly int[] _batchSizes;
        protected int _sumCounter;

        public readonly double CentralExpectation;
        public readonly double MaxVariance;
        public readonly int CountArms;
        public readonly int NumberBatches;
        public readonly int Horizon;

        public Action DeviationProcessed;
        public Action<Bandit> SimulationFinished;

        public Bandit(double centralExpectation, double maxVariance, int countArms, IEnumerable<int> batchSizes)
        {
            _batchSizes = batchSizes.ToArray();

            CountArms = countArms;
            CentralExpectation = centralExpectation;
            MaxVariance = maxVariance;
            NumberBatches = _batchSizes.Length;
            Horizon = _batchSizes.Sum();

            _sqrtDivDN = Math.Sqrt(maxVariance / Horizon);
            _sqrtMulDN = Math.Sqrt(maxVariance * Horizon);
        }

        public double MaxDeviation { get; private set; }

        public double MaxRegrets { get; private set; }

        public Dictionary<double, double> Regrets { get; private set; }

        public virtual string GameResult =>
            $"l_max = {MaxRegrets:f2}\nd_max = {MaxDeviation:f1}";

        protected abstract void CreateArms(double deviation, double normCoeff, ref double maxPossibleIncome);

        protected abstract void PlayStrategy(ref double gameIncome);

        public void Play(IEnumerable<double> deviations, int countGames)
        {
            Regrets = deviations.ToDictionary(k => k, v => 0d);

            foreach (var dev in deviations)
            {
                if (dev == 0d)
                {
                    DeviationProcessed?.Invoke();
                    continue;
                }

                CreateArms(dev, _sqrtDivDN, ref _maxPossibleIncome);

                for (int num = 0; num < countGames; num++)
                {
                    _sumCounter = 0;

                    PlayStrategy(ref _gameIncome);

                    Regrets[dev] += _maxPossibleIncome - _gameIncome;
                }

                Regrets[dev] /= countGames * _sqrtMulDN;
                DeviationProcessed?.Invoke();
            }

            (MaxDeviation, MaxRegrets) = CollectionHandler.GetPairMaxValue(Regrets);
            SimulationFinished?.Invoke(this);
        }
    }
}