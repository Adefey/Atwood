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
        private double velocity;
        private readonly int dt;
        private double stopCoord;
        private double scalingCoef;
        private double width, height;
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

    public static class Weights
    {
        public const double BaseWeight = 0.06,
                      AddWeight1 = 0.0065,
                      AddWeight2 = 0.0085,
                      AddWeight3 = 0.012;

    }

    public class Drawings
    {
        private Physics physics;
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

        public void Draw(double leftCoord, double rightCoord, bool chk1, bool chk2, bool chk3)
        {
            operating.Image = background;
            int leftCentreX = (int)((double)23 / 64 * operating.Width);
            int rightCentreX = (int)((double)55 / 96 * operating.Width);
            int UpY = (int)((double)245 / 2172 * operating.Height);
            graphics.DrawLine(new Pen(Color.Black, 3), leftCentreX, UpY, leftCentreX, Convert.ToInt32(leftCoord));
            graphics.DrawLine(new Pen(Color.Black, 3), rightCentreX, UpY, rightCentreX, Convert.ToInt32(rightCoord));
            graphics.DrawImage(W60G, new Rectangle(leftCentreX - operating.Height / 20, Convert.ToInt32(leftCoord), operating.Height / 10, operating.Height / 10));
            graphics.DrawImage(W60G, new Rectangle(rightCentreX - operating.Height / 20, Convert.ToInt32(rightCoord), operating.Height / 10, operating.Height / 10));

            if (chk1)
                graphics.DrawImage(W6_5G, new Rectangle(rightCentreX - operating.Height / 20, Convert.ToInt32(rightCoord) - (int)(operating.Height / 40), operating.Height / 10, operating.Height / 10 / 4));
            if (chk2)
                graphics.DrawImage(W8_5G, new Rectangle(rightCentreX - operating.Height / 20, Convert.ToInt32(rightCoord) - (int)(operating.Height / 13.5), operating.Height / 10, operating.Height / 10 / 2));
            if (chk3)
                graphics.DrawImage(W12G, new Rectangle(rightCentreX - operating.Height / 20, Convert.ToInt32(rightCoord) - (int)(operating.Height / 6.85), operating.Height / 10, operating.Height / 10 / 4 * 3));
        }
    }
}
