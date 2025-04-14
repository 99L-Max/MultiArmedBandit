using System.Collections.Generic;
using System.Linq;

namespace MultiArmedBandit
{
    class BanditThompsonSampling : Bandit
    {
        private delegate void Sample();

        private readonly ArmThompsonSampling[] _arms;
        private readonly Sample _sample;

        public readonly ConjugateDistribution ConjugateDistribution;

        public BanditThompsonSampling(double centralExpectation, double maxVariance, int countArms, IEnumerable<int> batchSizes, ConjugateDistribution conjugateDistribution) :
            base(centralExpectation, maxVariance, countArms, batchSizes)
        {
            _arms = new ArmThompsonSampling[countArms];

            ConjugateDistribution = conjugateDistribution;

            if (ConjugateDistribution == ConjugateDistribution.Beta)
                _sample = () => { foreach (var arm in _arms) arm.BetaSample(); };
            else
                _sample = () => { foreach (var arm in _arms) arm.NormSample(); };
        }

        protected override void CreateArms(double deviation, double normCoeff, ref double maxPossibleIncome)
        {
            for (int i = 0; i < _arms.Length; i++)
                _arms[i] = new ArmThompsonSampling(CentralExpectation + (i == 0 ? deviation : -deviation) * normCoeff);

            maxPossibleIncome = _arms.Select(x => x.Expectation).Max() * Horizon;
        }

        protected override void PlayStrategy(ref double gameIncome)
        {
            ArmThompsonSampling bestArm;

            for (int i = 0; i < CountArms; i++)
            {
                _arms[i].Reset();
                _arms[i].SetStartValues(_batchSizes[i]);
                _arms[i].Play(_batchSizes[i], ref _sumCounter);
            }

            for (int i = CountArms; i < NumberBatches; i++)
            {
                _sample();

                bestArm = _arms.OrderByDescending(x => x.RandomThompsonVariable).First();
                bestArm.Play(_batchSizes[i], ref _sumCounter);
            }

            gameIncome = _arms.Select(x => x.Income).Sum();
        }
    }
}
