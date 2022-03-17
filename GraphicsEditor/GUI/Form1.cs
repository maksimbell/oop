using GUI.Drawer;

namespace GUI
{
    public partial class GraphicsForm : Form
    {

        private List<Shape> staticShapes;

        private ShapesDrawer sd;

        public GraphicsForm()
        {
            InitializeComponent();
            InitializeStaticShapes();

            Graphics graphics = canvas.CreateGraphics();
            sd = new ShapesDrawer(graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void InitializeStaticShapes()
        {
            staticShapes = new List<Shape>
            {
                new Line(new Point(100, 100), new Point(400, 100)),
                new Triangle(new List<Point>() { new Point(100, 100),
                    new Point(100, 200), new Point(200, 100) }),
                new Circle(new Point(100, 100), 40),
                new Ellipse(new Point(100, 100), 50, 70),
                new Square(new List<Point>() { new Point(0, 0),
                    new Point(100, 0), new Point(100, 100), new Point(0, 100) }),
                new Square(new List<Point>() { new Point(110, 50),
                    new Point(110, 150), new Point(60, 150), new Point(60, 50) })
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
           


            /*line.Draw(sd);
            triangle.Draw(sd);
            circle.Draw(sd);
            ellipse.Draw(sd);
            square.Draw(sd);
            rect.Draw(sd);*/
        }
    }
}