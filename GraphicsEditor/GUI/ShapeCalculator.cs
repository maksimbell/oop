using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Drawer
{
    public static class ShapeCalculator
    {
        public static int GetXDistance(Point a, Point b)
        {
            return (a.X - b.X);
        }

        public static int GetYDistance(Point a, Point b)
        {
            return (a.Y - b.Y);
        }
    }
}
