using System;
using System.Windows.Forms;

namespace Atwood
{
    public partial class Form1 : Form
    {
        private Physics physics;
        private TruePhysics truePhysics;

        public Form1()
        {
            InitializeComponent();
            physics = new Physics(ref pictureBox1, timer1.Interval, ((double)pictureBox1.Height * 23 / 3620)); //перевод в сантиметры линейки
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            physics.ProcessPhysics();
            truePhysics.ProcessPhysics();
            label5.Text = Math.Round(truePhysics.GetVelocity(), 3).ToString() + "м/с";
            label7.Text = Math.Round(truePhysics.GetRightCoord(), 3).ToString() + "см";
            label14.Text = truePhysics.GetTime().ToString() + "сек";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
           // physics.SetLengths(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3), checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
            physics.StartMovement(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            truePhysics = new TruePhysics(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            truePhysics.Start();
            timer1.Enabled = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            physics = new Physics(ref pictureBox1, timer1.Interval, ((double)pictureBox1.Height * 23 / 3620));
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
        }

        private double CheckAdd(CheckBox chk1, CheckBox chk2, CheckBox chk3)
        {
            double result = 0;
            if (chk1.Checked)
            {
                result += Weights.AddWeight1;
            }

            if (chk2.Checked)
            {
                result += Weights.AddWeight2;
            }

            if (chk3.Checked)
            {
                result += Weights.AddWeight3;
            }

            return result;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3), checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3), checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3), checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
/* 
 Надо сделать:
1. Убрать мерцание (полностью переписать графику, если требуется)
2. Доразработать UI
3. По показателям  физического движка, мы точно видим, что прога работает не в реалтайме. Это надо фиксить9-
 */