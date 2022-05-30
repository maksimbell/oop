using System.Drawing;

namespace GUI.Drawer
{
    [Serializable]
    public class Ellipse:Shape
    {
        public int a, b;

        public Ellipse() : base() { }
        public Ellipse(Point center, int a, int b, Pen pen)
        {
            this.StartPoint = center;
            this.a = a;
            this.b = b;

            PenState = new PenState();
            PenState.Width = pen.Width;
            PenState.Color = pen.Color;
            PenState.RGB = PenState.Color.ToArgb();
            Pen = (Pen)pen.Clone();
        }

        public override float CalculateSquare()
        {
            return (float)(Math.PI * a * b);
        }

        public override void Draw(ShapesDrawer sd)
        {
            sd.DrawEllipse(Pen, StartPoint, a, b);
        }

        public override void Resize(Point rp)
        {
            a = ShapeCalculator.GetXDistance(rp, StartPoint);
            b = ShapeCalculator.GetYDistance(rp, StartPoint);
           
        }
    }
}
