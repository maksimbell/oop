using GUI.Drawer;
using GUI.ShapeHandlers;
using System.Drawing;

namespace ShapePlugins
{
    public class RightTriangleHandler : ShapeCreateHandler
    {
        public override Shape CreateShape(Point point, Pen pen)
        {
            return new RightTriangle(new List<Point> { point, point, point }, pen);
        }
    }
}
