using System;
using System.Drawing;
using System.Windows.Forms;

namespace Atwood
{
    internal class Physics
    {
        public Drawings drawings;
        private double ropeLength;
        private readonly double g = 9.8145;
        private double leftWeight;
        private double rightWeight;
        private double leftCoord, rightCoord;
        private Weights weights;
        private double velocity;
        private int dt;
        private double stopCoord;
        private double scalingCoef;
        private double width, height;
        public Physics(ref PictureBox picturebox, int tickTime, int scale, int width, int height)
        {
            Random rnd = new Random();
            weights = new Weights();
            leftWeight = weights.BaseWeight;
            rightWeight = weights.BaseWeight;
            rightCoord = 0;
            drawings = new Drawings(ref picturebox);
            velocity = 0;
            dt = tickTime;
            scalingCoef = scale;
            this.width = width;
            this.height = height;
        }

        public void AddToRight(double NewWeight)
        {
            rightWeight += NewWeight;
        }

        public void StartMovement(double obstacleCoord)
        {
            rightCoord = 0;
            leftCoord = (double)457 / 543 * height;
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

            leftCoord = ropeLength - rightCoord;                   //очевидно я сделаю нормальное перемещение а не это
            drawings.Draw(leftCoord, rightCoord); //фикс миганий обяззателен. Саня займись
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

    public class Drawings
    {
        private readonly Graphics graphics;
        private readonly Bitmap background = Properties.Resources.Stand;
        public PictureBox operating;
        public Drawings(ref PictureBox picturebox)
        {
            graphics = picturebox.CreateGraphics();
            operating = picturebox;
        }

        public void Draw(double leftCoord, double rightCoord)
        {
            operating.Image = background;
            graphics.FillRectangle(Brushes.Black, 10, Convert.ToInt32(leftCoord), 50, 50);
            graphics.FillRectangle(Brushes.Black, 250, Convert.ToInt32(rightCoord), 50, 50);
        }
    }
}
