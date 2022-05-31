using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Drawer;
using BaseFigure;
using FilledCircle;
using FilledTriangle;

namespace GUI.Patterns
{
    [Serializable]
    public class FilledTriangleAdapter : Shape
    {
        [NonSerialized]
        Figure figure;
        public FilledTriangleAdapter(List<Point> points, Pen pen)
        {
            figure = new FilledTriangle.FilledTriangle();
            figure.Points = points;

            PenState = new PenState();
            PenState.Width = pen.Width;
            PenState.Color = pen.Color;
            PenState.RGB = PenState.Color.ToArgb();
            Pen = (Pen)pen.Clone();

            figure.PenWidth = (int)pen.Width;
            figure.R = PenState.Color.R;
            figure.G = PenState.Color.G;
            figure.B = PenState.Color.B;
        }
        public override float CalculateSquare()
        {
            throw new NotImplementedException();
        }

        public override void Draw(ShapesDrawer sd)
        {
            figure.Draw(sd.pictureBox.Image);
        }

        public override void Resize(Point rp)
        {
            figure.Points[2] = new Point(rp.X, rp.Y);
            figure.Points[1] = new Point(rp.X - 2 * ShapeCalculator.GetXDistance(rp, figure.Points[0]), rp.Y);
        }
    }
}
