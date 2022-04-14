﻿using System.Drawing;

namespace GUI.Drawer
{
    public class Ellipse:Shape
    {
        int a, b;

        public Ellipse(Point center, int a, int b, Pen pen)
        {
            this.StartPoint = center;
            this.a = a;
            this.b = b;
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
