using System.Drawing;


namespace GUI.Drawer
{
    public abstract class Shape
    {
        public Point startPoint;
        public abstract void Draw(ShapesDrawer sd);
        public abstract float CalculateSquare();
    }
}