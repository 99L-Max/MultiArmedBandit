using MultiArmedBandit.Structs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MultiArmedBandit
{
    class BanditUCB : Bandit
    {
        private readonly ArmUCB[] _arms;

        public BanditUCB(double centralExpectation, double maxVariance, int armsCount, BatchSizeChangeRule batchSizeChangeRule, int batchesCount, int startBatchSize, double growthRateBatchSize, int timeChangeBatch, double parameterUCB) :
            base(centralExpectation, maxVariance, armsCount, batchSizeChangeRule, batchesCount, startBatchSize, growthRateBatchSize, timeChangeBatch)
        {
            _arms = new ArmUCB[armsCount];
            ParameterUCB = parameterUCB;
        }

        [JsonConstructor]
        public BanditUCB(double centralExpectation, double maxVariance, int armsCount, BatchSizeChangeRule batchSizeChangeRule, int batchesCount, int startBatchSize, double growthRateBatchSize, int timeChangeBatch, double parameterUCB, IEnumerable<Regret> regrets) : 
            this(centralExpectation, maxVariance, armsCount, batchSizeChangeRule, batchesCount, startBatchSize, growthRateBatchSize, timeChangeBatch, parameterUCB)
        {
            SetRegrets(regrets);
        }

        public double ParameterUCB { get; }

        public override string GameResult => $"a = {ParameterUCB:f2}\n{base.GameResult}";

        protected override void CreateArms(double deviation, double normalizingCoefficient, out double maxPossibleIncome)
        {
            for (int i = 0; i < _arms.Length; i++)
                _arms[i] = new ArmUCB(CentralExpectation + (i == 0 ? deviation : -deviation) * normalizingCoefficient);

            maxPossibleIncome = _arms.Max(arm => arm.Expectation) * Horizon;
        }

        protected override void PlayStrategy(out double gameIncome)
        {
            int sumGamesCount = 0;

            for (int i = 0; i < _arms.Length; i++)
            {
                _arms[i].Reset();
                _arms[i].Play(BatchSizes[i]);
                _arms[i].EstimateVariance();

                sumGamesCount += BatchSizes[i];
            }

            for (int i = _arms.Length; i < BatchesCount; i++)
            {
                foreach (var arm in _arms)
                    arm.CalculateUCB(ParameterUCB, sumGamesCount);

                _arms.OrderByDescending(arm => arm.UCB).First().Play(BatchSizes[i]);
                sumGamesCount += BatchSizes[i];
            }

            gameIncome = _arms.Sum(arm => arm.Income);
        }
    }
}
