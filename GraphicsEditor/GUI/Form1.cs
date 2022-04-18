using GUI.Drawer;
using GUI.Serializer;

namespace GUI
{
    public partial class GraphicsForm : Form
    {

        private List<Shape> staticShapes;

        private List<Shape> shapes = new List<Shape>();

        private Shape currentShape = null;

        private ShapeCreator shapeCreator = new ShapeCreator();

        //private ShapeType currentShapeType;

        private ShapesDrawer sd;

        private Pen canvasPen = new Pen(Color.Black);

        private List<int> selectedShapes = new List<int>();

        private CustomBinarySerializer<Shape> serializer;

        public GraphicsForm()
        {
            InitializeComponent();
            InitializeStaticShapes();

            Graphics graphics = canvas.CreateGraphics();
            sd = new ShapesDrawer(graphics);
            serializer = new CustomBinarySerializer<Shape>();

            cbShapesType.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void InitializeStaticShapes()
        {
            staticShapes = new List<Shape>
            {
                new Line(new Point(100, 50), new Point(500, 50), canvasPen),
                new Triangle(new List<Point>() { new Point(100, 100),
                    new Point(50, 200), new Point(150, 200) }, canvasPen),
                new Circle(new Point(200, 150), 50, canvasPen),
                new Ellipse(new Point(300, 150), 90, 60, canvasPen),
                new Rect(new List<Point>() { new Point(100, 250),
                    new Point(100, 350), new Point(150, 350), new Point(150, 250) }, canvasPen),
                new Square(new List<Point>() { new Point(300, 250),
                    new Point(350, 250), new Point(350, 300), new Point(300, 300) }, canvasPen)

            };
        }

        private void DrawShapesCanvas()
        {
            foreach (Shape shape in shapes)
            {
                shape.Draw(sd);
            }
        }

        private void ChangeSelectedShapes()
        {
            foreach (int index in selectedShapes)
            {
                shapes[index].Pen = (Pen)canvasPen.Clone();
                shapes[index].Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
        }

        private void UpdatePen()
        {
            canvasPen.Width = tbWidth.Value;
            canvasPen.Color = shapesColorDialog.Color;
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
            if (selectedShapes.Count > 0)
            {
                for(int i = selectedShapes.Count - 1; i > -1; i--)
                {
                    shapes.RemoveAt(selectedShapes[i]);
                    lbShapes.Items.RemoveAt(selectedShapes[i]);
                }
            }
            else
            {
                lbShapes.Items.Clear();
                shapes.Clear();
            }

            Refresh();
            DrawShapesCanvas();
            selectedShapes.Clear();
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            currentShape = shapeCreator.CreateShape(cbShapesType.Text, new Point(e.X, e.Y), canvasPen);
        }

        private void canvas_Click(object sender, EventArgs e)
        {

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentShape.Resize(new Point(e.X, e.Y));
                Refresh();
                DrawShapesCanvas();
                currentShape.Draw(sd);
            }
        }

        private void canvas_Move(object sender, EventArgs e)
        {

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentShape != null) shapes.Add(this.currentShape);
            lbShapes.Items.Add(currentShape.ToString().Replace("GUI.Drawer.","")) ;

            currentShape = null;

        }

        private void btnColorChange_Click(object sender, EventArgs e)
        {
            if (shapesColorDialog.ShowDialog() == DialogResult.Cancel)
                return;

            btnColorChange.BackColor = shapesColorDialog.Color;

            UpdatePen();
            ChangeSelectedShapes();

            Refresh();
            DrawShapesCanvas();
        }

        private void lbShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedShapes.Clear();
            for(int i = 0; i < lbShapes.SelectedIndices.Count; i++)
            {
                selectedShapes.Add(lbShapes.SelectedIndices[i]);
            }

            for (int i = 0; i < shapes.Count; i++)
            {
                shapes[i].Pen.DashStyle = selectedShapes.IndexOf(i) > -1 ? 
                    System.Drawing.Drawing2D.DashStyle.Dash :
                    System.Drawing.Drawing2D.DashStyle.Solid;
            }

            Refresh();
            DrawShapesCanvas();
        }

        private void tbWidth_Scroll(object sender, EventArgs e)
        {
            UpdatePen();
            ChangeSelectedShapes();

            Refresh();
            DrawShapesCanvas();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;

            serializer.Serialize(shapes[0], filename);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;

            Shape s = serializer.Deserialize(filename);
        }
    }
}