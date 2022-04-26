using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Drawer
{
    public class ShapeCreateHandler
    {
        public static Shape CreateSquare(Point creationPoint, Pen pen)
        {
            return new Square(new List<Point> { creationPoint, creationPoint, creationPoint, creationPoint }, pen);
        }
        public static Shape CreateCircle(Point creationPoint, Pen pen)
        {
            return new Circle(creationPoint, 0, pen);
        }
        public static Shape CreateRectangle(Point creationPoint, Pen pen)
        {
            return new Rect(new List<Point> { creationPoint, creationPoint, creationPoint, creationPoint }, pen);
        }
        public static Shape CreateEllipse(Point creationPoint, Pen pen)
        {
            return new Ellipse(creationPoint, 0, 0, pen);
        }
        public static Shape CreateTriangle(Point creationPoint, Pen pen)
        {
            return new Triangle(new List<Point> { creationPoint, creationPoint, creationPoint }, pen);
        }
        public static Shape CreateLine(Point creationPoint, Pen pen)
        {
            return new Line(creationPoint, creationPoint, pen);
        }
    }
}
