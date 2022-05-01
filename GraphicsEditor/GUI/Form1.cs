using GUI.Drawer;
using GUI.Serializer;
using GUI.PluginHandler;
using GUI.ShapeCreators;

namespace GUI
{
    public partial class GraphicsForm : Form
    {
        private string pluginsPath = "C:/Users/maksimbell/bsuir/4sem/oop/labs/GraphicsEditor/GUI/Plugins/ShapePlugins/bin/Debug/net6.0";

        private List<Shape> staticShapes;

        private List<Shape> shapes = new List<Shape>();

        private Shape currentShape = null;

        private ShapeCreator shapeCreator = null;

        private ShapesDrawer sd;

        private Pen canvasPen = new Pen(Color.Black);

        private List<int> selectedShapes = new List<int>();

        private CustomBinarySerializer<Shape> serializer;

        private PluginLoader loader = null;

        private List<Type> plugins = new List<Type>();
        private List<Type> shapePlugins = new List<Type>();
        private List<Type> shapeHandlerPlugins = new List<Type>();

        public GraphicsForm()
        {
            InitializeComponent();
            InitializeStaticShapes();

            LoadPlugins();

            shapeCreator = new ShapeCreator(shapePlugins, shapeHandlerPlugins);
            
            //List<Point> list = new List<Point>() { new Point(100, 250),
            //       new Point(100, 350), new Point(150, 350), new Point(150, 250) };

            //Type type = loader.plugins[0];
            //var instance = Activator.CreateInstance(type, (List<Point>)list, (Pen)canvasPen);

            Graphics graphics = canvas.CreateGraphics();
            sd = new ShapesDrawer(graphics);
            serializer = new CustomBinarySerializer<Shape>();

            cbShapesType.SelectedIndex = 0;
        }  
        
        private void LoadPlugins()
        {
            loader = new PluginLoader(pluginsPath);
            plugins = loader.Load("ShapePlugins");

            foreach (var plugin in plugins)
            {
                if (plugin.FullName.Contains("Handler")){
                    shapeHandlerPlugins.Add(plugin);
                }
                else
                {
                    shapePlugins.Add(plugin);
                    cbShapesType.Items.Add(plugin.Name);
                }
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var shape in staticShapes)
            {
                shape.Draw(sd);
            }

            btnClear.Enabled = true;   
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

            btnClear.Enabled = false;
            Refresh();
            DrawShapesCanvas();
            selectedShapes.Clear();
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            currentShape = shapeCreator.GetShape(cbShapesType.Text, new Point(e.X, e.Y), canvasPen);
        }

        private void canvas_Click(object sender, EventArgs e)
        {
            //ShapeCreator = new SC()
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

        private void AddCurrentShape()
        {
            shapes.Add(this.currentShape);
            lbShapes.Items.Add(currentShape.ToString().Split(".")[^1]);
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentShape != null) 
            AddCurrentShape();

            currentShape = null; 
            btnClear.Enabled = true;

        }

        private void btnColorChange_Click(object sender, EventArgs e)
        {
            if (shapesColorDialog.ShowDialog() == DialogResult.Cancel)
                return;

            btnColorChange.BackColor = shapesColorDialog.Color;

            canvasPen.Color = shapesColorDialog.Color;
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

            btnSave.Enabled = selectedShapes.Count == 1 ? true : false;

            Refresh();
            DrawShapesCanvas();
        }

        private void tbWidth_Scroll(object sender, EventArgs e)
        {
            canvasPen.Width = tbWidth.Value;
            ChangeSelectedShapes();

            Refresh();
            DrawShapesCanvas();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            serializer.Serialize(shapes[selectedShapes[0]], openFileDialog.FileName);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            currentShape = serializer.Deserialize(openFileDialog.FileName);

            currentShape.Pen = new Pen(currentShape.PenState.Color);
            currentShape.Pen.Width = currentShape.PenState.Width;

            AddCurrentShape();

            btnClear.Enabled = true;
            Refresh();
            DrawShapesCanvas();
        }

        private void cbShapesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //shapeCreator = new ShapeCreator(cbShapesType.Text, shapePlugins);
        }
    }
}