using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Drawer
{
    public class ShapeCreator
    {
        private Dictionary<string, Func<Point, Pen, Shape>> shapeCreateHandlers = new Dictionary<string, Func<Point, Pen, Shape>>();
        public ShapeCreator()
        {
            shapeCreateHandlers = new Dictionary<string, Func<Point, Pen, Shape>> {
                { "Square", ShapeCreateHandler.CreateSquare },
                { "Circle", ShapeCreateHandler.CreateCircle },
                { "Rectangle", ShapeCreateHandler.CreateRectangle },
                { "Ellipse", ShapeCreateHandler.CreateEllipse },
                { "Triangle", ShapeCreateHandler.CreateTriangle },
                { "Line", ShapeCreateHandler.CreateLine }
            };
        }

        public Shape CreateShape(string type, Point start, Pen pen)
        {
            return shapeCreateHandlers[type](start, pen);
        }

    }
}
