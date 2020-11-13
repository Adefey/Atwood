using System;

namespace Atwood
{
    internal class Physics
    {
        private readonly double ropeLength = 0.5;
        private readonly double g = 9.8145;
        private double leftWeight, rightWeight;
        private readonly double leftCoord, rightCoord;
        private readonly Weights weights;
        public Physics()
        {
            Random rnd = new Random();
            ropeLength += (rnd.Next(-1, 1)) / 1000;
            weights = new Weights();
            leftWeight = weights.BaseWeight;
            rightWeight = weights.BaseWeight;
            rightCoord = 0;
            leftCoord = ropeLength;
        }

        public void AddToRight(double NewWeight)
        {
            rightWeight += NewWeight;
        }

        public double GetLength()
        {
            return ropeLength;
        }
        public double GetLeftCoord()
        {
            return leftCoord;
        }
        public double GetRightCoord()
        {
            return rightCoord;
        }
    }

    public class Weights
    {
        public double BaseWeight = 0.06,
                      AddWeight1 = 0.0065,
                      AddWeight2 = 0.0085,
                      AddWeight3 = 0.012;

        public Weights()
        {
            Random rnd = new Random();
            BaseWeight += (rnd.Next(-1, 1)) / 100000;
            AddWeight1 += (rnd.Next(-1, 1)) / 100000;
            AddWeight2 += (rnd.Next(-1, 1)) / 100000;
            AddWeight3 += (rnd.Next(-1, 1)) / 100000;
        }


    }
}
