using System.Windows.Forms;

namespace Atwood
{
    internal class Physics
    {
        private readonly double g = 9.8145;
        public Drawings drawings;
        private double ropeLength;
        private readonly double leftWeight = 0.06;
        private double rightWeight;
        private double leftCoord, rightCoord;
        private double velocity;
        private readonly int dt;
        private double RemoveCoord;
        private double StopCoord;
        private readonly double scalingCoef;
        private readonly double height;

        public Physics(ref PictureBox picturebox, int tickTime, double scale)
        {
            leftWeight = Weights.BaseWeight;
            rightWeight = Weights.BaseWeight;
            drawings = new Drawings(ref picturebox);
            drawings.ProcessPictures(false, false, false, false, false, false);
            velocity = 0;
            dt = tickTime;
            scalingCoef = scale;
            height = picturebox.Height;
            rightCoord = height * 61 / 181;
            leftCoord = height * 23 / 27;
        }

        public void SetRightWeight(double NewWeight, bool CHB1, bool CHB2, bool CHB3, bool CHB4, bool CHB5, bool CHB6)
        {
            rightWeight = NewWeight + Weights.BaseWeight;
            drawings.ProcessPictures(CHB1, CHB2, CHB3, CHB4, CHB5, CHB6);
            drawings.Draw(leftCoord, rightCoord, 0, false);
        }
        public double GetRightWeight()
        {
            return rightWeight;
        }

        public double GetLeftWeight()
        {
            return leftWeight;
        }

        public double GetRightVelocity()
        {
            return velocity;
        }
        public double GetRightCoord()
        {
            return rightCoord;
        }

        public void StartMovement(double remove, double stop)
        {
            rightCoord = height * 61 / 181;
            leftCoord = height * 23 / 27;
            ropeLength = leftCoord;
            velocity = 0;
            RemoveCoord = remove * scalingCoef + (height * 61 / 181);
            StopCoord = stop * scalingCoef + (height * 61 / 181);
        }
        public void ProcessPhysics()
        {
            bool separated = false;
            //закоментированные скобки можно убрать ради плавного столкновения с препятствием
            if ((rightCoord < RemoveCoord/* + (height * 61 / 1737)*/) && (rightWeight != leftWeight))
            {
                velocity += (((double)(dt)) / 1000) * g; //dt - это интервал таймера. Делить на тысячу - секунды
            }
            else separated = true;

            if (rightCoord < StopCoord)
            {
                rightCoord += scalingCoef * 2 * ((((double)(dt)) / 1000) * velocity); //длина нити справа увеличивается
                leftCoord = ropeLength - rightCoord + height * 365 / 1086;  //height * 365 / 1086 компенсация начального значения
            }

            drawings.Draw(leftCoord, rightCoord, (int)RemoveCoord, separated);
        } //height*23/362 - одно деление!
    }
}