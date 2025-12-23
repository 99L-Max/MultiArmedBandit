using MultiArmedBandit.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiArmedBandit
{
    abstract class Bandit
    {
        private readonly double _sqrtDivisionVarianceHorizon;
        private readonly double _sqrtProductVarianceHorizon;

        protected readonly int[] BatchSizes;

        public Bandit(double centralExpectation, double maxVariance, int armsCount, BatchSizeChangeRule batchSizeChangeRule, int batchesCount, int startBatchSize, double growthRateBatchSize, int timeChangeBatch)
        {
            ArmsCount = armsCount;
            CentralExpectation = centralExpectation;
            MaxVariance = maxVariance;

            BatchSizeChangeRule = batchSizeChangeRule;
            StartBatchSize = startBatchSize;
            GrowthRateBatchSize = growthRateBatchSize;
            TimeChangeBatch = timeChangeBatch;

            BatchSizes = HorizonBuilder.GetBatches(batchSizeChangeRule, batchesCount, startBatchSize, growthRateBatchSize, timeChangeBatch).ToArray();
            Horizon = BatchSizes.Sum();

            _sqrtDivisionVarianceHorizon = Math.Sqrt(maxVariance / Horizon);
            _sqrtProductVarianceHorizon = Math.Sqrt(maxVariance * Horizon);
        }

        public event Action DeviationProcessed;
        public event Action<Bandit> GameOver;

        public BatchSizeChangeRule BatchSizeChangeRule { get; }
        public int BatchesCount => BatchSizes.Length;
        public double CentralExpectation { get; }
        public double MaxVariance { get; }
        public int ArmsCount { get; }
        public int Horizon { get; }
        public int StartBatchSize { get; }
        public int TimeChangeBatch { get; }
        public double GrowthRateBatchSize { get; }
        public Regret MaxRegret { get; private set; }
        public IEnumerable<Regret> Regrets { get; private set; }
        public virtual string GameResult => $"l_max = {MaxRegret.Value:f2}\nd_max = {MaxRegret.Deviation:f1}";

        public void Play(IEnumerable<double> deviations, int gamesCount)
        {
            Regret[] regrets = deviations.Select(deviation => new Regret(deviation)).ToArray();

            for (int i = 0; i < regrets.Length; i++)
            {
                if (regrets[i].Deviation == 0d)
                {
                    DeviationProcessed?.Invoke();
                    continue;
                }

                CreateArms(regrets[i].Deviation, _sqrtDivisionVarianceHorizon, out double maxPossibleIncome);

                for (int num = 0; num < gamesCount; num++)
                {
                    PlayStrategy(out double gameIncome);
                    regrets[i].Add(maxPossibleIncome - gameIncome);
                }

                regrets[i].Norm(gamesCount * _sqrtProductVarianceHorizon);
                DeviationProcessed?.Invoke();
            }

            SetRegrets(regrets);
            GameOver?.Invoke(this);
        }

        protected void SetRegrets(IEnumerable<Regret> regrets)
        {
            Regrets = regrets;
            MaxRegret = CollectionHandler.GetMaxRegret(regrets);
        }

        protected abstract void CreateArms(double deviation, double normalizingCoefficient, out double maxPossibleIncome);

        protected abstract void PlayStrategy(out double gameIncome);
    }
}