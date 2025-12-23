using System;
using System.Collections.Generic;

namespace MultiArmedBandit
{
    class NumbersFactory
    {
        public static IEnumerable<double> CreateDoubleCollection(double start, double step, int count, int decimalPlaces = 2)
        {
            for (int i = 0; i < count; i++)
                yield return Math.Round(start + i * step, decimalPlaces);
        }
    }
}
