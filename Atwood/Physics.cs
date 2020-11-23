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
        private  double leftWeight = 0.06;
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

    public static class Weights
    {
        public const double BaseWeight = 0.06,
                      AddWeight1 = 0.0065,
                      AddWeight2 = 0.0085,
                      AddWeight3 = 0.012;
    }

    public class Drawings
    {
        private readonly Graphics graphics;
        private readonly Bitmap background = Properties.Resources.Stand;
        private readonly Bitmap W6_5G = Properties.Resources.W6_5G;
        private readonly Bitmap W8_5G = Properties.Resources.W8_5G;
        private readonly Bitmap W12G = Properties.Resources.W12G;
        private readonly Bitmap W60G = Properties.Resources.W60G;
        private Bitmap resultBitmap;
        public PictureBox operating;
        public Drawings(ref PictureBox picturebox)
        {
            graphics = picturebox.CreateGraphics();
            operating = picturebox;
        }
        public void ProcessPictures(bool CHB1, bool CHB2, bool CHB3)
        {
            int resHeight = W60G.Height;
            if (CHB1)
            {
                resHeight += W6_5G.Height;
            }

            if (CHB2)
            {
                resHeight += W8_5G.Height;
            }

            if (CHB3)
            {
                resHeight += W12G.Height;
            }

            Bitmap bufBitmap = new Bitmap(W60G.Width, resHeight);
            Graphics newGFX = Graphics.FromImage((Image)bufBitmap);
            int curHeight = 0;

            if (CHB1)
            {
                newGFX.DrawImage(W6_5G, new Point(0, curHeight));
                curHeight += W6_5G.Height;
            }

            if (CHB2)
            {
                newGFX.DrawImage(W8_5G, new Point(0, curHeight));
                curHeight += W8_5G.Height;
            }

            if (CHB3)
            {
                newGFX.DrawImage(W12G, new Point(0, curHeight));
                curHeight += W12G.Height;
            }
            newGFX.DrawImage(W60G, new Point(0, curHeight));
            resultBitmap = bufBitmap;
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
            graphics.DrawImage(resultBitmap, new Rectangle(rightCentreX - operating.Height / 20, Convert.ToInt32(rightCoord), operating.Height / 10, operating.Height / 10));   //поправить высоту правого блока
        }
    }
}
//короче создаешь итоговую картинку в ProcessPicture