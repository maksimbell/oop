﻿using System.Drawing;

namespace GUI.Drawer
{
    public class Line:Shape
    {
        public Point endPoint;

        public Line(Point start, Point end)
        {
            this.startPoint = start;
            this.endPoint = end;
        }

        public override float CalculateSquare()
        {
            return 0;
        }

        public override void Draw(ShapesDrawer sd)
        {
            sd.DrawLine(startPoint, endPoint);
        }

        public override void Resize(Point rp)
        {
            endPoint = rp;
        }
    }
}
