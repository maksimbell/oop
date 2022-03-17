using GUI.Drawer;

namespace GUI
{
    public partial class GraphicsForm : Form
    {

        private List<Shape> staticShapes = new List<Shape>();

        private List<Shape> shapes;

        private Shape currentShape;

        //private ShapeType currentShapeType;
        
        private ShapesDrawer sd;

        public GraphicsForm()
        {
            InitializeComponent();
            InitializeStaticShapes();

            Graphics graphics = canvas.CreateGraphics();
            sd = new ShapesDrawer(graphics);

            cbShapesType.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void InitializeStaticShapes()
        {
            staticShapes = new List<Shape>
            {
                new Line(new Point(100, 50), new Point(500, 50)),
                new Triangle(new List<Point>() { new Point(100, 100),
                    new Point(50, 200), new Point(150, 200) }),
                new Circle(new Point(200, 150), 50),
                new Ellipse(new Point(300, 150), 90, 60),
                new Rect(new List<Point>() { new Point(100, 250),
                    new Point(100, 350), new Point(150, 350), new Point(150, 250) }),
                new Square(new List<Point>() { new Point(300, 250),
                    new Point(350, 250), new Point(350, 300), new Point(300, 300) })

            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
           foreach (var shape in staticShapes)
            {
                shape.Draw(sd);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            canvas.Image = null;
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void canvas_Click(object sender, EventArgs e)
        {

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}