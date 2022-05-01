using GUI.Drawer;
using GUI.ShapeHandlers;
using System.Drawing;

namespace ShapePlugins
{
    public class RombusHandler : ShapeCreateHandler
    {
        public override Shape CreateShape(Point point, Pen pen)
        {
            return new Rhombus(new List<Point> { point, point, point, point }, pen);
        }
    }
}
