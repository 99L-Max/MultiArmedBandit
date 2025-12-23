namespace MultiArmedBandit
{
    class ArmThompsonSampling : Arm
    {
        private double _expectationThompson;
        private double _varianceThompson;
        private double _variancePriopi;

        public ArmThompsonSampling(double expectation) : base(expectation) { }

        public double RandomThompsonVariable { get; private set; }

        public override void Reset()
        {
            base.Reset();
            RandomThompsonVariable = 0d;
        }

        public void SetStartValues(int startBatchSize)
        {
            _expectationThompson = 0d;
            _varianceThompson = startBatchSize;
            _variancePriopi = startBatchSize;
        }

        public void NormSample()
        {
            var previousVariance = _varianceThompson;
            var previousExpectation = _expectationThompson;

            _varianceThompson = 1d / (1d / previousVariance + 1d / _variancePriopi);
            _expectationThompson = _varianceThompson * (previousExpectation / previousVariance + BatchIncome / _variancePriopi);

            RandomThompsonVariable = RandomVariable.NormSample(_expectationThompson, _varianceThompson);
        }

        public void BetaSample()
        {
            RandomThompsonVariable = RandomVariable.BetaSample(Income, GamesCount - Income);
        }
    }
}
