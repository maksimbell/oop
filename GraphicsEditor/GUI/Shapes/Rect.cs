using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Drawer
{
    [Serializable]
    public class Rect:Shape
    {
        public int width,  height;
        public List<Point> points = new();

        public Rect(List<Point> points, Pen pen)
        {
            if (points.Count != 4)
            {
                throw new Exception("4 points expected.");
            }

            PenState = new PenState();
            PenState.Width = pen.Width;
            PenState.Color = pen.Color;
            Pen = (Pen)pen.Clone();
            this.points = points;
        }

        public override float CalculateSquare()
        {
            return width * height;
        }

        public override void Draw(ShapesDrawer sd)
        {
            sd.DrawPolygon(Pen, points);
        }

        public override void Resize(Point rp)
        {
            points[1] = new Point(rp.X, points[0].Y);
            points[3] = new Point(points[0].X, rp.Y);
            points[2] = rp;
        }

    }
}
