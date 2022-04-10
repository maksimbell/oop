using System.Drawing;

namespace GUI.Drawer
{
    public class Ellipse:Shape
    {
        int a, b;

        public Ellipse(Point center, int a, int b)
        {
            this.StartPoint = center;
            this.a = a;
            this.b = b;
            Pen = new Pen(Color.Black);
        }

        public override float CalculateSquare()
        {
            return (float)(Math.PI * a * b);
        }

        public override void Draw(ShapesDrawer sd)
        {
            sd.DrawEllipse(StartPoint, a, b, Pen);
        }

        public override void Resize(Point rp)
        {
            a = ShapeCalculator.GetXDistance(rp, StartPoint);
            b = ShapeCalculator.GetYDistance(rp, StartPoint);
           
        }
    }
}
