using GUI.ShapeHandlers;

namespace GUI
{
    public class ShapeTypeHandler
    {
        public Dictionary<string, ShapeCreateHandler> shapeCreateHandlers;
        public ShapeTypeHandler(List<Type> shapePlugins, List<Type> shapeHandlerPlugins)
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

            // add plugins here
            for (int i = 0; i < shapePlugins.Count; i++)
            {
                shapeCreateHandlers[shapePlugins[i].Name] =
                    Activator.CreateInstance(shapeHandlerPlugins[i]) as ShapeCreateHandler;
            }
        }

        public ShapeCreateHandler getHandler(string currentShape)
        {
            return shapeCreateHandlers[currentShape];
        }
    }
}
