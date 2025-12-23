using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MultiArmedBandit
{
    static class EnumFactory
    {
        public static IEnumerable<string> GetEnumString<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(value => value.ToString());
        }

        public static IEnumerable<T> GetEnumValuesSkip<T>(params T[] missedValues)
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Except(missedValues);
        }

        public static void SetComboBoxValues<T>(ComboBox comboBox)
        {
            comboBox.Items.AddRange(Enum.GetNames(typeof(T)));
        }
    }
}
