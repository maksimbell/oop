using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle:Shape
    {
        public int width,  height;
        public List<Point> points = new();

        public override void Draw()
        {

        }

        public override float CalculateSquare()
        {
            return width * height;
        }

        public Rectangle(List<Point> points)
        {
            if (points.Count != 4)
            {
                throw new Exception("4 points expected.");
            }

            this.points = points;
        }

    }
}
