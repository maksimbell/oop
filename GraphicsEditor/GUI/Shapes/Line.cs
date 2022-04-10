using System.Drawing;

namespace GUI.Drawer
{
    public class Line:Shape
    {
        public Point endPoint;

        public Line(Point start, Point end, Pen pen)
        {
            this.StartPoint = start;
            this.endPoint = end;
            Pen.Color = pen.Color;
        }

        public override float CalculateSquare()
        {
            return 0;
        }

        public override void Draw(ShapesDrawer sd)
        {
            sd.DrawLine(StartPoint, endPoint, Pen);
        }

        public override void Resize(Point rp)
        {
            endPoint = rp;
        }
    }
}
