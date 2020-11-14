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
