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

        public PictureBox pictureBox;

        public Brush Brush
        {
            get { return brush; }
            set { brush = value; }
        }

        public ShapesDrawer(Graphics graphics, PictureBox pb)
        {
            this.graphics = graphics;
            pen = new Pen(Color.Black);
            this.brush = new SolidBrush(Color.Black);
            this.pictureBox = pb;
        }

        public void DrawLine(Pen pen, Point start, Point end)
        {
            Graphics.FromImage(pictureBox.Image).DrawLine(pen, start, end); 
        }

        public void DrawPolygon(Pen pen, List<Point> points)
        {
            Graphics.FromImage(pictureBox.Image).DrawPolygon(pen, points.ToArray());
        }

        public void DrawEllipse(Pen pen, Point start, int a, int b)
        {
            Graphics.FromImage(pictureBox.Image).DrawEllipse(pen, start.X, start.Y, a, b);
        }

    }
}
