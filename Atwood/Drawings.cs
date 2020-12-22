using System.Drawing;
using System.Windows.Forms;

namespace Atwood
{
    internal class Drawings
    {
        private int leftCentreX;
        private int rightCentreX;
        private int UpY;
        private int rightLow;
        private int leftLow;
        private int stopLow;
        private readonly Graphics graphics;
        private readonly Bitmap W6_5G = Properties.Resources.W6_5G;
        private readonly Bitmap W8_5G = Properties.Resources.W8_5G;
        private readonly Bitmap W12G = Properties.Resources.W12G;
        private readonly Bitmap W60G = Properties.Resources.W60G;
        private readonly Bitmap Stop = Properties.Resources.Stop;
        private readonly Bitmap W2G = Properties.Resources.W2G;
        private readonly Bitmap W4G = Properties.Resources.W4G;
        private readonly Bitmap W6G = Properties.Resources.W6G;
        private Bitmap resultBitmap;
        private Bitmap separatedBitmap;

        private readonly Pen pen;
        public PictureBox operating;
        private readonly Image resultImage;
        public Drawings(ref PictureBox picturebox)
        {
            resultImage = new Bitmap(picturebox.Width, picturebox.Height);
            graphics = Graphics.FromImage(resultImage);
            pen = new Pen(Color.Black, 3);
            operating = picturebox;
            leftCentreX = (int)((double)23 / 64 * picturebox.Width);
            rightCentreX = (int)((double)55 / 96 * picturebox.Width);
            UpY = (int)((double)250 / 1500 * picturebox.Width);
        }

        public void ProcessPictures(bool CHB1, bool CHB2, bool CHB3, bool CHB4, bool CHB5, bool CHB6)
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
            if (CHB4)
            {
                resHeight += W2G.Height;
            }

            if (CHB5)
            {
                resHeight += W2G.Height;
            }

            if (CHB6)
            {
                resHeight += W6G.Height;
            }
            Bitmap bufBitmap1 = new Bitmap(W60G.Width, resHeight);
            Graphics newGFX1 = Graphics.FromImage(bufBitmap1);
            Bitmap bufBitmap2 = new Bitmap(W60G.Width, resHeight - W60G.Height + 1);
            Graphics newGFX2 = Graphics.FromImage(bufBitmap2);
            int curHeight = 0;

            if (CHB4)
            {
                newGFX1.DrawImage(W2G, new Point(0, curHeight));
                newGFX2.DrawImage(W2G, new Point(0, curHeight));
                curHeight += W2G.Height;
            }

            if (CHB5)
            {
                newGFX1.DrawImage(W4G, new Point(0, curHeight));
                newGFX2.DrawImage(W4G, new Point(0, curHeight));
                curHeight += W4G.Height;
            }

            if (CHB6)
            {
                newGFX1.DrawImage(W6G, new Point(0, curHeight));
                newGFX2.DrawImage(W6G, new Point(0, curHeight));
                curHeight += W6G.Height;
            }
            if (CHB1)
            {
                newGFX1.DrawImage(W6_5G, new Point(0, curHeight));
                newGFX2.DrawImage(W6_5G, new Point(0, curHeight));
                curHeight += W6_5G.Height;
            }

            if (CHB2)
            {
                newGFX1.DrawImage(W8_5G, new Point(0, curHeight));
                newGFX2.DrawImage(W8_5G, new Point(0, curHeight));
                curHeight += W8_5G.Height;
            }

            if (CHB3)
            {
                newGFX1.DrawImage(W12G, new Point(0, curHeight));
                newGFX2.DrawImage(W12G, new Point(0, curHeight));
                curHeight += W12G.Height;
            }

            newGFX1.DrawImage(W60G, new Point(0, curHeight));
            resultBitmap = bufBitmap1;
            separatedBitmap = bufBitmap2;
        }

        public void Draw(double leftCoord, double rightCoord, int stopCoord, bool separated)
        {
            graphics.Clear(Color.Transparent);
            rightLow = (int)((rightCoord) - (W60G.Height * ((double)operating.Height / 3000)));
            leftLow = (int)((leftCoord) - (W60G.Height * ((double)operating.Height / 3000)));
            stopLow = (int)(stopCoord - (Stop.Height * ((double)operating.Height / 2000)));
            graphics.DrawLine(pen, leftCentreX, UpY, leftCentreX, leftLow);
            graphics.DrawLine(pen, rightCentreX, UpY, rightCentreX, rightLow);
            graphics.DrawImage(W60G, new Rectangle(leftCentreX - (int)(0.5 * W60G.Width * ((double)operating.Height / 3000)), leftLow, (int)(W60G.Width * ((double)operating.Height / 3000)), (int)(W60G.Height * ((double)operating.Height / 3000))));
            graphics.DrawImage(Stop, new Rectangle((rightCentreX + leftCentreX) / 2 - (int)(0.2 * Stop.Width * ((double)operating.Height / 2000)), stopLow, (int)(Stop.Width * ((double)operating.Height / 2000)), (int)((Stop.Height * ((double)operating.Height / 2000)))));
            if (!separated)
            {
                rightLow = (int)((rightCoord) - (resultBitmap.Height * ((double)operating.Height / 3000)));
                graphics.DrawImage(resultBitmap, new Rectangle(rightCentreX - (int)(0.5 * resultBitmap.Width * ((double)operating.Height / 3000)), rightLow, (int)(resultBitmap.Width * ((double)operating.Height / 3000)), (int)(resultBitmap.Height * ((double)operating.Height / 3000))));
            }
            else
            {
                graphics.DrawImage(separatedBitmap, new Rectangle(rightCentreX - (int)(0.5 * separatedBitmap.Width * ((double)operating.Height / 3000)), (int)(stopCoord - (separatedBitmap.Height * ((double)operating.Height / 3000))), (int)(W60G.Width * ((double)operating.Height / 3000)), (int)(separatedBitmap.Height * ((double)operating.Height / 3000))));
                graphics.DrawImage(W60G, new Rectangle(rightCentreX - (int)(0.5 * resultBitmap.Width * ((double)operating.Height / 3000)), rightLow, (int)(W60G.Width * ((double)operating.Height / 3000)), (int)(W60G.Height * ((double)operating.Height / 3000))));
            }
            operating.Image = resultImage;
        }
    }
}
