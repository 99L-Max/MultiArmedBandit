using System.Collections.Generic;
using System.Collections.ObjectModel;
using MultiArmedBandit.Properties;

namespace MultiArmedBandit
{
    class GameData
    {
        public static readonly ReadOnlyDictionary<CollectionNames, double> CollectionDefault;
        public static readonly ReadOnlyDictionary<CollectionNames, double> CollectionMinimum;
        public static readonly ReadOnlyDictionary<CollectionNames, int> CollectionDecimalPlaces;

        static GameData()
        {
            CollectionDefault = FileHandler.ReadJsonResource<CollectionNames, double>(Resources.Dictionary_Collection_Default);
            CollectionMinimum = FileHandler.ReadJsonResource<CollectionNames, double>(Resources.Dictionary_Collection_Minimum);
            CollectionDecimalPlaces = FileHandler.ReadJsonResource<CollectionNames, int>(Resources.Dictionary_Collection_DecimalPlaces);
        }

        public BatchSizeChangeRule BatchSizeChangeRule { get; set; }
        public Strategy Strategy { get; set; }
        public int CountBandits { get; set; }
        public int CountGames { get; set; }
        public int CountThreads { get; set; }
        public int IndexBestBandit { get; set; }
        public double CentralExpectation { get; set; }
        public double MaxVariance { get; set; }
        public string GameResult { get; set; }
        public int[] CountArms { get; set; }
        public int[] NumberBatches { get; set; }
        public int[] StartBatchSize { get; set; }
        public int[] TimeChangeBatch { get; set; }
        public double[] GrowthRateBatchSize { get; set; }
        public double[] ParameterUCB { get; set; }
        public double[] Deviations { get; set; }
        public Dictionary<double, double[]> Regrets { get; set; }
    }
}
