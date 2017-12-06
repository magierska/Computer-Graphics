using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor
{
    public partial class FillAndCropPolygonForm : Form
    {
        List<Polygon> polygonsList;
        Polygon polygon, clippingPolygon;
        Point currentClickedPoint, lastPointForMovingEntirePolygon;
        Bitmap stableBitmap, temporaryBitmap;
        Color polygonColor = Color.Black;
        int movingVertexIndex = -1, clickedLineIndex = -1;
        bool canDraw = false;
        enum Activities { nothing, firstDrawing, movingEntirePolygon, movingVertex };
        Activities activity = Activities.nothing;

        Timer timer;
        int interval = 10;
        int lightMove = 100, lightX;
        Point screenMiddle;
        int lanternHeight = 100;

        public FillAndCropPolygonForm()
        {
            InitializeComponent();

            Polygon.BitmapWidth = pictureBox.Width;
            Polygon.BitmapHeight = pictureBox.Height;
            polygonsList = new List<Polygon>();
            polygon = new Polygon();
            stableBitmap = temporaryBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);

            pictureBox.MouseClick += new MouseEventHandler(PictureBox_MouseClick);
            pictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            pictureBox.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
            pictureBox.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
            pictureBox.MouseDoubleClick += new MouseEventHandler(PictureBox_MouseDoubleClick);
            addNewVertexToolStripMenuItem.Click += new EventHandler(AddNewVertexToolStripMenuItem_Click);

            lightSourceColorPictureBox.Click += new EventHandler(lightSourceColorPictureBox_Click);
            constantObjectColorPictureBox.Click += new EventHandler(constantObjectColorPictureBox_Click);
            textureObjectPictureBox.Click += new EventHandler(textureObjectPictureBox_Click);
            textureDisoderPictureBox.Click += new EventHandler(textureDisoderPictureBox_Click);
            textureVectorPictureBox.Click += new EventHandler(textureVectorPictureBox_Click);

            // Default
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval += interval;
            screenMiddle = new Point(pictureBox.Width / 2, pictureBox.Height / 2);
            lightX = screenMiddle.X;

            Polygon pol1 = new Polygon();
            pol1.Vertices.Add(new Vertex(new Point(200, 200)));
            pol1.Vertices.Add(new Vertex(new Point(200, 400)));
            pol1.Vertices.Add(new Vertex(new Point(400, 400)));
            pol1.Vertices.Add(new Vertex(new Point(400, 200)));
            polygonsList.Add(pol1);

            Polygon pol2 = new Polygon();
            pol2.Vertices.Add(new Vertex(new Point(300, 150)));
            pol2.Vertices.Add(new Vertex(new Point(150, 300)));
            pol2.Vertices.Add(new Vertex(new Point(450, 300)));
            polygonsList.Add(pol2);

            lightSourceColorPictureBox.BackColor = Color.White;

            textureObjectPictureBox.BackColor = Color.White;
            ConstantObjectRadioButton.Checked = true;

            constantNormalVectorRadioButton.Checked = true;

            fDisorderTextbox.Text = "0,1";
            noDisorderRadioButton.Checked = true;

            radiusLightSourceVectorTextBox.Text = "1000";
            constantLightSourceVectorRadioButton.Checked = true;

            PaintingManager.InitializeLanterns(
                new Vector3(0, pictureBox.Height, lanternHeight),
                new Vector3(pictureBox.Width, pictureBox.Height, lanternHeight),
                new Vector3(pictureBox.Width / 2, 0, lanternHeight),
                new Vector3(pictureBox.Width / 2, pictureBox.Height / 2, 0));

            this.CheckRadioButtonsAndDrawNewPicture();

            ConstantObjectRadioButton.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            TextureObjectRadioButton.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            constantNormalVectorRadioButton.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            textureNormalVectorRadioButton.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            noDisorderRadioButton.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            textureDisorderRadioButton.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            constantLightSourceVectorRadioButton.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radiusLightSourceVectorRadioButton.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            fDisorderTextbox.TextChanged += new EventHandler(radioButton_CheckedChanged);
            redLightToolStripMenuItem.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            greenLightToolStripMenuItem.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            blueLightToolStripMenuItem.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!int.TryParse(radiusLightSourceVectorTextBox.Text, out int radius))
                return;
            if (lightX >= radius + screenMiddle.X - lightMove)
                lightX = screenMiddle.X - radius + lightMove;
            else
                lightX += lightMove;

            int z = (int)Math.Sqrt(radius * radius - Math.Pow(screenMiddle.X - lightX, 2));
            Vector3 vector = new Vector3(lightX - screenMiddle.X, 0, z);
            PaintingManager.SetLightVector(vector, false);
            this.DrawNewPicture();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckRadioButtonsAndDrawNewPicture();
        }

        private void CheckRadioButtonsAndDrawNewPicture()
        {
            PaintingManager.SetLightColor(lightSourceColorPictureBox.BackColor);

            if (ConstantObjectRadioButton.Checked)
                PaintingManager.SetBaseObject(constantObjectColorPictureBox.BackColor);
            else
                PaintingManager.SetBaseObject(textureObjectPictureBox.Image as Bitmap);

            if (constantNormalVectorRadioButton.Checked)
                PaintingManager.SetNormalVector(new Vector3(0, 0, 1));
            else
                PaintingManager.SetNormalVector(textureVectorPictureBox.Image as Bitmap);

            if (noDisorderRadioButton.Checked)
                PaintingManager.SetDisorder(new Vector3(0, 0, 0));
            else
                PaintingManager.SetDisorder(textureDisoderPictureBox.Image as Bitmap, fDisorderTextbox.Text);

            if (constantLightSourceVectorRadioButton.Checked)
            {
                timer.Stop();
                PaintingManager.SetLightVector(new Vector3(0, 0, 1), true);
            }
            else
            {
                if (!int.TryParse(radiusLightSourceVectorTextBox.Text, out int radius))
                    return;
                PaintingManager.SetLightVector(new Vector3(radius, 0, 0), false);
                timer.Start();
            }

            PaintingManager.SetLights(redLightToolStripMenuItem.Checked, greenLightToolStripMenuItem.Checked, blueLightToolStripMenuItem.Checked);

            this.DrawNewPicture();
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Point clickedPoint = e.Location;
            if (canDraw)
                activity = Activities.firstDrawing;
            if (activity == Activities.firstDrawing)
                ClickPointForFirstDrawing(clickedPoint);
        }

        private void ClickPointForFirstDrawing(Point clickedPoint)
        {
            for (int i = 0; i < polygon.Vertices.Count; i++)
            {
                if (polygon.Vertices[i].IsTheSamePoint(clickedPoint))
                {
                    if (i == 0 && polygon.Vertices.Count > 2)
                    {
                        activity = Activities.nothing;
                        break;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            RememberCurrentVertex(clickedPoint);
        }

        private void RememberCurrentVertex(Point clickedPoint)
        {
            if (activity == Activities.firstDrawing)
            {
                currentClickedPoint = clickedPoint;
                polygon.Vertices.Add(new Vertex(clickedPoint));
            }
            else
            {
                temporaryBitmap = (Bitmap)stableBitmap.Clone();
                polygon.FillPolygon(temporaryBitmap);
                polygon.DrawLine(ref temporaryBitmap, currentClickedPoint, polygon.Vertices[0].Point, polygon.LineColor);
                polygonsList.Add(polygon);
                canDraw = false;
            }
            pictureBox.Image = stableBitmap = (Bitmap)temporaryBitmap.Clone();
            pictureBox.Invalidate();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (activity == Activities.firstDrawing || polygonsList.Count == 0)
                return;

            if (activity == Activities.nothing && (movingVertexIndex = this.IsOnVertices(e.Location)) != -1)
            {
                activity = Activities.movingVertex;
            }
            else if (activity == Activities.nothing && this.IsInsidePolygon(e.Location))
            {
                lastPointForMovingEntirePolygon = e.Location;
                activity = Activities.movingEntirePolygon;
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (activity == Activities.movingEntirePolygon || activity == Activities.movingVertex)
                activity = Activities.nothing;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (activity == Activities.firstDrawing)
            {
                temporaryBitmap = (Bitmap)stableBitmap.Clone();
                polygon.DrawLine(ref temporaryBitmap, currentClickedPoint, e.Location, polygon.LineColor);
                pictureBox.Image = temporaryBitmap;
                pictureBox.Invalidate();
            }
            else if (activity == Activities.movingEntirePolygon)
            {
                polygon.MoveEntirePolygon(lastPointForMovingEntirePolygon, e.Location);
                this.DrawNewPicture();
                lastPointForMovingEntirePolygon = e.Location;
            }
            else if (activity == Activities.movingVertex)
            {
                polygon.MoveVertex(movingVertexIndex, e.Location);
                this.DrawNewPicture();
            }
        }

        private void PictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((clickedLineIndex = this.IsOnVertices(e.Location)) != -1)
            {
                currentClickedPoint = e.Location;
                contextMenuStrip2.Show(sender as PictureBox, e.Location);
            }
            else if (this.IsInsidePolygon(e.Location))
            {
                currentClickedPoint = e.Location;
                if (clippingPolygon == null)
                    clippingPolygon = polygon;
                else if (clippingPolygon != polygon)
                {
                    clippingPolygon.ClipPolygon(polygon);
                    polygonsList.Remove(polygon);
                    if (clippingPolygon.Vertices.Count <= 0)
                        polygonsList.Remove(clippingPolygon);
                    this.DrawNewPicture();
                    clippingPolygon = null;
                }
                else
                    clippingPolygon = null;
                polygon = new Polygon();
            }
            else if ((clickedLineIndex = this.IsOnLines(e.Location)) != -1)
            {
                currentClickedPoint = e.Location;
                contextMenuStrip1.Show(sender as PictureBox, e.Location);
            }
        }

        private int IsOnVertices(Point clickedPoint)
        {
            int index = -1;
            foreach (Polygon pol in polygonsList)
                if ((index = pol.IsOnVertices(clickedPoint)) != -1)
                {
                    polygon = pol;
                    return index;
                }
            return index;
        }

        private bool IsInsidePolygon(Point clickedPoint)
        {
            foreach (Polygon pol in polygonsList)
                if (pol.PointInsidePolygon(clickedPoint))
                {
                    polygon = pol;
                    return true;
                }
            return false;
        }

        private int IsOnLines(Point clickedPoint)
        {
            int index = -1;
            foreach (Polygon pol in polygonsList)
                if ((index = pol.IsOnLines(clickedPoint)) != -1)
                {
                    polygon = pol;
                    return index;
                }
            return index;
        }

        private void deleteVertexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedLineIndex != -1)
            {
                polygon.DeleteVertex(clickedLineIndex);
                this.DrawNewPicture();
                polygon = new Polygon();
            }
        }

        private void AddNewVertexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedLineIndex != -1)
            {
                polygon.AddNewVertex(clickedLineIndex);
                this.DrawNewPicture();
                polygon = new Polygon();
            }
        }

        private void drawNewPolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            polygon = new Polygon();
            canDraw = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            polygonsList = new List<Polygon>();
            polygon = new Polygon();
            pictureBox.Image = stableBitmap = temporaryBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Invalidate();
        }

        private void DrawNewPicture()
        {
            stableBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            foreach (Polygon pol in polygonsList)
            {
                pol.FillPolygon(stableBitmap);
                stableBitmap = pol.DrawEntirePolygon(stableBitmap);
            }
            pictureBox.Image = temporaryBitmap = stableBitmap;
            pictureBox.Invalidate();
        }

        private void FillPolygons()
        {
            foreach (Polygon pol in polygonsList)
                pol.FillPolygon(stableBitmap);
            pictureBox.Image = temporaryBitmap = stableBitmap;
            pictureBox.Invalidate();
        }

        private void lightSourceColorPictureBox_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                (sender as PictureBox).BackColor = color;
                PaintingManager.SetLightColor(color);
                this.DrawNewPicture();
            }
        }

        private void constantObjectColorPictureBox_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                (sender as PictureBox).BackColor = color;
                if (ConstantObjectRadioButton.Checked)
                {
                    PaintingManager.SetBaseObject(color);
                    this.DrawNewPicture();
                }
            }
        }

        private void textureObjectPictureBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Choose Texture Image";
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Bitmap image = new Bitmap(dlg.FileName);
                    (sender as PictureBox).Image = image;
                    if (TextureObjectRadioButton.Checked)
                    {
                        PaintingManager.SetBaseObject(image);
                        this.DrawNewPicture();
                    }
                }
            }
        }

        private void textureDisoderPictureBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Choose Texture Image";
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Bitmap image = new Bitmap(dlg.FileName);
                    (sender as PictureBox).Image = image;
                    if (textureDisorderRadioButton.Checked)
                    {
                        PaintingManager.SetDisorder(image, fDisorderTextbox.Text);
                        this.DrawNewPicture();
                    }
                }
            }
        }

        private void textureVectorPictureBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Choose Texture Image";
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Bitmap image = new Bitmap(dlg.FileName);
                    (sender as PictureBox).Image = image;
                    if (textureNormalVectorRadioButton.Checked)
                    {
                        PaintingManager.SetNormalVector(image);
                        this.DrawNewPicture();
                    }
                }
            }
        }
    }
}
