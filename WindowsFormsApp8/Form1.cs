using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        internal float g;
        internal bool laser;
        internal object bc;
        private object nlo;
        private Bitmap imageP;
        private object player;
        private object rec;
        private object e;

        public Form1()
        {
            InitializeComponent();
        }

        public static int N_max { get; internal set; }
        public int Result { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            nlo.k_generation = 0;
            nlo.Enemy(this);
            nlo.Ally(this);
            timer1.Start();
            timer2.Start();
            button3.Enabled = true;
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (laser)
            {
                laser = false;
                button2.Text = "Включить Лазер";
            }
            else
            {
                laser = true;
                button2.Text = "Отключить Лазер";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            imageP = new Bitmap(imageList1.Images[1], 100, 100);
            int procent = Result * 100 / (nlo.Delta_N * nlo.N_generation);
            string msg = "Подбито " + Result.ToString() + " НЛО, " + procent.ToString() + "% результат";
            MessageBox.Show(msg, "Ваш результат", MessageBoxButtons.OK);
            player.Show_player(this, 50, 50, player.GetReg(), rec);
            nlo.N = 0;
            button1.Enabled = true;
            Result = 0;
            textBox1.Text = Result.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(BackColor);
            Result = Result + nlo.Select_bugs();
            nlo.Show_bugs(this);
            textBox1.Text = Result.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            nlo.k_generation++;
            timer2.Interval -= 100;
            if (nlo.k_generation < nlo.N_generation)
                nlo.Enemy(this);
        }
        private void Form1_MouseClick(object sender, EventArgs e)
        {
            _ = player.Show_player(
                this.e.X,
                this.e.Y,
                reg: player.GetReg(),
                rec: rec);
            if (laser)
                g.DrawLine(player.laser_pen, player.point.X + player.size.Width / 2, player.point.Y, player.point.X + player.size.Width / 2, 0);
            _ = nlo.Killed_bugs(this.e.X, this.e.Y);
        }

        public override bool Equals(object obj)
        {
            return obj is Form1 form &&
                   EqualityComparer<Player>.Default.Equals(player, form.player);
        }
    }
}
