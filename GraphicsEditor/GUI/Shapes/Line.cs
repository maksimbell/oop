using System.Drawing;
using System.Xml.Serialization;

namespace GUI.Drawer
{
    [Serializable]
    public class Line:Shape
    {
        public Point endPoint;

        public Line():base(){}
        public Line(Point start, Point end, Pen pen)
        {
            this.StartPoint = start;
            this.endPoint = end;

            PenState = new PenState();
            PenState.Width = pen.Width;
            PenState.Color = pen.Color;
            PenState.RGB = PenState.Color.ToArgb();
            Pen = (Pen)pen.Clone();
        }

        public override float CalculateSquare()
        {
            return 0;
        }

        public override void Draw(ShapesDrawer sd)
        {
            Image img = new Bitmap(100, 100);
            sd.DrawLine(Pen, StartPoint, endPoint);
        }

        public override void Resize(Point rp)
        {
            endPoint = rp;
        }

        public override Shape Clone()
        {
            return (Shape)this.MemberwiseClone();
        }
    }
}
