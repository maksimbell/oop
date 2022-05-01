using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Drawer;
using GUI.ShapeHandlers;

namespace GUI.ShapeCreators
{
    
    public class ShapeCreator
    {
        public Dictionary<string, ShapeCreateHandler> shapeCreateHandlers;
        public ShapeCreator(List<Type> shapePlugins, List<Type> shapeHandlerPlugins)
        {
            shapeCreateHandlers =
            new Dictionary<string, ShapeCreateHandler> {
                {"Line", new LineHandler() },
                {"Rectangle", new RectHandler() },
                {"Square", new SquareHandler() },
                {"Circle", new CircleHandler() },
                {"Ellipse", new EllipseHandler() },
                {"Triangle", new TriangleHandler() },
            };

            //add plugins here
            for(int i = 0; i < shapePlugins.Count; i++)
            {
                shapeCreateHandlers[shapePlugins[i].Name] =
                    (ShapeCreateHandler)Activator.CreateInstance(shapeHandlerPlugins[i]);
            }
        }

        public Shape GetShape(string currentShape, Point point, Pen pen)
        {
            return shapeCreateHandlers[currentShape].CreateShape(point, pen);
        }

    }
}
