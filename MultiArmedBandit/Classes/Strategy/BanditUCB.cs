using System.Collections.Generic;
using System.Linq;

namespace MultiArmedBandit
{
    class BanditUCB : Bandit
    {
        private readonly ArmUCB[] _arms;

        public BanditUCB(double centralExpectation, double maxVariance, int countArms, IEnumerable<int> batchSizes) :
            base(centralExpectation, maxVariance, countArms, batchSizes)
        {
            _arms = new ArmUCB[countArms];
        }

        public double ParameterUCB { get; set; } = 0d;

        public override string GameResult =>
            $"a = {ParameterUCB:f2}\n{base.GameResult}";

        protected override void CreateArms(double deviation, double normCoeff, out double maxPossibleIncome)
        {
            for (int i = 0; i < _arms.Length; i++)
                _arms[i] = new ArmUCB(CentralExpectation + (i == 0 ? deviation : -deviation) * normCoeff);

            maxPossibleIncome = _arms.Select(x => x.Expectation).Max() * Horizon;
        }

        protected override void PlayStrategy(out double gameIncome)
        {
            ArmUCB bestArm;

            for (int i = 0; i < CountArms; i++)
            {
                _arms[i].Reset();
                _arms[i].Play(_batchSizes[i], ref _sumCounter);
                _arms[i].EstimateVariance();
            }

            for (int i = CountArms; i < NumberBatches; i++)
            {
                foreach (var arm in _arms)
                    arm.CalculateUCB(ParameterUCB, _sumCounter);

                bestArm = _arms.OrderByDescending(x => x.UCB).First();
                bestArm.Play(_batchSizes[i], ref _sumCounter);
            }

            gameIncome = _arms.Select(x => x.Income).Sum();
        }
    }
}
