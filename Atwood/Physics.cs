using System;

namespace Atwood
{
    internal class Physics
    {
        private readonly double ropeLength = 50;
        private readonly double g = 9.8145;
        private readonly double leftWeight, rightWeight;
        private readonly double leftCoord, rightCoord;
        private Weights weights;
        public Physics()
        {
            weights = new Weights();
            leftWeight = weights.BaseWeight;
            rightWeight = weights.BaseWeight;
            rightCoord = 0;
            leftCoord = 50;
        }
    }

    internal class Weights
    {
        public double BaseWeight = 0.06,
                      AddWeight1 = 0.0065,
                      AddWeight2 = 0.0085,
                      AddWeight3 = 0.012;

        public Weights()
        {
            Random rnd = new Random();
            BaseWeight += (rnd.Next(-1, 1))/100000;
            AddWeight1 += (rnd.Next(-1, 1)) / 100000;
            AddWeight2 += (rnd.Next(-1, 1)) / 100000;
            AddWeight3 += (rnd.Next(-1, 1)) / 100000;
        }


    }
}
