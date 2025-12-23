using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiArmedBandit
{
    static class HorizonBuilder
    {
        public static IEnumerable<int> GetBatches(BatchSizeChangeRule rule, int batchesCount, int startBatchSize, double growthRateBatchSize, int timeChangeBatch)
        {
            var bacthSize = startBatchSize;
            var changeСounter = 0;

            for (int i = 1; i <= batchesCount; i++)
            {
                yield return bacthSize;

                if (++changeСounter >= timeChangeBatch)
                {
                    changeСounter = 0;
                    bacthSize = GetBatchSize(rule, i, startBatchSize, growthRateBatchSize, timeChangeBatch);
                }
            }
        }

        public static int GetHorizon(BatchSizeChangeRule rule, int batchesCount, int startBatchSize, double growthRateBatchSize, int timeChangeBatch)
        {
            return GetBatches(rule, batchesCount, startBatchSize, growthRateBatchSize, timeChangeBatch).Sum();
        }

        private static int GetBatchSize(BatchSizeChangeRule rule, int indexBatch, int startBatchSize, double growthRateBatchSize, int timeChangeBatch)
        {
            switch (rule)
            {
                default:
                    return startBatchSize;

                case BatchSizeChangeRule.IncreaseByPercentage:
                    return (int)(Math.Pow(growthRateBatchSize, indexBatch / timeChangeBatch) * startBatchSize);

                case BatchSizeChangeRule.IncreaseByFixedNumberData:
                    return startBatchSize + (int)Math.Round((growthRateBatchSize - 1d) * startBatchSize) * (indexBatch / timeChangeBatch);
            }
        }
    }
}
