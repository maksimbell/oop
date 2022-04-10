namespace GUI.Drawer
{
    public class ShapesDrawer
    {
        
        private Graphics graphics;

        /*private Pen pen;*/

        /* public Pen Pen
         {
             get { return pen; }
             set { pen = value; }
         }*/

        private Brush brush;

        public Brush Brush
        {
            get { return brush; }
            set { brush = value; }
        }

        public ShapesDrawer(Graphics graphics)
        {
            this.graphics = graphics;
            /*pen = new Pen(Color.Black);*/
            this.brush = new SolidBrush(Color.Black);
        }

        public void DrawLine(Point start, Point end, Pen pen)
        {

            graphics.DrawLine(pen, start, end); 
        }

        public void DrawPolygon(List<Point> points, Pen pen)
        {
            graphics.DrawPolygon(pen, points.ToArray());
        }

        public void DrawEllipse(Point start, int a, int b, Pen pen)
        {
            graphics.DrawEllipse(pen, start.X, start.Y, a, b);
        }

    }
}
