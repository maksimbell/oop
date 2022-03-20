using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Drawer
{
    public class ShapeCreator
    {
        public ShapeCreator()
        {

        }
        
        public Shape CreateShape(string type, Point start)
        {

           /* Line
            Square
            Rectangle
            Triangle
            Circle
            Ellipse*/

            switch (type)
            {
                case "Line":
                    return new Line(start, start);
                case "Square":
                    return new Square(new List<Point> { start, start, start, start });
                case "Rectangle":
                    return new Rect(new List<Point> { start, start, start, start });
                case "Triangle":
                    return new Triangle(new List<Point> { start, start, start});
                case "Circle":
                    return new Circle(start, 0);
                case "Ellipse":
                    return new Ellipse(start, 0, 0);
                default:
                    return null;
            }
        }

    }
}
