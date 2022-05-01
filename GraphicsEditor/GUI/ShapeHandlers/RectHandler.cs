using GUI.Drawer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ShapeHandlers
{
    public class RectHandler : ShapeCreateHandler
    {
        public override Shape CreateShape(Point point, Pen pen)
        {
            return new Rect(new List<Point> { point, point, point, point }, pen);
        }
    }
}
