using System.Collections.Generic;
using System.Linq;

namespace MultiArmedBandit
{
    class BanditThompsonSampling : Bandit
    {
        public BanditThompsonSampling(double centralExpectation, double maxVariance, int countArms, IEnumerable<int> batches) :
            base(centralExpectation, maxVariance, countArms, batches)
        { }

        public override void PlayStrategy()
        {
            Arm bestArm;

            for (int i = 0; i < CountArms; i++)
            {
                _arms[i].Reset();
                _arms[i].Play(_batches[i], ref _sumCounter);
            }

            for (int i = CountArms; i < NumberBatches; i++)
            {
                foreach (var arm in _arms)
                    arm.ApplyThompsonSampling();

                bestArm = _arms.OrderByDescending(x => x.ProfitabilityAssessment).First();
                bestArm.Play(_batches[i], ref _sumCounter);
            }
        }
    }
}
