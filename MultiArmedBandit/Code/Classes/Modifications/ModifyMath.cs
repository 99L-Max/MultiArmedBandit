namespace MultiArmedBandit
{
    static class ModifyMath
    {
        public static double Clamp(double value, double min, double max)
        {
            return value < min ? min : value > max ? max : value;
        }
    }
}
