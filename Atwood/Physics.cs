using System;
using System.Windows.Forms;

namespace Atwood
{
    internal class Physics
    {
        public Drawings drawings;
        private double ropeLength;
        private readonly double g = 9.8145;
        private readonly double leftWeight = 0.06;
        private double rightWeight;
        private double leftCoord, rightCoord;
        private double velocity;
        private readonly int dt;
        private double stopCoord;
        private readonly double scalingCoef;
        private readonly double width, height;
        private bool chk1, chk2, chk3;

        public Physics(ref PictureBox picturebox, int tickTime, int scale, int width, int height)
        {
            Random rnd = new Random();
            leftWeight = Weights.BaseWeight;
            rightWeight = Weights.BaseWeight;
            rightCoord = 0;
            drawings = new Drawings(ref picturebox);
            velocity = 0;
            dt = tickTime;
            scalingCoef = scale;
            this.width = width;
            this.height = height;
        }

        public void SetRightWeight(double NewWeight, bool CHB1, bool CHB2, bool CHB3)
        {
            rightWeight = NewWeight + Weights.BaseWeight;
            chk1 = CHB1;
            chk2 = CHB2;
            chk3 = CHB3;
            drawings.ProcessPictures(CHB1, CHB2, CHB3);
            drawings.Draw(leftCoord, rightCoord, chk1, chk2, chk3);
        }
        public double GetRightWeight()
        {
            return rightWeight;
        }

        public double GetRightVelocity()
        {
            return velocity;
        }
        public double GetRightCoord()
        {
            return rightCoord;
        }

        public void StartMovement(double obstacleCoord)
        {
            rightCoord = 120;
            leftCoord = (double) /* 457 / 543 */ 10000 / 12580 * height;
            ropeLength = leftCoord;
            velocity = 0;
            stopCoord = obstacleCoord;
        }
        public void ProcessPhysics()
        {
            if (rightCoord < stopCoord * scalingCoef)
            {
                velocity += (((double)(dt)) / 1000) * g; //dt - это интервал таймера. Делить на тысячу - секунды
            }

            if (rightCoord < ropeLength)
            {
                rightCoord += scalingCoef * ((((double)(dt)) / 1000) * velocity); //расстояние увеличивается
            }

            leftCoord = ropeLength - rightCoord + 90;  //(очевидно я сделаю нормальное перемещение а не это) //fixed
            drawings.Draw(leftCoord, rightCoord, chk1, chk2, chk3); //фикс миганий обязателен. Саня займись!!
        }
    }
}
//короче создаешь итоговую картинку в ProcessPicture