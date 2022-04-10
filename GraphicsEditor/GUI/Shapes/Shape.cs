using System.Drawing;


namespace GUI.Drawer
{
    public abstract class Shape: IDrawable, IResizeable
    {
        private Point startPoint;

        private Pen pen;

        public Point StartPoint
        {
            get { return startPoint; } 
            set { startPoint = value; }
        }

        public Pen Pen
        {
            get { return pen; } 
            set { pen = value; }
        }

        public abstract float CalculateSquare();

        public abstract void Draw(ShapesDrawer sd);

        public abstract void Resize(Point rp);
    }
}