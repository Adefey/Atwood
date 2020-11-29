using System.Diagnostics;

namespace Atwood
{
    internal class TruePhysics
    {
        private double g = 9.8145;
        private double stopCoord, removeCoord;
        private double rightCoord;
        private double velocity;
        private Stopwatch stopWatch = new Stopwatch();
        public TruePhysics(double remove, double stop)
        {
            stopCoord = stop;
            removeCoord = remove;
            rightCoord = 0;
        }

        public void Start()
        {
            velocity = 0;
            rightCoord = 0;
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
            }
            else
            {
                stopWatch.Stop();
            }

        }

        public double GetRightCoord()
        {
            return rightCoord;
        }

        public double GetVelocity()
        {
            return velocity;
        }

        public double GetTime()
        {
            return (double)stopWatch.ElapsedMilliseconds / 1000;
        }
    }
}
