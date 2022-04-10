using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Drawer
{
    public class Rect:Shape
    {
        public int width,  height;
        public List<Point> points = new();

        public Rect(List<Point> points)
        {
            if (points.Count != 4)
            {
                throw new Exception("4 points expected.");
            }

            Pen = new Pen(Color.Black);
            this.points = points;
        }

        public override float CalculateSquare()
        {
            return width * height;
        }

        public override void Draw(ShapesDrawer sd)
        {
            sd.DrawPolygon(points, Pen);
        }

        public override void Resize(Point rp)
        {
            points[1] = new Point(rp.X, points[0].Y);
            points[3] = new Point(points[0].X, rp.Y);
            points[2] = rp;
        }

    }
}
