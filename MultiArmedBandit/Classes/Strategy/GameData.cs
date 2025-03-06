using System.Collections.Generic;

namespace MultiArmedBandit
{
    class GameData
    {
        public const int DefaultCountArms = Bandit.MinCountArms;
        public const int DefaultNumberBatches = 50;
        public const int DefaultStartBatchSize = 100;
        public const int DefaultTimeChangeBatch = 10;
        public const double DefaultGrowthRateBatchSize = 1d;
        public const double DefaultParameterUCB = 1d;

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
