namespace GUI.Drawer
{
    public class ShapesDrawer
    {
        
        private Graphics graphics;

        private Pen pen;
        
        private Brush brush;

        public ShapesDrawer(Graphics graphics)
        {
            this.graphics = graphics;
            pen = new Pen(Color.Black);
            this.brush = new SolidBrush(Color.Black);
        }

        public void DrawLine(Point start, Point end)
        {
            graphics.DrawLine(pen, start, end);
        }

        public void DrawPolygon(List<Point> points)
        {
            graphics.FillPolygon(brush, points.ToArray());
        }

        public void DrawEllipse(Point start, int a, int b)
        {
            graphics.FillEllipse(brush, start.X, start.Y, a, b);
        }



    }
}
