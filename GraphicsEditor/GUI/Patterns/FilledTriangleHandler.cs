using GUI.Drawer;
using GUI.ShapeHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Patterns
{
    public class FilledTriangleHandler : ShapeCreateHandler
    {
        public override Shape CreateShape(Point point, Pen pen)
        {
            return new FilledTriangleAdapter(new List<Point> { point, point, point }, pen);
        }
    }
}
