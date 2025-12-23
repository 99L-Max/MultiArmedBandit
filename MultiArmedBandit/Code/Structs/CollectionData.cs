using Newtonsoft.Json;

namespace MultiArmedBandit
{
    struct CollectionData
    {
        [JsonConstructor]
        public CollectionData(string title, double defaultValue, double minimum, int decimalPlaces, bool readOnly)
        {
            Title = title;
            DefaultValue = defaultValue;
            Minimum = minimum;
            DecimalPlaces = decimalPlaces;
            ReadOnly = readOnly;
        }

        public string Title { get; }
        public double DefaultValue { get; }
        public double Minimum { get; }
        public int DecimalPlaces { get; }
        public bool ReadOnly { get; }
    }
}
