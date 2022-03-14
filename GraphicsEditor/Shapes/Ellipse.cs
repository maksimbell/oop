using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Ellipse:Shape
    {
        int a, b;
        public override void Draw()
        {

        }
        public override float CalculateSquare()
        {
            return (float)(Math.PI * a * b);
        }

        public Ellipse(Point center, int a, int b)
        {
            this.startPoint = center;
            this.a = a;
            this.b = b;
        }
    }
}
