using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    internal class Allies
    {
        public int Delta_N;
        public int N_generation;
        public int k_generation;
        public int N;

        public Bugs[] bugs = new Bugs[Form1.N_max];

        public int N_max;
        public int k_max;
        public int k;

        public void New_Allies()
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
        public void Ally1(Form1 F)
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
                F.g.FillRegion(bugs[j].br, bugs[j].reg);
            }
        }
        public void Ally2(Form1 F)
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
        public void Ally3(Form1 F)
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
                F.g.FillRegion(bugs[j].br, bugs[j].reg);
            }
        }
    }
}
