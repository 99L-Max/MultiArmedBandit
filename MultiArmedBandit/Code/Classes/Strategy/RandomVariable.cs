using System;

namespace MultiArmedBandit
{
    class RandomVariable
    {
        private readonly Random _random = new Random();

        public double BernoulliSample(double expectation)
        {
            return _random.NextDouble() < expectation ? 1d : 0d;
        }

        public double NormSample(double expectation, double variance)
        {
            return expectation + Math.Sqrt(variance) * StandardNormSample();
        }

        public double StandardNormSample()
        {
            var phi = _random.NextDouble();
            var r = _random.NextDouble();
            return Math.Cos(2d * Math.PI * phi) * Math.Sqrt(-2d * Math.Log(r));
        }

        public double BetaSample(double alpha, double beta)
        {
            double num1;
            double num2;

            if (alpha == beta)
            {
                num1 = GammaSample(alpha, 1d);
                num2 = GammaSample(beta, 1d);

                if (num1 == 0d && num2 == 0d)
                    return BernoulliSample(0.5);
            }
            else
            {
                do
                {
                    num1 = GammaSample(alpha, 1d);
                    num2 = GammaSample(beta, 1d);
                }
                while (num1 == 0d && num2 == 0d);
            }

            return num1 / (num1 + num2);
        }

        public double GammaSample(double shape, double rate)
        {
            if (double.IsPositiveInfinity(rate))
                return shape;

            double num1 = shape;
            double num2 = 1d;

            if (shape < 1d)
            {
                num1 = shape + 1d;
                num2 = Math.Pow(_random.NextDouble(), 1d / shape);
            }

            double num3 = num1 - 1d / 3d;
            double num4 = 1d / Math.Sqrt(9d * num3);
            double num5, num6, num7;

            do
            {
                num5 = StandardNormSample();

                for (num6 = 1d + num4 * num5; num6 <= 0d; num6 = 1d + num4 * num5)
                    num5 = StandardNormSample();

                num6 = num6 * num6 * num6;
                num7 = _random.NextDouble();
                num5 *= num5;

                if (num7 < 1d - 0.0331 * num5 * num5)
                    return num2 * num3 * num6 / rate;
            }
            while ((Math.Log(num7) < 0.5 * num5 + num3 * (1d - num6 + Math.Log(num6))) == false);

            return num2 * num3 * num6 / rate;
        }
    }
}