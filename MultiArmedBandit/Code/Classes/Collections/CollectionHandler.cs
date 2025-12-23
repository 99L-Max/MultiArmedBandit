using MultiArmedBandit.Structs;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiArmedBandit
{
    static class CollectionHandler
    {
        public static string ConvertToShortString<T>(IEnumerable<T> collection)
        {
            if (collection.Count() < 4)
                return "{" + string.Join("; ", collection) + "}";
            else
                return "{" + $"{collection.First()}; {collection.ElementAt(1)}; ... {collection.Last()}" + "}";
        }

        public static IEnumerable<double> ConvertToDoubles(IEnumerable<string> values)
        {
            foreach (var value in values)
                if (double.TryParse(value, out double result))
                    yield return result;
        }

        public static int GetIndexMinMax(IEnumerable<Regret[]> regrets)
        {
            var index = -1;
            var min = double.MaxValue;

            for (int i = 0; i < regrets.Count(); i++)
            {
                double max = regrets.ElementAt(i).Max(regret => regret.Value);

                if (min > max)
                {
                    min = max;
                    index = i;
                }
            }

            return index;
        }

        public static string GetRegretTable(IEnumerable<Regret[]> regrets)
        {
            var table = new StringBuilder();
            var deviations = regrets.SelectMany(regret => regret).Select(regret => regret.Deviation).Distinct();

            foreach (var deviation in deviations)
            {
                table.Append(deviation);

                for (int i = 0; i < regrets.Count(); i++)
                {
                    table.Append($" {regrets.ElementAt(i).FirstOrDefault(regret => regret.Deviation == deviation).Value}");
                }

                table.Append("\n");
            }

            return table.ToString();
        }

        public static void FindMinMax(IEnumerable<Regret[]> regrets, out double minDeviation, out double maxDeviation, out double minRegret, out double maxRegret)
        {
            minDeviation = maxDeviation = regrets.First().First().Deviation;
            minRegret = maxRegret = regrets.First().First().Value;

            foreach (var array in regrets)
            {
                foreach (var regret in array)
                {
                    if (minDeviation > regret.Deviation)
                        minDeviation = regret.Deviation;

                    if (maxDeviation < regret.Deviation)
                        maxDeviation = regret.Deviation;

                    if (minRegret > regret.Value)
                        minRegret = regret.Value;

                    if (maxRegret < regret.Value)
                        maxRegret = regret.Value;
                }
            }
        }

        public static Regret GetMaxRegret(IEnumerable<Regret> regrets)
        {
            return regrets.Aggregate((max, next) => next.Value > max.Value ? next : max);
        }
    }
}