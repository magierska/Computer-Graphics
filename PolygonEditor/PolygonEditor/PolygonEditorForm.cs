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
    public partial class PolygonEditorForm : Form
    {
        List<Polygon> polygonsList;
        Polygon polygon;
        Point currentClickedPoint, lastPointForMovingEntirePolygon;
        Bitmap stableBitmap, temporaryBitmap;
        Color polygonColor = Color.Black;
        int movingVertexIndex = -1, clickedLineIndex = -1;
        enum Activities { nothing, firstDrawing, movingEntirePolygon, movingVertex };
        Activities activity = Activities.nothing;

        public enum DrawingAlgorithm { Bresenham, Wu};
        public DrawingAlgorithm drawingAlgorithm = DrawingAlgorithm.Bresenham;

        public PolygonEditorForm()
        {
            InitializeComponent();

            polygonsList = new List<Polygon>();
            polygon = new Polygon(pictureBox.Width, pictureBox.Height, this);
            stableBitmap = temporaryBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);

            pictureBox.MouseClick += new MouseEventHandler(PictureBox_MouseClick);
            pictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            pictureBox.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
            pictureBox.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
            pictureBox.MouseDoubleClick += new MouseEventHandler(PictureBox_MouseDoubleClick);
            addNewVertexToolStripMenuItem.Click += new EventHandler(AddNewVertexToolStripMenuItem_Click);
            verticalLineToolStripMenuItem.Click += new EventHandler(VerticalLineToolStripMenuItem_Click);
            horizontalLineToolStripMenuItem.Click += new EventHandler(HorizontalLineToolStripMenuItem_Click);
            lineLengthToolStripMenuItem.Click += new EventHandler(LineLengthToolStripMenuItem_Click);
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Point clickedPoint = e.Location;
            if (polygon.Vertices.Count == 0)
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
                polygon.DrawLine(ref temporaryBitmap, currentClickedPoint, polygon.Vertices[0].Point, polygon.LineColor);
                polygonsList.Add(polygon);
            }
            pictureBox.Image = stableBitmap = (Bitmap)temporaryBitmap.Clone();
            pictureBox.Invalidate();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (activity == Activities.firstDrawing || polygonsList.Count == 0)
                return;

            if (activity == Activities.nothing && (movingVertexIndex = polygonsList[0].IsOnVertices(e.Location)) != -1)
            {
                activity = Activities.movingVertex;
            }
            else if (activity == Activities.nothing && polygonsList[0].PointInsidePolygon(e.Location))
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
            try
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
                    polygonsList[0].MoveEntirePolygon(lastPointForMovingEntirePolygon, e.Location);
                    this.DrawNewPicture();
                    lastPointForMovingEntirePolygon = e.Location;
                }
                else if (activity == Activities.movingVertex)
                {
                    polygonsList[0].MoveVertex(movingVertexIndex, e.Location);
                    this.DrawNewPicture();
                }
            }
            catch (IncompatibleTagsException){ }
        }

        private void PictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((clickedLineIndex = polygonsList[0].IsOnVertices(e.Location)) != -1)
            {
                currentClickedPoint = e.Location;
                contextMenuStrip2.Show(sender as PictureBox, e.Location);
            }
            else if ((clickedLineIndex = polygonsList[0].IsOnLines(e.Location)) != -1)
            {
                currentClickedPoint = e.Location;
                contextMenuStrip1.Show(sender as PictureBox, e.Location);
            }
        }

        private void deleteVertexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedLineIndex != -1)
            {
                try
                {
                    polygonsList[0].DeleteVertex(clickedLineIndex);
                    this.DrawNewPicture();
                }
                catch (IncompatibleTagsException) { }
            }
        }

        private void AddNewVertexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedLineIndex != -1)
            {
                try
                {
                    polygonsList[0].AddNewVertex(clickedLineIndex);
                    this.DrawNewPicture();
                }
                catch (IncompatibleTagsException) { }
            }
        }

        private void VerticalLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (polygonsList[0].IsTagged(clickedLineIndex, Vertex.Tags.VerticalLine))
                    polygonsList[0].DeleteTag(clickedLineIndex);
                else
                    polygonsList[0].AddVerticalLineTag(clickedLineIndex);
                this.DrawNewPicture();
            }
            catch (IncompatibleTagsException) { }
        }

        private void drawNewPolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            polygon = new Polygon(pictureBox.Width, pictureBox.Height, this);
        }

        private void HorizontalLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (polygonsList[0].IsTagged(clickedLineIndex, Vertex.Tags.HorizontalLine))
                    polygon.DeleteTag(clickedLineIndex);
                else
                    polygonsList[0].AddHorizontalLineTag(clickedLineIndex);
                this.DrawNewPicture();
            }
            catch (IncompatibleTagsException) { }
        }

        private void bresenhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wuToolStripMenuItem.CheckState = CheckState.Unchecked;
            bresenhamToolStripMenuItem.CheckState = CheckState.Checked;
            drawingAlgorithm = DrawingAlgorithm.Bresenham;
        }

        private void wuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bresenhamToolStripMenuItem.CheckState = CheckState.Unchecked;
            wuToolStripMenuItem.CheckState = CheckState.Checked;
            drawingAlgorithm = DrawingAlgorithm.Wu;
        }

        private void LineLengthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (polygonsList[0].IsTagged(clickedLineIndex, Vertex.Tags.Length))
                    polygonsList[0].DeleteTag(clickedLineIndex);
                else
                {
                    LineLengthEditor form = new LineLengthEditor(polygon.GetLineLength(clickedLineIndex));
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        polygonsList[0].AddLineLengthTag(clickedLineIndex, form.ChosenValue);
                    }
                }
                this.DrawNewPicture();
            }
            catch (IncompatibleTagsException) { }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            polygonsList = new List<Polygon>();
            polygon = new Polygon(pictureBox.Width, pictureBox.Height, this);
            pictureBox.Image = stableBitmap = temporaryBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Invalidate();
        }

        private void DrawNewPicture()
        {
            stableBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            foreach (Polygon pol in polygonsList)
                stableBitmap = pol.DrawEntirePolygon(stableBitmap);
            pictureBox.Image = temporaryBitmap = stableBitmap;
            pictureBox.Invalidate();
        }
    }
}
