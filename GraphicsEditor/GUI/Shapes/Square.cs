using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Drawer
{
    public class Square:Shape
    {
        public int width;
        public List<Point> points = new();
        
        public Square(List<Point> points)
        {
            if (points.Count != 4)
            {
                throw new Exception("4 points expected.");
            }

            this.points = points;
        }

        public override float CalculateSquare()
        {
            return width * width;
        }

        public override void Draw(ShapesDrawer sd)
        {
            sd.DrawPolygon(points);
        }

        public override void Resize(Point rp)
        {

            points[3] = rp;
            points[1] = new Point(rp.X - points[0].X, rp.Y - points[0].Y);
            
        }
    }
}
