using System.Drawing;

namespace GUI.Drawer
{
    public class Ellipse:Shape
    {
        int a, b;

        public Ellipse(Point center, int a, int b)
        {
            this.startPoint = center;
            this.a = a;
            this.b = b;
        }

        public override float CalculateSquare()
        {
            return (float)(Math.PI * a * b);
        }

        public override void Draw(ShapesDrawer sd)
        {
            sd.DrawEllipse(startPoint, a, b);
        }

        public override void Resize(Point rp)
        {
            a = ShapeCalculator.GetXDistance(rp, startPoint);
            b = ShapeCalculator.GetYDistance(rp, startPoint);
           
        }
    }
}
