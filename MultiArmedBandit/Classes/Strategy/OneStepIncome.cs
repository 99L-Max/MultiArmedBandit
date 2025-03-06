using System;

namespace MultiArmedBandit
{
    class OneStepIncome
    {
        private readonly Random _random = new Random();

        public double Sample(double expectation) =>
            _random.NextDouble() < expectation ? 1d : 0d;
    }
}
