using System.Drawing;

namespace GUI.Drawer
{
    [Serializable]
    public class Line:Shape
    {
        public Point endPoint;

        public Line(Point start, Point end, Pen pen)
        {
            this.StartPoint = start;
            this.endPoint = end;
            Pen = (Pen)pen.Clone();
        }

        public override float CalculateSquare()
        {
            return 0;
        }

        public override void Draw(ShapesDrawer sd)
        {
            sd.DrawLine(Pen, StartPoint, endPoint);
        }

        public override void Resize(Point rp)
        {
            endPoint = rp;
        }
    }
}
