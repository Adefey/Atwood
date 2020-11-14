using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Atwood
{
    internal class Physics
    {
        public Drawings drawings;
        private double ropeLength = 0.5;
        private double g = 9.8145;
        private double leftWeight, rightWeight;
        private double leftCoord, rightCoord;
        private  Weights weights;
        private double time;
        private double velocity;
        private Stopwatch stopwatch = new Stopwatch();
        public Physics(ref PictureBox picturebox)
        {
            Random rnd = new Random();
            ropeLength += (rnd.Next(-1, 1)) / 1000;
            weights = new Weights();
            leftWeight = weights.BaseWeight;
            rightWeight = weights.BaseWeight;
            rightCoord = 0;
            leftCoord = ropeLength;
            drawings = new Drawings(ref picturebox);

        }

        public void AddToRight(double NewWeight)
        {
            rightWeight += NewWeight;
        }

        public void StartMovement()
        {
            stopwatch.Reset();
            stopwatch.Start();
            rightCoord = 0;
            leftCoord = ropeLength;
        }
        public void ProcessPhysics()
        {
            time = stopwatch.ElapsedMilliseconds/10; //это черновик чтобы просто увидеть анимацию
            leftCoord = 500 - time;                  //очевидно я сделаю нормальное перемещение 
            rightCoord = time;
            drawings.Draw(leftCoord, rightCoord);
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
        Graphics graphics;
        Bitmap background = Properties.Resources.Stand;
        PictureBox operating;
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
