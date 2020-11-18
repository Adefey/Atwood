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
            drawings.Draw(leftCoord, rightCoord); //фикс миганий обязателен. Саня займись!!
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
        private readonly Bitmap W6_5G = Properties.Resources.W6_5G;
        private readonly Bitmap W8_5G = Properties.Resources.W8_5G;
        private readonly Bitmap W12G = Properties.Resources.W12G;
        private readonly Bitmap W60G = Properties.Resources.W60G;

        public PictureBox operating;
        public Drawings(ref PictureBox picturebox)
        {
            graphics = picturebox.CreateGraphics();
            operating = picturebox;
        }

        public void Draw(double leftCoord, double rightCoord)
        {
            operating.Image = background;
            int leftCentreX = (int)((double) 23 / 64 * operating.Width);
            int rightCentreX = (int)((double) 55 / 96 * operating.Width);
            int UpY = (int)((double) 245 / 2172 * operating.Height);
            graphics.DrawLine(new Pen(Color.Black, 3), leftCentreX, UpY, leftCentreX, Convert.ToInt32(leftCoord));
            graphics.DrawLine(new Pen(Color.Black, 3), rightCentreX, UpY, rightCentreX, Convert.ToInt32(rightCoord));
            graphics.DrawImage(W60G, new Rectangle(leftCentreX - 20, Convert.ToInt32(leftCoord), operating.Height/10, operating.Height/10));
            graphics.DrawImage(W60G, new Rectangle(rightCentreX - 20, Convert.ToInt32(rightCoord), operating.Height/10, operating.Height/10));
        }
    }
}
