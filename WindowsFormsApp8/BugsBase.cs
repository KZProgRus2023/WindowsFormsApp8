using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp8
{
    internal class BugsBase
    {
        private object size;
        private object point;

        public Region Form_bug(Point pt, Point point)
        {
            Size st = new Size();
            point.X = point.X;
            Point point1 = new Point
            {
                Y = point.Y + (size.Height / 4)
            };
            st.Width = size.Width;
            st.Height = size.Height / 2;
            Rectangle rec = new Rectangle(new Point(), st);
            GraphicsPath path1 = new GraphicsPath();
            path1.AddEllipse(rec);
            Region reg = new Region(path1);
            rec.X = point.X + size.Width / 4;
            rec.Y = point.Y;
            rec.Width = size.Width / 2;
            rec.Height = size.Height;
            path1.AddEllipse(rec);
            reg.Union(path1);
            return reg;
        }
        public void Form_bug() { }
    }
}