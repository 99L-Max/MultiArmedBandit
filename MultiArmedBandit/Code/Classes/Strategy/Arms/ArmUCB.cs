using System;

namespace MultiArmedBandit
{
    class ArmUCB : Arm
    {
        public ArmUCB(double expectation) : base(expectation) { }

        public double UCB { get; private set; }

        public override void Reset()
        {
            base.Reset();
            UCB = 0d;
        }

        public void CalculateUCB(double parameter, double sumGamesCount)
        {
            UCB = Income / GamesCount + parameter * Math.Sqrt(Variance * Math.Log(sumGamesCount) / GamesCount);
        }
    }
}
