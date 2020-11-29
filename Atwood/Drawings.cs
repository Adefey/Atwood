using System.Drawing;
using System.Windows.Forms;

namespace Atwood
{
    internal class Drawings
    {
        private readonly Graphics graphics;
        private readonly Bitmap background = Properties.Resources.Stand;
        private readonly Bitmap W6_5G = Properties.Resources.W6_5G;
        private readonly Bitmap W8_5G = Properties.Resources.W8_5G;
        private readonly Bitmap W12G = Properties.Resources.W12G;
        private readonly Bitmap W60G = Properties.Resources.W60G;
        private readonly Bitmap Stop = Properties.Resources.Stop;
        private Bitmap resultBitmap;
        private readonly Pen pen;
        public PictureBox operating;
        public Drawings(ref PictureBox picturebox)
        {
            graphics = picturebox.CreateGraphics();
            pen = new Pen(Color.Black, 3);
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
            Graphics newGFX = Graphics.FromImage(bufBitmap);
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

        public void Draw(double leftCoord, double rightCoord, int stopCoord)
        {
            operating.Image = background; //если убрать очиску экрана все будет норм
            int leftCentreX = (int)((double)23 / 64 * operating.Width);
            int rightCentreX = (int)((double)55 / 96 * operating.Width);
            int UpY = (int)((double)245 / 2172 * operating.Height);
            int rightLow = (int)((rightCoord) - (resultBitmap.Height * ((double)operating.Height / 3000)));
            int leftLow = (int)((leftCoord) - (W60G.Height * ((double)operating.Height / 3000)));
            int stopLow = (int)(stopCoord - (Stop.Height * ((double)operating.Height / 2000)));
            //graphics.DrawLine(new Pen(Color.Red, 8), leftCentreX, operating.Height / 2, rightCentreX, operating.Height / 2);
            graphics.DrawLine(pen, leftCentreX, UpY, leftCentreX, leftLow);
            graphics.DrawLine(pen, rightCentreX, UpY, rightCentreX, rightLow);
            graphics.DrawImage(W60G, new Rectangle(leftCentreX - (int)(0.5 * W60G.Width * ((double)operating.Height / 3000)), leftLow, (int)(W60G.Width * ((double)operating.Height / 3000)), (int)(W60G.Height * ((double)operating.Height / 3000))));
            graphics.DrawImage(resultBitmap, new Rectangle(rightCentreX - (int)(0.5 * resultBitmap.Width * ((double)operating.Height / 3000)), rightLow, (int)(resultBitmap.Width * ((double)operating.Height / 3000)), (int)(resultBitmap.Height * ((double)operating.Height / 3000))));
            graphics.DrawImage(Stop, new Rectangle((rightCentreX + leftCentreX) / 2 - (int)(0.2 * Stop.Width * ((double)operating.Height / 2000)), stopLow, (int)(Stop.Width * ((double)operating.Height / 2000)), (int)((Stop.Height * ((double)operating.Height / 2000)))));
        }
    }
}
