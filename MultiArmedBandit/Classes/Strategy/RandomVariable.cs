using System;

namespace MultiArmedBandit
{
    class RandomVariable
    {
        private readonly Random _random = new Random();

        public double BernoulliSample(double expectation) =>
            _random.NextDouble() < expectation ? 1d : 0d;

        public double StandardNormSample()
        {
            var phi = _random.NextDouble();
            var r = _random.NextDouble();
            return Math.Cos(2d * Math.PI * phi) * Math.Sqrt(-2d * Math.Log(r));
        }

        public double NormSample(double expectation, double variance) =>
            expectation + Math.Sqrt(variance) * StandardNormSample();
    }
}
