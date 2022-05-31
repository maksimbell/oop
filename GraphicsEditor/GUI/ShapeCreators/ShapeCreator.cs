using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI;
using GUI.Drawer;
using GUI.ShapeHandlers;

namespace GUI.ShapeCreators
{
    
    public class ShapeCreator
    {
        private ShapeTypeHandler shapeTypeHandler;
        public ShapeCreator(string currentShape, List<Type> shapePlugins, List<Type> shapeHandlerPlugins)
        {
            shapeTypeHandler = new ShapeTypeHandler(shapePlugins, shapeHandlerPlugins);
        }

        public Shape GetShape(string currentShape, Point point, Pen pen)
        {
            Shape shape = shapeTypeHandler.getHandler(currentShape).CreateShape(point, pen);
            return shape;
        }

    }
}
