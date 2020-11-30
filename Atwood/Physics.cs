using System.Diagnostics;
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
        private readonly double width, height;
        private bool chk1, chk2, chk3;

        //  private double RemoveL, EndL;
        //  private readonly double V;
        //  private readonly double x;


        public Physics(ref PictureBox picturebox, int tickTime, double scale)
        {
            leftWeight = Weights.BaseWeight;
            rightWeight = Weights.BaseWeight;
            drawings = new Drawings(ref picturebox);
            drawings.ProcessPictures(false, false, false);
            velocity = 0;
            dt = tickTime;
            scalingCoef = scale;
            width = picturebox.Width;
            height = picturebox.Height;
            rightCoord = height * 61 / 181;
            leftCoord = height * 23 / 27;
        }
        //public void SetLengths(double L, double l)
        //{
        //    RemoveL = l;
        //    EndL = L;
        //}
        public void SetRightWeight(double NewWeight, bool CHB1, bool CHB2, bool CHB3)
        {
            rightWeight = NewWeight + Weights.BaseWeight;
            chk1 = CHB1;
            chk2 = CHB2;
            chk3 = CHB3;
            drawings.ProcessPictures(CHB1, CHB2, CHB3);
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
            //rightCoord = 365 / 1086 * (double)height;
            // leftCoord =  /* 457 / 543  3 / 4 */ 458 / 543 * (double)height;
            rightCoord = height * 61 / 181;
            leftCoord = height * 23 / 27;
            ropeLength = leftCoord;
            velocity = 0;
            RemoveCoord = remove * scalingCoef + (height * 61 / 181);
            StopCoord = stop * scalingCoef + (height * 61 / 181);
        }
        public void ProcessPhysics()
        {
            bool separated=false;
            if (rightCoord < RemoveCoord)
            {
                velocity += (((double)(dt)) / 1000) * g; //dt - это интервал таймера. Делить на тысячу - секунды
                //velocity += (GetRightWeight() - leftWeight) * (((double)(dt)) / 100) * g; //неправильно
            }
            else separated = true;

            if (rightCoord < StopCoord)
            {
                rightCoord += scalingCoef * 2 * ((((double)(dt)) / 1000) * velocity); //длина нити справа увеличивается
                leftCoord = ropeLength - rightCoord + height * 365 / 1086;  //height * 365 / 1086 компенсация начального значения
            }

            //t = Math.Sqrt(((Weights.BaseWeight + GetRightWeight()) * Math.Pow(EndL, 2)) / (GetRightWeight() * RemoveL * g)); //нахождение времени из формулы g в методичке

            drawings.Draw(leftCoord, rightCoord, (int)RemoveCoord, separated); //фикс миганий обязателен. Саня займись!!
        } //height*23/362 - одно деление!
    }
}