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
            physics = new Physics(ref pictureBox1, timer1.Interval, ((double)pictureBox1.Height * 23 / 3620)); //перевод в сантиметры линейки
            label3.Text = physics.GetRightWeight().ToString() + "кг";
            label10.Text = Math.Round(physics.GetLeftWeight(), 2).ToString() + "кг";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            physics.ProcessPhysics();
            label5.Text = Math.Round(physics.GetRightVelocity(), 2).ToString();
            label7.Text = Math.Round(physics.GetRightCoord(), 2).ToString();
            label14.Text = physics.GetTime().ToString() + "сек";
        }

        private void button1_click(object sender, EventArgs e)
        {
            // Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            physics.SetLengths(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3), checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
            physics.StartMovement(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));

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
    }
}
/* 
 Надо сделать:
1. Убрать мерцание (полностью переписать графику, если требуется)
2. Полностью разработать реализацию stopCoord препятствия и взаимодействия с ползунком прокрутки
3. Разработать UI
4. Заменить физические координаты на фактические и наоборот где надо
5. Наконец то ввести нормальный физический движок
 */