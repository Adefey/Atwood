using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Atwood
{
    public partial class Form1 : Form
    {
        Physics physics;
        Graphics graphics;
        Bitmap background = Properties.Resources.Stand;
        BufferedGraphics bufferedGraphics;
        BufferedGraphicsContext bufferedGraphicsContext;

        public Form1()
        {
            InitializeComponent();
            physics = new Physics();
            graphics = pictureBox1.CreateGraphics();
            bufferedGraphicsContext = new BufferedGraphicsContext();
            bufferedGraphics = bufferedGraphicsContext.Allocate(graphics, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = background;
            graphics.FillRectangle(Brushes.Black, 10,10,40,40);
            
        }
    }
}
