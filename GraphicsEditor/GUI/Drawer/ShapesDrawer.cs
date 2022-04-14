namespace GUI.Drawer
{
    public class ShapesDrawer
    {
        
        private Graphics graphics;

        private Pen pen;

        public Pen Pen
        {
            get { return pen; }
            set { pen = value; }
        }

        private Brush brush;

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

        public void DrawLine(Pen pen, Point start, Point end)
        {
            graphics.DrawLine(pen, start, end); 
        }

        public void DrawPolygon(Pen pen, List<Point> points)
        {
            graphics.DrawPolygon(pen, points.ToArray());
        }

        public void DrawEllipse(Pen pen, Point start, int a, int b)
        {
            graphics.DrawEllipse(pen, start.X, start.Y, a, b);
        }

    }
}
