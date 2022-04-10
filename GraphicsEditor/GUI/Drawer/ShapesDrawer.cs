namespace GUI.Drawer
{
    public class ShapesDrawer
    {
        
        private Graphics graphics;

        private Pen pen;
        
        private Brush brush;

        public Pen Pen
        {
            get { return pen; }
            set { pen = value; }
        }

        public Brush Brush
        {
            get { return brush; }
            set { brush = value; }
        }

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
            graphics.DrawPolygon(pen, points.ToArray());
        }

        public void DrawEllipse(Point start, int a, int b)
        {
            graphics.DrawEllipse(pen, start.X, start.Y, a, b);
        }

    }
}
