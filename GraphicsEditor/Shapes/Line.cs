using System.Drawing;

namespace Shapes
{
    public class Line:Shape
    {
        public Point endPoint;
        public override void Draw()
        {
                
        }
        public override float CalculateSquare()
        {
            return 0;
        }
        public Line(Point start, Point end)
        {
            this.startPoint = start;
            this.endPoint = end;
        }
    }
}
