using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle:Shape
    {
        int radius;
        public override void Draw()
        {

        }
        public override float CalculateSquare()
        {
            return (float)(Math.PI * radius * radius);
        }

        public Circle(Point center, int radius)
        {
            this.startPoint = center;
            this.radius = radius;
        }
    }
}
