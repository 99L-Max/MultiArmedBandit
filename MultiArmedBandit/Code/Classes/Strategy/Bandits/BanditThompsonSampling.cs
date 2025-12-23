using MultiArmedBandit.Structs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MultiArmedBandit
{
    class BanditThompsonSampling : Bandit
    {
        private readonly ArmThompsonSampling[] _arms;
        private readonly Sample _sample;

        public BanditThompsonSampling(double centralExpectation, double maxVariance, int armsCount, BatchSizeChangeRule batchSizeChangeRule, int batchesCount, int startBatchSize, double growthRateBatchSize, int timeChangeBatch, ConjugateDistribution conjugateDistribution) :
            base(centralExpectation, maxVariance, armsCount, batchSizeChangeRule, batchesCount, startBatchSize, growthRateBatchSize, timeChangeBatch)
        {
            _arms = new ArmThompsonSampling[armsCount];

            ConjugateDistribution = conjugateDistribution;

            if (ConjugateDistribution == ConjugateDistribution.Beta)
                _sample = () => { foreach (var arm in _arms) arm.BetaSample(); };
            else
                _sample = () => { foreach (var arm in _arms) arm.NormSample(); };
        }

        [JsonConstructor]
        public BanditThompsonSampling(double centralExpectation, double maxVariance, int armsCount, BatchSizeChangeRule batchSizeChangeRule, int batchesCount, int startBatchSize, double growthRateBatchSize, int timeChangeBatch, ConjugateDistribution conjugateDistribution, IEnumerable<Regret> regrets) :
            this(centralExpectation, maxVariance, armsCount, batchSizeChangeRule, batchesCount, startBatchSize, growthRateBatchSize, timeChangeBatch, conjugateDistribution)
        {
            SetRegrets(regrets);
        }

        private delegate void Sample();

        public ConjugateDistribution ConjugateDistribution { get; }

        protected override void CreateArms(double deviation, double normalizingCoefficient, out double maxPossibleIncome)
        {
            for (int i = 0; i < _arms.Length; i++)
                _arms[i] = new ArmThompsonSampling(CentralExpectation + (i == 0 ? deviation : -deviation) * normalizingCoefficient);

            maxPossibleIncome = _arms.Max(arm => arm.Expectation) * Horizon;
        }

        protected override void PlayStrategy(out double gameIncome)
        {
            for (int i = 0; i < _arms.Length; i++)
            {
                _arms[i].Reset();
                _arms[i].SetStartValues(BatchSizes[i]);
                _arms[i].Play(BatchSizes[i]);
            }

            for (int i = _arms.Length; i < BatchesCount; i++)
            {
                _sample();
                _arms.OrderByDescending(arm => arm.RandomThompsonVariable).First().Play(BatchSizes[i]);
            }

            gameIncome = _arms.Sum(arm => arm.Income);
        }
    }
}
