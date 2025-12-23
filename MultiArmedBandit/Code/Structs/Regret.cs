using Newtonsoft.Json;

namespace MultiArmedBandit.Structs
{
    struct Regret
    {
        public Regret(double deviation)
        {
            Deviation = deviation;
            Value = 0d;
        }

        [JsonConstructor]
        public Regret(double deviation, double value)
        {
            Deviation = deviation;
            Value = value;
        }

        public double Deviation { get; }
        public double Value { get; private set; }

        public void Add(double value)
        {
            Value += value;
        }

        public void Norm(double normalizingCoefficient)
        {
            Value /= normalizingCoefficient;
        }
    }
}
