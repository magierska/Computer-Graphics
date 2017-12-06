using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor
{
    public class Vertex : ICloneable
    {
        public Point Point;
        int pointRadius = 5;
        Color pointColor = Color.Violet, selectedPointColor = Color.Green;
        public bool Changed = false;
        public bool Intersection;

        public Vertex(Point _point, bool _intersection = false)
        {
            Point = _point;
            Intersection = _intersection;
        }

        public bool IsTheSamePoint(Point _point)
        {
            return GetRectangle().Contains(_point);
        }

        public void DrawPoint(ref Bitmap temporaryBitmap)
        {
            using (Graphics g = Graphics.FromImage(temporaryBitmap))
                g.FillEllipse(new SolidBrush(pointColor), this.GetRectangle());
        }

        public void SelectPoint(bool select)
        {
            if (select)
                pointColor = Color.Green;
            else
                pointColor = Color.Violet;
        }

        public void Move(int x, int y)
        {
            this.X += x;
            this.Y += y;
        }

        private Rectangle GetRectangle()
        {
            return new Rectangle(new Point(Point.X - pointRadius, Point.Y - pointRadius), new Size(2 * pointRadius, 2 * pointRadius));
        }

        public object Clone()
        {
            Vertex vertex = new PolygonEditor.Vertex(this.Point);
            vertex.Changed = this.Changed;
            return vertex;
        }

        public int X
        {
            get
            {
                return Point.X;
            }
            set
            {
                Point.X = value;
            }
        }

        public int Y
        {
            get
            {
                return Point.Y;
            }
            set
            {
                Point.Y = value;
            }
        }
    }
}
