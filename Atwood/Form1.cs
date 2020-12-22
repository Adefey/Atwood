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
            KeyPreview = true;
            physics = new Physics(ref pictureBox1, timer1.Interval, ((double)pictureBox1.Height * 23 / 3620)); //перевод в сантиметры линейки
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
            physics.ProcessPhysics();
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
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6),
                checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked, checkBox5.Checked, checkBox6.Checked);
            physics.StartMovement(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            truePhysics = new TruePhysics(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), physics.GetRightWeight());
            truePhysics.Start();
            timer1.Enabled = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            physics = new Physics(ref pictureBox1, timer1.Interval, ((double)pictureBox1.Height * 23 / 3620));
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
            physics.ProcessPhysics();
        }

        private double CheckAdd(CheckBox chk1, CheckBox chk2, CheckBox chk3, CheckBox chk4, CheckBox chk5, CheckBox chk6)
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

            if (chk4.Checked)
            {
                result += Weights.AddWeight2G;
            }

            if (chk5.Checked)
            {
                result += Weights.AddWeight4G;
            }

            if (chk6.Checked)
            {
                result += Weights.AddWeight6G;
            }

            return result;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6),
                checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked, checkBox5.Checked, checkBox6.Checked);
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
            truePhysics = new TruePhysics(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), physics.GetRightWeight());
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6),
                 checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked, checkBox5.Checked, checkBox6.Checked);
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
            truePhysics = new TruePhysics(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), physics.GetRightWeight());
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6),
                checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked, checkBox5.Checked, checkBox6.Checked);
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
            truePhysics = new TruePhysics(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), physics.GetRightWeight());
        }  

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6),
                checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked, checkBox5.Checked, checkBox6.Checked);
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
            truePhysics = new TruePhysics(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), physics.GetRightWeight());
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6),
                checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked, checkBox5.Checked, checkBox6.Checked);
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
            truePhysics = new TruePhysics(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), physics.GetRightWeight());
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6),
                checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked, checkBox5.Checked, checkBox6.Checked);
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
            truePhysics = new TruePhysics(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), physics.GetRightWeight());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AboutBox1().Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                MessageBox.Show("Adefe ninekeem ARM\r\nbeyond expectations\r\nvk.com/adefe vk.com/ninekeem", "Авторы", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}