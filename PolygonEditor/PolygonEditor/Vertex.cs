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
        Color pointColor = Color.Violet, tagColor = Color.Green;
        public enum Tags { Nothing, VerticalLine, HorizontalLine, Length};
        public double ChosenLength;
        public Tags Tag = Tags.Nothing;
        public Point TagPoint;
        int tagSize = 20;
        public bool Changed = false;

        public Vertex(Point _point)
        {
            Point = _point;
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

        public void DrawTag(ref Bitmap temporaryBitmap, Point middle)
        {
            if (Tag == Tags.Nothing)
                return;
            using (Graphics g = Graphics.FromImage(temporaryBitmap))
            {
                TagPoint = middle;
                if (Tag == Tags.VerticalLine)
                {
                    g.FillRectangle(new SolidBrush(tagColor), new Rectangle(TagPoint, new Size(tagSize, tagSize)));
                    g.DrawLine(new Pen(Color.White, 3), new Point(TagPoint.X + tagSize / 2, TagPoint.Y + 2), new Point(TagPoint.X + tagSize / 2, TagPoint.Y + tagSize - 2));
                }
                else if (Tag == Tags.HorizontalLine)
                {
                    g.FillRectangle(new SolidBrush(tagColor), new Rectangle(TagPoint, new Size(tagSize, tagSize)));
                    g.DrawLine(new Pen(Color.White, 3), new Point(TagPoint.X + 2, TagPoint.Y + tagSize / 2), new Point(TagPoint.X + tagSize - 2, TagPoint.Y + tagSize / 2));
                }
                else if (Tag == Tags.Length)
                {
                    TextRenderer.DrawText(g, ChosenLength.ToString(), new Font("Arial", 14), TagPoint, tagColor, Color.White);
                }
            }
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
            vertex.Tag = this.Tag;
            vertex.ChosenLength = this.ChosenLength;
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
