using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MultiArmedBandit
{
    abstract class Bandit
    {
        private readonly double _sqrtDivDN;
        private readonly double _sqrtMulDN;

        protected readonly Arm[] _arms;
        protected readonly int[] _batches;
        protected int _sumCounter;

        public readonly double CentralExpectation;
        public readonly double MaxVariance;
        public readonly int NumberBatches;
        public readonly int Horizon;

        public Action DeviationProcessed;
        public Action<Bandit> SimulationFinished;

        public Bandit(double centralExpectation, double maxVariance, int countArms, IEnumerable<int> batches)
        {
            _arms = new Arm[countArms];
            _batches = batches.ToArray();

            CentralExpectation = centralExpectation;
            MaxVariance = maxVariance;
            NumberBatches = _batches.Length;
            Horizon = _batches.Sum();

            _sqrtDivDN = Math.Sqrt(maxVariance / Horizon);
            _sqrtMulDN = Math.Sqrt(maxVariance * Horizon);
        }

        public double MaxDeviation { get; private set; }

        public double MaxRegrets { get; private set; }

        public Dictionary<double, double> Regrets { get; private set; }

        public int CountArms =>
            _arms.Length;

        public virtual string GameResult =>
            $"l_max = {MaxRegrets:f2}\nd_max = {MaxDeviation:f1}";

        public abstract void PlayStrategy();

        public void Play(IEnumerable<double> deviations, int countGames)
        {
            double maxIncome;
            Regrets = deviations.ToDictionary(k => k, v => 0d);

            foreach (var dev in deviations)
            {
                if (dev == 0d)
                {
                    DeviationProcessed?.Invoke();
                    continue;
                }

                for (int i = 0; i < _arms.Length; i++)
                    _arms[i] = new Arm(CentralExpectation + (i == 0 ? dev : -dev) * _sqrtDivDN);

                maxIncome = _arms.Select(x => x.Expectation).Max() * Horizon;

                for (int num = 0; num < countGames; num++)
                {
                    _sumCounter = 0;

                    PlayStrategy();

                    Regrets[dev] += maxIncome - _arms.Select(x => x.Income).Sum();
                }

                Regrets[dev] /= countGames * _sqrtMulDN;
                DeviationProcessed?.Invoke();
            }

            (MaxDeviation, MaxRegrets) = CollectionHandler.GetPairMaxValue(Regrets);
            SimulationFinished?.Invoke(this);
        }
    }
}