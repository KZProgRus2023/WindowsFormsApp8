using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    internal class Enemies
    {
        public int Delta_N;
        public int N_generation;
        public int k_generation;
        public int N;

        public Bugs[] bugs = new Bugs[Form1.N_max];

        public void New_Enemies()
        {
            N_generation = 10;
            Delta_N = Form1.N_max / N_generation;
            k_generation = 0;
            N = 0;
            for (int j = 0; j < Form1.N_max; j++)
                bugs[j] = new Bugs();
        }
        public void Show_bugs(Form1 F)
        {
            for (int j = 0; j < N; j++)
            {
                bugs[j].Move_bug();
                object value = F.g.FillRegion(bugs[j].br, bugs[j].reg);
            }
        }
        public void Enemy1(Form1 F)
        {
            int N0 = N;
            N = N + Delta_N;
            int rch;
            Random rnd = new Random();
            for (int j = N0; j < N; j++)
            {
                bugs[j] = new Bugs();
                rch = rnd.Next();
                bugs[j].New_bug(F, rch);
                HatchBrush br = bugs[j].br;
                object value = F.g.FillRegion(br, bugs[j].reg);
            }
        }
        public void Enemy2(Form1 F)
        {
            int N0 = N;
            N = N + Delta_N;
            int rch;
            Random rnd = new Random();
            for (int j = N0; j < N; j++)
            {
                bugs[j] = new Bugs();
                rch = rnd.Next();
                bugs[j].New_bug(F, rch);
                object value = F.g.FillRegion(bugs, bugs[j].reg);
            }
        }
        public void Enemy3(Form1 F)
        {
            int N0 = N;
            N = N + Delta_N;
            int rch;
            Random rnd = new Random();
            for (int j = N0; j < N; j++)
            {
                bugs[j] = new Bugs();
                rch = rnd.Next();
                bugs[j].New_bug(F, rch);
                object value = F.g.FillRegion(bugs[j].br, bugs[j].reg);
            }
        }
        public void Killed_bugs(Form1 F, int x, int y)
        {
            for (int j = 0; j < N; j++)
            {
                Rectangle r = new Rectangle(x - bugs[j].size.Width / 2, 0, bugs[j].size.Width, y);
                if (bugs[j].reg.IsVisible(r, F.g) & F.laser)
                {
                    bugs[j].br = new HatchBrush(HatchStyle.DarkHorizontal, F.bc.KilledBug, F.bc.KilledBug);
                    object value = F.g.FillRegion(bugs[j].br, bugs[j].reg);
                    bugs[j].life = false;
                }
            }
        }
        public int Select_bugs()
        {
            int k = 0;
            for (int j = 0; j < N; j++)
            {
                if (!bugs[j].life)
                    k++;
            }
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (!bugs[j].life)
                    {
                        for (int j1 = j; j1 < (N - 1); j1++)
                            bugs[j1] = bugs[j1 + 1];
                        break;
                    }
                }
                N--;
            }
            return k;    // счетчик подбитых НЛО
        }

        internal void Killed_bugs(Form1 form1, object x, object y)
        {
            throw new NotImplementedException();
        }

        internal void New_Enemies(Form1 form1)
        {
            throw new NotImplementedException();
        }
    }
}