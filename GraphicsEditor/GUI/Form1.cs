using GUI.Drawer;
using GUI.Serializer;
using GUI.PluginHandler;
using GUI.ShapeCreators;
using GUI.Patterns;
using BaseFigure;
using FilledCircle;
using FilledTriangle;

namespace GUI
{
    public partial class GraphicsForm : Form
    {
        private string pluginsPath = "C:/Users/maksimbell/bsuir/4sem/oop/labs/GraphicsEditor/GUI/Plugins/";

        private List<Shape> staticShapes;

        private List<Shape> shapes = new List<Shape>();

        private Shape currentShape = null;

        private ShapeCreator shapeCreator = null;
        private SerializerCreator<Shape> serializerCreator = null;

        private ShapesDrawer sd;

        private Pen canvasPen = new Pen(Color.Black);

        private List<int> selectedShapes = new List<int>();

        private ISerializer<Shape> serializer;

        private PluginLoader loader = null;

        private List<Type> plugins = new List<Type>();
        private List<Type> shapePlugins = new List<Type>();
        private List<Type> shapeHandlerPlugins = new List<Type>();
        private List<Type> serializerPlugins = new List<Type>();
        private List<Type> serializerHandlerPlugins = new List<Type>();
        //private List<Type> strangePlugins = new List<Type>();

        public GraphicsForm()
        {
            InitializeComponent();
            InitializeStaticShapes();

            
            Graphics graphics = canvas.CreateGraphics();
            canvas.Image = DrawFilledRectangle(canvas.Width, canvas.Height);
            sd = new ShapesDrawer(graphics, canvas);
            
            shapeCreator = new ShapeCreator(cbShapesType.Text, shapePlugins, shapeHandlerPlugins);
            serializerCreator = new SerializerCreator<Shape>(serializerPlugins, serializerHandlerPlugins);

            cbShapesType.SelectedIndex = 0;
            cbSerializer.SelectedIndex = 0;
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
            Refresh();
            canvas.Image = DrawFilledRectangle(canvas.Width, canvas.Height);
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
                
                shapes[index].PenState.Color = canvasPen.Color;
                shapes[index].PenState.RGB = canvasPen.Color.ToArgb();
                shapes[index].PenState.Width = canvasPen.Width;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
            canvas.Image = DrawFilledRectangle(canvas.Width, canvas.Height);
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
        private Bitmap DrawFilledRectangle(int x, int y)
        {
            Bitmap bmp = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, x, y);
                graph.FillRectangle(Brushes.Transparent, ImageSize);
            }
            return bmp;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentShape.Resize(new Point(e.X, e.Y));
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
            btnClone.Enabled = selectedShapes.Count == 1 ? true : false;

            DrawShapesCanvas();
        }

        private void tbWidth_Scroll(object sender, EventArgs e)
        {
            canvasPen.Width = tbWidth.Value;
            ChangeSelectedShapes();

            DrawShapesCanvas();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                serializer.Serialize(shapes[selectedShapes[0]], openFileDialog.FileName);
            }
            catch (CustomSerializerException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                currentShape = serializer.Deserialize(openFileDialog.FileName);

                currentShape.Pen = new Pen(Color.FromArgb(currentShape.PenState.RGB));
                currentShape.PenState.Color = currentShape.Pen.Color;
                currentShape.Pen.Width = currentShape.PenState.Width;

                AddCurrentShape();

                btnClear.Enabled = true;
                DrawShapesCanvas();
            }
            catch (CustomSerializerException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbSerializer_SelectedIndexChanged(object sender, EventArgs e)
        {
            serializer = serializerCreator.GetSerializer(cbSerializer.Text);
        }

        private void lblWidth_Click(object sender, EventArgs e)
        {

        }

        private void SetPluginLists(List<Type> plugins)
        {
            foreach (var plugin in plugins)
            {
                if (plugin.FullName.Contains("Handler"))
                {
                    shapeHandlerPlugins.Add(plugin);
                }
                else if (plugin.FullName.Contains("Shape"))
                {
                    shapePlugins.Add(plugin);
                    cbShapesType.Items.Add(plugin.Name);
                }
                if (plugin.FullName.Contains("SerializerHandler"))
                {
                    serializerHandlerPlugins.Add(plugin);
                }
                else if (plugin.FullName.Contains("Custom"))
                {
                    serializerPlugins.Add(plugin);
                    cbSerializer.Items.Add(plugin.ToString().Split('.')[1]);
                }

            }

            shapeCreator = new ShapeCreator(cbShapesType.Text, shapePlugins, shapeHandlerPlugins);
            serializerCreator = new SerializerCreator<Shape>(serializerPlugins, serializerHandlerPlugins);
        }

        private void btnPlugins_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    loader = PluginLoader.GetInstance();
                    plugins = loader.Load(fbd.SelectedPath);
                    SetPluginLists(plugins);    

                    MessageBox.Show("Selected plugins are now available", "Message");
                }
            }
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            currentShape = shapes[selectedShapes[0]].Clone();
            AddCurrentShape();

            currentShape = null;
            btnClear.Enabled = true;
        }
    }
}