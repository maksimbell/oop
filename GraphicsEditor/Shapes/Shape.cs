using System.Drawing;

namespace Shapes
{
    public abstract class Shape
    {
        public Point startPoint;
        public abstract void Draw();
        public abstract float CalculateSquare();
    }
}