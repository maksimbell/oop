﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle: Shape
    {

        public List<Point> points = new();
        public override void Draw()
        {

        }

        public override float CalculateSquare()
        {
            return 0;
        }

        public Triangle(List<Point> points)
        {
            if (points.Count != 3)
            {
                throw new Exception("3 points expected.");
            }

            this.points = points;
        }
    }
}
