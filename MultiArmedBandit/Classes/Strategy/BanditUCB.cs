using System.Collections.Generic;
using System.Linq;

namespace MultiArmedBandit
{
    class BanditUCB : Bandit
    {
        public BanditUCB(double centralExpectation, double maxVariance, int countArms, IEnumerable<int> batches) :
            base(centralExpectation, maxVariance, countArms, batches)
        { }

        public double ParameterUCB { get; set; } = 0d;

        public override string GameResult =>
            $"a = {ParameterUCB:f2}\n{base.GameResult}";

        public override void PlayStrategy()
        {
            Arm bestArm;

            for (int i = 0; i < CountArms; i++)
            {
                _arms[i].Reset();
                _arms[i].Play(_batches[i], ref _sumCounter);
                _arms[i].EstimateVariance();
            }

            for (int i = CountArms; i < NumberBatches; i++)
            {
                foreach (var arm in _arms)
                    arm.ApplyUCB(ParameterUCB, _sumCounter);

                bestArm = _arms.OrderByDescending(x => x.ProfitabilityAssessment).First();
                bestArm.Play(_batches[i], ref _sumCounter);
            }
        }
    }
}
