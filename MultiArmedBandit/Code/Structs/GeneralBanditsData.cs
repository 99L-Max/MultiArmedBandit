namespace MultiArmedBandit
{
    struct GeneralBanditsData
    {
        public BatchSizeChangeRule BatchSizeChangeRule { get; set; }
        public Strategy Strategy { get; set; }
        public ConjugateDistribution ConjugateDistribution { get; set; }
        public int GamesCount { get; set; }
        public int ThreadsMaxCount { get; set; }
        public double CentralExpectation { get; set; }
        public double MaxVariance { get; set; }
        public string GameResult { get; set; }
        public double[] Deviations { get; set; }
    }
}
