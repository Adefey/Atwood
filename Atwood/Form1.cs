using System;
using System.Windows.Forms;

namespace Atwood
{
    public partial class Form1 : Form
    {
        private readonly Physics physics;

        public Form1()
        {
            InitializeComponent();
            physics = new Physics(ref pictureBox1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            physics.ProcessPhysics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            physics.StartMovement();
            timer1.Enabled = true;
        }
    }
}
