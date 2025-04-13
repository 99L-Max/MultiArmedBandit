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

        public void EstimateValues()
        {
            var prevVariance = _varianceThompson;
            var prevExpectation = _expectationThompson;

            _varianceThompson = 1d / (1d / prevVariance + 1d / _variancePriopi);
            _expectationThompson = _varianceThompson * (prevExpectation / prevVariance + LastBatchIncome / _variancePriopi);
        }

        public void Sample() =>
            RandomThompsonVariable = _randomVariable.NormSample(_expectationThompson, _varianceThompson);
    }
}
