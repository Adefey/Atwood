using System;
using System.Windows.Forms;

namespace Atwood
{
    public partial class Form1 : Form
    {
        private Physics physics;

        public Form1()
        {
            InitializeComponent();
            physics = new Physics(ref pictureBox1, timer1.Interval, 10, pictureBox1.Width, pictureBox1.Height);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            physics.ProcessPhysics();
        }

        private void button1_click(object sender, EventArgs e)
        {
            physics.StartMovement(200);
            timer1.Enabled = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            physics = new Physics(ref pictureBox1, timer1.Interval, 10, pictureBox1.Width, pictureBox1.Height);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var weights = new Weights();
            physics.AddToRight(weights.AddWeight1);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            var weigths = new Weights();
            physics.AddToRight(weigths.AddWeight2); 

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            var weigths = new Weights();
            physics.AddToRight(weigths.AddWeight3);
        }
    }
}
