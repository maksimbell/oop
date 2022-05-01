using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Drawer;

namespace GUI.ShapeHandlers
{
    public abstract class ShapeCreateHandler
    {
        public abstract Shape CreateShape(Point point, Pen pen);
    }
}
