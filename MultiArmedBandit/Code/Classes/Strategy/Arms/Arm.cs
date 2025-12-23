namespace MultiArmedBandit
{
    abstract class Arm
    {
        private const double MinExpectation = 0d;
        private const double MaxExpectation = 1d;

        protected readonly RandomVariable RandomVariable;

        public Arm(double expectation)
        {
            RandomVariable = new RandomVariable();
            Expectation = ModifyMath.Clamp(expectation, MinExpectation, MaxExpectation);
            Variance = Expectation * (MaxExpectation - Expectation);
        }

        public double Expectation { get; }
        public double Variance { get; private set; }
        public double Income { get; private set; }
        public int GamesCount { get; private set; }
        public double BatchIncome { get; private set; }

        public virtual void Reset()
        {
            BatchIncome = Income = GamesCount = 0;
        }

        public void EstimateVariance()
        {
            Variance = Income * (GamesCount - Income) / (GamesCount * (GamesCount - 1));
        }

        public void Play(int gamesCount)
        {
            GamesCount += gamesCount;
            BatchIncome = 0d;

            for (int i = 0; i < gamesCount; i++)
            {
                BatchIncome += RandomVariable.BernoulliSample(Expectation);
            }

            Income += BatchIncome;
        }
    }
}