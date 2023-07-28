using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using SolrNet.Utils;

namespace WindowsFormsApp8
{
    internal class Bugs : BugsBase
    {
        public Point point;
        public Size size;
        int veloX;
        int veloY;
        public HatchBrush br;
        public Region reg = new Region();
        public Boolean life = true;
        private object pt;

        public void New_bug(Form1 F, int rch)
        {
            Random rv = new Random(rch);
            point.X = rv.Next(10, Form1.ActiveForm.Width - 40);
            point.Y = rv.Next(10, Form1.ActiveForm.Height / 5);
            size.Width = rv.Next(20, 50);
            size.Height = size.Width * 2 / 3;
            veloX = rv.Next(7) - 3;
            veloY = rv.Next(3, 10);
            br = F.bc.New_br(rch);
            reg = Form_bug(pt, point: new Point());
        }
        void F.bc.New_br(rch);

        public void Move_bug()
        {
            point.X += veloX;
            point.Y += veloY;
            reg = Form_bug(pt, point: new Point());
        }

        private Region Form_bug(object pt, Point point)
        {
            throw new NotImplementedException();
        }
    }
}
