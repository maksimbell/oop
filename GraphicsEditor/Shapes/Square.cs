using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square:Shape
    {
        public int width;
        public List<Point> points = new();
        public override void Draw()
        {

        }
        public override float CalculateSquare()
        {
            return width * width;
        }

        public Square(List<Point> points)
        {
            if (points.Count != 4)
            {
                throw new Exception("4 points expected.");
            }

            this.points = points;
        }
    }
}
