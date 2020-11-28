using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Atwood
{
    internal class Physics
    {
        public Drawings drawings;
        private double ropeLength;
        private readonly double g = 9.8145;
        private double leftWeight = 0.06;
        private double rightWeight;
        private double leftCoord, rightCoord;
        private double velocity;
        private readonly int dt;
        private double RemoveCoord;
        private double StopCoord;
        private readonly double scalingCoef;
        private readonly double width, height;
        private bool chk1, chk2, chk3;

        public double t;
        private double RemoveL, EndL;
        private double V;
        private double x;


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
        public void SetLengths(double L, double l)
        {
            RemoveL = l;
            EndL = L;
        }
        public void SetRightWeight(double NewWeight, bool CHB1, bool CHB2, bool CHB3)
        {
            rightWeight = NewWeight + Weights.BaseWeight;
            chk1 = CHB1;
            chk2 = CHB2;
            chk3 = CHB3;
            drawings.ProcessPictures(CHB1, CHB2, CHB3);
            drawings.Draw(leftCoord, rightCoord, chk1, chk2, chk3, RemoveCoord);
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
            t = 0;
            rightCoord = 0;
            leftCoord = (double) /* 457 / 543 */ 10000 / 15000 * height;
            ropeLength = leftCoord;
            velocity = 0;
            RemoveCoord = remove;
            StopCoord = stop;
        }
        public void ProcessPhysics()
        {
            if (rightCoord < RemoveCoord * scalingCoef)
            {
                velocity += (((double)(dt)) / 1000) * g; //dt - это интервал таймера. Делить на тысячу - секунды
                //velocity += (GetRightWeight() - leftWeight) * (((double)(dt)) / 100) * g; //неправильно
            }

            if (rightCoord < ropeLength)
            {
                t += (double)(dt) / 1000;
                rightCoord += scalingCoef * ((((double)(dt)) / 100) * velocity); //длина нити справа увеличивается
                leftCoord = ropeLength - rightCoord;  //(очевидно я сделаю нормальное перемещение а не это)
            }

            //t = Math.Sqrt(((Weights.BaseWeight + GetRightWeight()) * Math.Pow(EndL, 2)) / (GetRightWeight() * RemoveL * g)); //нахождение времени из формулы g в методичке

            drawings.Draw(leftCoord, rightCoord, chk1, chk2, chk3, RemoveCoord); //фикс миганий обязателен. Саня займись!!
        }
    }
    public class Stopwatch { }
}