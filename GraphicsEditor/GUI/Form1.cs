using GUI.Drawer;

namespace GUI
{
    public partial class GraphicsForm : Form
    {
        public GraphicsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = canvas.CreateGraphics();
            ShapesDrawer sd = new ShapesDrawer(graphics);

            Shape line = new Line(new Point(100, 100), new Point(400, 100));
            Shape triangle = new Triangle(new List<Point>() { new Point(100, 100), new Point(100, 200), new Point(200, 100) });
            Shape circle = new Circle(new Point(100, 100), 40);
            Shape ellipse = new Ellipse(new Point(100, 100), 50, 70);
            Shape square = new Square(new List<Point>() { new Point(0, 0),  new Point(100, 0), new Point(100, 100), new Point(0, 100) });
            Shape rect = new Square(new List<Point>() { new Point(110, 50), new Point(110, 150), new Point(60, 150), new Point(60, 50) });

            line.Draw(sd);
            /*triangle.Draw(sd);*/
            /*circle.Draw(sd);*/
            ellipse.Draw(sd);
            square.Draw(sd);
            rect.Draw(sd);
        }
    }
}