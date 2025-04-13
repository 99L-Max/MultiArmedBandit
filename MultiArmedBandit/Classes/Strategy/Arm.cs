namespace MultiArmedBandit
{
    abstract class Arm
    {
        protected readonly RandomVariable _randomVariable;

        public readonly double Expectation;

        public Arm(double expectation)
        {
            _randomVariable = new RandomVariable();

            Expectation = expectation;
        }

        public double Variance { get; private set; }
        public double Income { get; private set; }
        public int Counter { get; private set; }
        public double LastBatchIncome { get; private set; }

        public virtual void Reset() =>
            LastBatchIncome = Income = Counter = 0;

        public void Play(int countGames, ref int sumCountGames)
        {
            sumCountGames += countGames;
            Counter += countGames;
            LastBatchIncome = 0d;

            while (countGames-- > 0)
                LastBatchIncome += _randomVariable.BernoulliSample(Expectation);

            Income += LastBatchIncome;
        }

        public void EstimateVariance() =>
            Variance = Income * (Counter - Income) / (Counter * (Counter - 1));
    }
}