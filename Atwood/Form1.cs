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
            label3.Text = physics.GetRightWeight().ToString() + "кг";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            physics.ProcessPhysics();
            label5.Text = Math.Round(physics.GetRightVelocity(), 2).ToString();
            label7.Text = Math.Round(physics.GetRightCoord(), 2).ToString();
        }

        private void button1_click(object sender, EventArgs e)
        {
            physics.StartMovement(20);
            timer1.Enabled = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            physics = new Physics(ref pictureBox1, timer1.Interval, 10, pictureBox1.Width, pictureBox1.Height);
            label3.Text = physics.GetRightWeight().ToString() + "кг";
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
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3));
            label3.Text = physics.GetRightWeight().ToString() + "кг";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3));
            label3.Text = physics.GetRightWeight().ToString()+"кг";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            physics.SetRightWeight(CheckAdd(checkBox1, checkBox2, checkBox3));
            label3.Text = physics.GetRightWeight().ToString()+"кг";
        }
    }
}
/* 
 Надо сделать:
1. Убрать мерцание (полностью переписать графику)
2. Все абмлютные значения переписать в пропорции, если еще не сделано
3. В частности stopCoord
4. Полностью разработать реализацию stopCoord препятствия и взаимодействия с ползунком прокрутки
5. Разработать UI6
6. Заменить физические координаты на фактические и наоборот где надо
7. Наконец то ввести нормальный физический движок
 */