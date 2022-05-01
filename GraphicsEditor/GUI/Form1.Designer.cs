namespace GUI
{
    partial class GraphicsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbShapesType = new System.Windows.Forms.ComboBox();
            this.lbShapes = new System.Windows.Forms.ListBox();
            this.btnColorChange = new System.Windows.Forms.Button();
            this.shapesColorDialog = new System.Windows.Forms.ColorDialog();
            this.tbWidth = new System.Windows.Forms.TrackBar();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.ImageLocation = "";
            this.canvas.Location = new System.Drawing.Point(208, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(580, 426);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Click += new System.EventHandler(this.canvas_Click);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            this.canvas.Move += new System.EventHandler(this.canvas_Move);
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(8, 409);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(94, 29);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(108, 409);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 29);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cbShapesType
            // 
            this.cbShapesType.FormattingEnabled = true;
            this.cbShapesType.Items.AddRange(new object[] {
            "Line",
            "Square",
            "Rectangle",
            "Triangle",
            "Circle",
            "Ellipse"});
            this.cbShapesType.Location = new System.Drawing.Point(8, 12);
            this.cbShapesType.Name = "cbShapesType";
            this.cbShapesType.Size = new System.Drawing.Size(194, 28);
            this.cbShapesType.TabIndex = 3;
            this.cbShapesType.SelectedIndexChanged += new System.EventHandler(this.cbShapesType_SelectedIndexChanged);
            // 
            // lbShapes
            // 
            this.lbShapes.FormattingEnabled = true;
            this.lbShapes.ItemHeight = 20;
            this.lbShapes.Location = new System.Drawing.Point(8, 46);
            this.lbShapes.Name = "lbShapes";
            this.lbShapes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbShapes.Size = new System.Drawing.Size(194, 104);
            this.lbShapes.TabIndex = 4;
            this.lbShapes.SelectedIndexChanged += new System.EventHandler(this.lbShapes_SelectedIndexChanged);
            // 
            // btnColorChange
            // 
            this.btnColorChange.BackColor = System.Drawing.Color.Black;
            this.btnColorChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnColorChange.ForeColor = System.Drawing.Color.Transparent;
            this.btnColorChange.Location = new System.Drawing.Point(95, 169);
            this.btnColorChange.Name = "btnColorChange";
            this.btnColorChange.Size = new System.Drawing.Size(89, 29);
            this.btnColorChange.TabIndex = 5;
            this.btnColorChange.UseVisualStyleBackColor = false;
            this.btnColorChange.Click += new System.EventHandler(this.btnColorChange_Click);
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(83, 227);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(101, 56);
            this.tbWidth.TabIndex = 6;
            this.tbWidth.Scroll += new System.EventHandler(this.tbWidth_Scroll);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(25, 178);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(48, 20);
            this.lblColor.TabIndex = 7;
            this.lblColor.Text = "Color:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(25, 237);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(52, 20);
            this.lblWidth.TabIndex = 8;
            this.lblWidth.Text = "Width:";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(8, 289);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(108, 289);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 29);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // GraphicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.tbWidth);
            this.Controls.Add(this.btnColorChange);
            this.Controls.Add(this.lbShapes);
            this.Controls.Add(this.cbShapesType);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.canvas);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GraphicsForm";
            this.Text = "graphics";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox canvas;
        private Button btnDraw;
        private Button btnClear;
        private ComboBox cbShapesType;
        private ListBox lbShapes;
        private Button btnColorChange;
        private ColorDialog shapesColorDialog;
        private TrackBar tbWidth;
        private Label lblColor;
        private Label lblWidth;
        private Button btnSave;
        private Button btnLoad;
        private OpenFileDialog openFileDialog;
    }
}