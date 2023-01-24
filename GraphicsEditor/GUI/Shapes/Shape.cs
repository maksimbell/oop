using System.Drawing;
using System.Xml.Serialization;
using GUI;
using GUI.Drawer;

namespace GUI.Drawer
{
    [XmlInclude(typeof(PenState)), XmlInclude(typeof(Color)), XmlInclude(typeof(Line)), 
        XmlInclude(typeof(Rect)), XmlInclude(typeof(Circle)),
        XmlInclude(typeof(Ellipse)), XmlInclude(typeof(Triangle)), XmlInclude(typeof(Square)), 
        XmlInclude(typeof(ShapePlugins.Rhombus)), XmlInclude(typeof(ShapePlugins.RightTriangle))]
    [Serializable]
    public abstract class Shape: IDrawable, IResizeable, IClownable
    {
        private Point startPoint;

        private PenState penState;

        [XmlIgnore, NonSerialized]
        public Pen Pen;

        public Point StartPoint
        {
            get { return startPoint; } 
            set { startPoint = value; }
        }
        public PenState PenState
        {
            get { return penState; }
            set { penState = value; }
        }

        /*public Pen Pen
        {
            get { return pen; } 
            set { pen = value; }
        }*/

        public abstract float CalculateSquare();

        public abstract void Draw(ShapesDrawer sd);

        public abstract void Resize(Point rp);

        public abstract Shape Clone();
    }
}