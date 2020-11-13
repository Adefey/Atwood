using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Atwood
{
    public partial class Form1 : Form
    {
        Physics MyPhysics;
        Graphics GFX;
        int a = 10;
        public Form1()
        {
            InitializeComponent();
            MyPhysics = new Physics();
            GFX = pictureBox1.CreateGraphics();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GFX.Clear(Color.White);
            a += 10;
            GFX.DrawEllipse(new Pen(Color.Green), a, a, 20, 40);
        }
    }
}
