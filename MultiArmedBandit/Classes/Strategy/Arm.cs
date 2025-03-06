using System;
using MathNet.Numerics.Distributions;

namespace MultiArmedBandit
{
    class Arm
    {
        private readonly OneStepIncome _oneStepIncome;

        public readonly double Expectation;

        public Arm(double expectation)
        {
            _oneStepIncome = new OneStepIncome();

            Expectation = expectation;
        }

        public double RatioVariance { get; private set; } = 1d;
        public double Income { get; private set; }
        public int Counter { get; private set; }
        public double ProfitabilityAssessment { get; private set; }

        public void Reset() =>
            ProfitabilityAssessment = Income = Counter = 0;

        public void Play(int countGames, ref int sumCountGames)
        {
            Counter += countGames;
            sumCountGames += countGames;

            while (countGames-- > 0)
                Income += _oneStepIncome.Sample(Expectation);
        }

        public void EstimateVariance(double maxVariance) =>
            RatioVariance = Income * (Counter - Income) / (Counter * (Counter - 1)) / maxVariance;

        public void ApplyUCB(double parameter, double sumCountGames) =>
            ProfitabilityAssessment = Income / Counter + parameter * Math.Sqrt(RatioVariance * Math.Log(sumCountGames) / Counter);

        public void ApplyThompsonSampling() =>
            ProfitabilityAssessment = new Beta(Income, Counter - Income).Sample();
    }
}