using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiArmedBandit
{
    static class CollectionHandler
    {
        public static bool CheckArraysSameLength(params Array[] arrays) =>
            arrays.All(arr => arr.Length == arrays[0].Length);

        public static (double, double) GetPairMaxValue(IDictionary<double, double> dict)
        {
            var pair = dict.Aggregate((max, next) => next.Value > max.Value ? next : max);
            return (pair.Key, pair.Value);
        }

        public static IEnumerable<double> CreateCollection(double start, double step, int count, int decimalPlaces = 2)
        {
            for (int i = 0; i < count; i++)
                yield return Math.Round(start + i * step, decimalPlaces);
        }

        public static IEnumerable<Bandit> CreateBandits(GameData gameData)
        {
            var batchSizes = new List<IEnumerable<int>>();

            for (int i = 0; i < gameData.CountBandits; i++)
                batchSizes.Add(HorizonBuilder.GetBatches(gameData.BatchSizeChangeRule, gameData.NumberBatches[i], gameData.StartBatchSize[i], gameData.GrowthRateBatchSize[i], gameData.TimeChangeBatch[i]));

            if (gameData.Strategy == Strategy.UCB)
                for (int i = 0; i < gameData.CountBandits; i++)
                    yield return new BanditUCB(gameData.CentralExpectation, gameData.MaxVariance, gameData.CountArms[i], batchSizes[i]);
            else
                for (int i = 0; i < gameData.CountBandits; i++)
                    yield return new BanditThompsonSampling(gameData.CentralExpectation, gameData.MaxVariance, gameData.CountArms[i], batchSizes[i], gameData.ConjugateDistribution);
        }

        public static string ConvertToShortString<T>(IEnumerable<T> collection)
        {
            if (collection.Count() < 4)
                return "{" + string.Join("; ", collection) + "}";
            else
                return "{" + $"{collection.First()}; {collection.ElementAt(1)}; ... {collection.Last()}" + "}";
        }

        public static Dictionary<double, double[]> CreateBanditsRegrets(IEnumerable<double> keys, IEnumerable<Dictionary<double, double>> regrets) => 
            keys.ToDictionary(k => k, v => regrets.Select(x => x[v]).ToArray());
    }
}