using System.Diagnostics;

namespace Atwood
{
    internal class TruePhysics
    {
        private readonly double g = 9.8145;
        private readonly double stopCoord, removeCoord;
        private readonly double ropeLength = 80;
        private double leftCoord, rightCoord;
        private double velocity;
        private readonly Stopwatch stopWatch = new Stopwatch();
        public TruePhysics(double remove, double stop)
        {
            stopCoord = stop;
            removeCoord = remove;
            leftCoord = 80;
            rightCoord = 0;
        }

        public void Start()
        {
            velocity = 0;
            rightCoord = 0;
            leftCoord = 80;
            stopWatch.Reset();
            stopWatch.Start();
        }
        public void ProcessPhysics()
        {
            if (rightCoord < removeCoord)
            {
                velocity = g * stopWatch.ElapsedMilliseconds / 1000; //получаем в метрах в секунду 
            }

            if (rightCoord < stopCoord)
            {
                rightCoord = velocity * stopWatch.ElapsedMilliseconds / 1000; //получаем в метрах
                leftCoord = ropeLength - rightCoord;
            }

        }

        public double GetLeftCoord()
        {
            return leftCoord;
        }

        public double GetRightCoord()
        {
            return rightCoord;
        }

        public double GetVelocity()
        {
            return velocity;
        }

    }
}
