using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Drawer
{
    public class Circle:Shape
    {
        int radius;
       
        public Circle(Point center, int radius)
        {
            this.startPoint = center;
            this.radius = radius;
        }

        public override float CalculateSquare()
        {
            return (float)(Math.PI * radius * radius);
        }

        public override void Draw(ShapesDrawer sd)
        {
            sd.DrawEllipse(startPoint, radius, radius);
        }

        public override void Resize(Point rp)
        {
            /*int x = ShapeCalculator.GetXDistance(startPoint, rp);
            int y = ShapeCalculator.GetYDistance(startPoint, rp);
            radius = (int)Math.Sqrt(x*x+y*y);*/

            radius = ShapeCalculator.GetXDistance(rp, startPoint);
        }
    }
}
