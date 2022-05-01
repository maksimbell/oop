using GUI;
using GUI.Drawer;
using GUI.Interfaces;
using System.Drawing;

namespace ShapePlugins
{
    [Serializable]
    public class Rhombus : Shape
    {
        public int width;
        public List<Point> points = new();

        public Rhombus(List<Point> points, Pen pen)
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

        public string Activate(string text)
        {
            throw new NotImplementedException();
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
            //points[0] = new Point(points[0].X, points[0].Y + ShapeCalculator.GetYDistance(points[0], rp));
            points[1] = new Point(points[0].X + ShapeCalculator.GetXDistance(rp, points[0]), (points[0].Y + rp.Y)/2);
            points[2] = new Point(points[0].X, rp.Y);
            points[3] = new Point(points[0].X - ShapeCalculator.GetXDistance(rp, points[0]), (points[0].Y + rp.Y) / 2);

        }
    }
}