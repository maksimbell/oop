using GUI;
using GUI.Drawer;
using GUI.Interfaces;
using System.Drawing;

namespace ShapePlugins
{
    [Serializable]
    public class RightTriangle : Shape
    {

        public List<Point> points = new();

        public RightTriangle() : base() { }
        public RightTriangle(List<Point> points, Pen pen)
        {
            if (points.Count != 3)
            {
                throw new Exception("3 points expected.");
            }

            PenState = new PenState();
            PenState.Width = pen.Width;
            PenState.Color = pen.Color;
            PenState.RGB = PenState.Color.ToArgb();
            Pen = (Pen)pen.Clone();
            this.points = points;
        }

        public override float CalculateSquare()
        {
            return 0;
        }

        public override void Draw(ShapesDrawer sd)
        {
            sd.DrawPolygon(Pen, points);
        }

        public override void Resize(Point rp)
        {
            points[2] = new Point(rp.X - ShapeCalculator.GetXDistance(rp, points[0]), rp.Y);
            points[1] = new Point(rp.X, rp.Y);
        }
    }
}
