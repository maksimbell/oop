using System.Drawing;


namespace GUI.Drawer
{
    public abstract class Shape: IDrawable, IResizeable
    {
        public Point startPoint;

        public abstract float CalculateSquare();

        public abstract void Draw(ShapesDrawer sd);

        public abstract void Resize(Point rp);
    }
}