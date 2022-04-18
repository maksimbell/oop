using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Drawer
{
    [Serializable]
    public class Square:Shape
    {
        public int width;
        public List<Point> points = new();
        
        public Square(List<Point> points, Pen pen)
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
            return width * width;
        }

        public override void Draw(ShapesDrawer sd)
        {
            sd.DrawPolygon(Pen, points);
        }

        public override void Resize(Point rp)
        {

            points[1] = new Point(points[0].X + ShapeCalculator.GetXDistance(rp, points[0]), points[0].Y);
            points[3] = new Point(points[0].X, points[0].Y + ShapeCalculator.GetXDistance(rp, points[0]));
            points[2] = new Point(points[0].X + ShapeCalculator.GetXDistance(rp, points[0]), points[0].Y + ShapeCalculator.GetXDistance(rp, points[0]));

        }
    }
}
