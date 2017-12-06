using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor
{
    public class Polygon
    {
        public Color LineColor = Color.Black;
        public List<Vertex> Vertices = new List<Vertex>();
        private int BitmapWidth, BitmapHeight;
        private PolygonEditorForm Form;

        public Polygon(int bitmapWidth, int bitmapHeight, PolygonEditorForm form)
        {
            BitmapWidth = bitmapWidth;
            BitmapHeight = bitmapHeight;
            Form = form;
        }

        public void DrawLine(ref Bitmap stableBitmap, Vertex lineStart, Vertex lineEnd)
        {
            lineStart.DrawTag(ref stableBitmap, this.GetMiddle(lineStart, lineEnd));
            this.DrawLine(ref stableBitmap, lineStart.Point, lineEnd.Point, LineColor);
        }

        public void DrawLine( ref Bitmap temporaryBitmap, Point lineStart, Point lineEnd, Color lineColor)
        {
            if (Form.drawingAlgorithm == PolygonEditorForm.DrawingAlgorithm.Bresenham)
                this.DrawLineBresenham(ref temporaryBitmap, lineStart, lineEnd, LineColor);
            else
                this.DrawLineWu(ref temporaryBitmap, lineStart, lineEnd, LineColor);
            Vertex vertexStart = new Vertex(lineStart);
            vertexStart.DrawPoint(ref temporaryBitmap);
            Vertex vertexEnd = new Vertex(lineEnd);
            vertexEnd.DrawPoint(ref temporaryBitmap);
        }

        private void plot(Bitmap bitmap, double x, double y, double c)
        {
            int alpha = (int)(c * 255);
            if (alpha > 255) alpha = 255;
            if (alpha < 0) alpha = 0;
            Color color = Color.FromArgb(alpha, LineColor);
            if ((int)x > 0 && (int)x < bitmap.Width && (int)y > 0 && (int)y < bitmap.Height)
            {
                bitmap.SetPixel((int)x, (int)y, color);
            }
        }

        int ipart(double x) { return (int)x; }

        int round(double x) { return ipart(x + 0.5); }

        double fpart(double x)
        {
            if (x < 0) return (1 - (x - Math.Floor(x)));
            return (x - Math.Floor(x));
        }

        double rfpart(double x)
        {
            return 1 - fpart(x);
        }

        public void DrawLineWu(ref Bitmap temporaryBitmap, Point lineStart, Point lineEnd, Color lineColor)
        {
            int x0 = lineStart.X, x1 = lineEnd.X, y0 = lineStart.Y, y1 = lineEnd.Y;
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            int temp;
            if (steep)
            {
                temp = x0; x0 = y0; y0 = temp;
                temp = x1; x1 = y1; y1 = temp;
            }
            if (x0 > x1)
            {
                temp = x0; x0 = x1; x1 = temp;
                temp = y0; y0 = y1; y1 = temp;
            }

            double dx = x1 - x0;
            double dy = y1 - y0;
            double gradient = dy / dx;

            double xEnd = round(x0);
            double yEnd = y0 + gradient * (xEnd - x0);
            double xGap = rfpart(x0 + 0.5);
            double xPixel1 = xEnd;
            double yPixel1 = ipart(yEnd);

            if (steep)
            {
                plot(temporaryBitmap, yPixel1, xPixel1, rfpart(yEnd) * xGap);
                plot(temporaryBitmap, yPixel1 + 1, xPixel1, fpart(yEnd) * xGap);
            }
            else
            {
                plot(temporaryBitmap, xPixel1, yPixel1, rfpart(yEnd) * xGap);
                plot(temporaryBitmap, xPixel1, yPixel1 + 1, fpart(yEnd) * xGap);
            }
            double intery = yEnd + gradient;

            xEnd = round(x1);
            yEnd = y1 + gradient * (xEnd - x1);
            xGap = fpart(x1 + 0.5);
            double xPixel2 = xEnd;
            double yPixel2 = ipart(yEnd);
            if (steep)
            {
                plot(temporaryBitmap, yPixel2, xPixel2, rfpart(yEnd) * xGap);
                plot(temporaryBitmap, yPixel2 + 1, xPixel2, fpart(yEnd) * xGap);
            }
            else
            {
                plot(temporaryBitmap, xPixel2, yPixel2, rfpart(yEnd) * xGap);
                plot(temporaryBitmap, xPixel2, yPixel2 + 1, fpart(yEnd) * xGap);
            }

            if (steep)
            {
                for (int x = (int)(xPixel1 + 1); x <= xPixel2 - 1; x++)
                {
                    plot(temporaryBitmap, ipart(intery), x, rfpart(intery));
                    plot(temporaryBitmap, ipart(intery) + 1, x, fpart(intery));
                    intery += gradient;
                }
            }
            else
            {
                for (int x = (int)(xPixel1 + 1); x <= xPixel2 - 1; x++)
                {
                    plot(temporaryBitmap, x, ipart(intery), rfpart(intery));
                    plot(temporaryBitmap, x, ipart(intery) + 1, fpart(intery));
                    intery += gradient;
                }
            }
        }

        public void DrawLineBresenham(ref Bitmap temporaryBitmap, Point lineStart, Point lineEnd, Color lineColor)
        {
            int x0 = lineStart.X, y0 = lineStart.Y, x1 = lineEnd.X, y1 = lineEnd.Y;
            if (x0 < x1 && y0 <= y1 && x1 - x0 > y1 - y0) //0
            {
                int dx = x1 - x0;
                int dy = y1 - y0;
                int d = 2 * dy - dx;
                int incrE = 2 * dy;
                int incrNE = 2 * (dy - dx);
                int xf = x0, yf = y0, xb = x1, yb = y1;
                if (xf < BitmapWidth && xf > 0 && yf + 1 < BitmapHeight && yf - 1 > 0)
                    temporaryBitmap.SetPixel(xf, yf, lineColor);
                if (xb < BitmapWidth && xb > 0 && yb + 1 < BitmapHeight && yb - 1 > 0)
                    temporaryBitmap.SetPixel(xb, yb, lineColor);
                while (xf < xb)
                {
                    xf++;
                    xb--;
                    if (d < 0)
                    {
                        d += incrE;
                    }
                    else
                    {
                        d += incrNE;
                        yf++;
                        yb--;
                    }
                    if (xf < BitmapWidth && xf > 0 && yf + 1 < BitmapHeight && yf - 1 > 0)
                        temporaryBitmap.SetPixel(xf, yf, lineColor);
                    if (xb < BitmapWidth && xb > 0 && yb + 1 < BitmapHeight && yb - 1 > 0)
                        temporaryBitmap.SetPixel(xb, yb, lineColor);
                }
            }
            else if (x0 < x1 && y0 < y1 && x1 - x0 <= y1 - y0) //1
            {
                int dx = y1 - y0;
                int dy = x1 - x0;
                int d = 2 * dy - dx;
                int incrE = 2 * dy;
                int incrNE = 2 * (dy - dx);
                int xf = x0, yf = y0, xb = x1, yb = y1;
                if (xf + 1 < BitmapWidth && xf - 1 > 0 && yf < BitmapHeight && yf > 0)
                    temporaryBitmap.SetPixel(xf, yf, lineColor);
                if (xb + 1 < BitmapWidth && xb - 1 > 0 && yb < BitmapHeight && yb > 0)
                    temporaryBitmap.SetPixel(xb, yb, lineColor);
                while (yf < yb)
                {
                    yf++;
                    yb--;
                    if (d < 0)
                    {
                        d += incrE;
                    }
                    else
                    {
                        d += incrNE;
                        xf++;
                        xb--;
                    }
                    if (xf + 1 < BitmapWidth && xf - 1 > 0 && yf < BitmapHeight && yf > 0)
                        temporaryBitmap.SetPixel(xf, yf, lineColor);
                    if (xb + 1 < BitmapWidth && xb - 1 > 0 && yb < BitmapHeight && yb > 0)
                        temporaryBitmap.SetPixel(xb, yb, lineColor);
                }
            }
            else if (x0 >= x1 && y0 < y1 && x0 - x1 < y1 - y0) //2
            {
                int dx = y1 - y0;
                int dy = x0 - x1;
                int d = 2 * dy - dx;
                int incrE = 2 * dy;
                int incrNE = 2 * (dy - dx);
                int xf = x0, yf = y0, xb = x1, yb = y1;
                if (xf + 1 < BitmapWidth && xf - 1 > 0 && yf < BitmapHeight && yf > 0)
                    temporaryBitmap.SetPixel(xf, yf, lineColor);
                if (xb + 1 < BitmapWidth && xb - 1 > 0 && yb < BitmapHeight && yb > 0)
                    temporaryBitmap.SetPixel(xb, yb, lineColor);
                while (yf < yb)
                {
                    yf++;
                    yb--;
                    if (d < 0)
                    {
                        d += incrE;
                    }
                    else
                    {
                        d += incrNE;
                        xf--;
                        xb++;
                    }
                    if (xf + 1 < BitmapWidth && xf - 1 > 0 && yf < BitmapHeight && yf > 0)
                        temporaryBitmap.SetPixel(xf, yf, lineColor);
                    if (xb + 1 < BitmapWidth && xb - 1 > 0 && yb < BitmapHeight && yb > 0)
                        temporaryBitmap.SetPixel(xb, yb, lineColor);
                }
            }
            else if (x0 > x1 && y0 < y1 && x0 - x1 >= y1 - y0) //3
            {
                int dx = x0 - x1;
                int dy = y1 - y0;
                int d = 2 * dy - dx;
                int incrE = 2 * dy;
                int incrNE = 2 * (dy - dx);
                int xf = x0, yf = y0, xb = x1, yb = y1;
                if (xf < BitmapWidth && xf > 0 && yf + 1 < BitmapHeight && yf - 1 > 0)
                    temporaryBitmap.SetPixel(xf, yf, lineColor);
                if (xb < BitmapWidth && xb > 0 && yb + 1 < BitmapHeight && yb - 1 > 0)
                    temporaryBitmap.SetPixel(xb, yb, lineColor);
                while (xf > xb)
                {
                    xf--;
                    xb++;
                    if (d < 0)
                    {
                        d += incrE;
                    }
                    else
                    {
                        d += incrNE;
                        yf++;
                        yb--;
                    }
                    if (xf < BitmapWidth && xf > 0 && yf + 1 < BitmapHeight && yf - 1 > 0)
                        temporaryBitmap.SetPixel(xf, yf, lineColor);
                    if (xb < BitmapWidth && xb > 0 && yb + 1 < BitmapHeight && yb - 1 > 0)
                        temporaryBitmap.SetPixel(xb, yb, lineColor);
                }
            }
            else if (x0 > x1 && y0 >= y1 && x0 - x1 > y0 - y1) //4
            {
                int dx = x0 - x1;
                int dy = y0 - y1;
                int d = 2 * dy - dx;
                int incrE = 2 * dy;
                int incrNE = 2 * (dy - dx);
                int xf = x0, yf = y0, xb = x1, yb = y1;
                if (xf < BitmapWidth && xf > 0 && yf + 1 < BitmapHeight && yf - 1 > 0)
                    temporaryBitmap.SetPixel(xf, yf, lineColor);
                if (xb < BitmapWidth && xb > 0 && yb + 1 < BitmapHeight && yb - 1 > 0)
                    temporaryBitmap.SetPixel(xb, yb, lineColor);
                while (xf > xb)
                {
                    xf--;
                    xb++;
                    if (d < 0)
                    {
                        d += incrE;
                    }
                    else
                    {
                        d += incrNE;
                        yf--;
                        yb++;
                    }
                    if (xf < BitmapWidth && xf > 0 && yf + 1 < BitmapHeight && yf - 1 > 0)
                        temporaryBitmap.SetPixel(xf, yf, lineColor);
                    if (xb < BitmapWidth && xb > 0 && yb + 1 < BitmapHeight && yb - 1 > 0)
                        temporaryBitmap.SetPixel(xb, yb, lineColor);
                }
            }
            else if (x0 > x1 && y0 > y1 && x0 - x1 <= y0 - y1) //5
            {
                int dx = y0 - y1;
                int dy = x0 - x1;
                int d = 2 * dy - dx;
                int incrE = 2 * dy;
                int incrNE = 2 * (dy - dx);
                int xf = x0, yf = y0, xb = x1, yb = y1;
                if (xf + 1 < BitmapWidth && xf - 1 > 0 && yf < BitmapHeight && yf > 0)
                    temporaryBitmap.SetPixel(xf, yf, lineColor);
                if (xb + 1 < BitmapWidth && xb - 1 > 0 && yb < BitmapHeight && yb > 0)
                    temporaryBitmap.SetPixel(xb, yb, lineColor);
                while (yf > yb)
                {
                    yf--;
                    yb++;
                    if (d < 0)
                    {
                        d += incrE;
                    }
                    else
                    {
                        d += incrNE;
                        xf--;
                        xb++;
                    }
                    if (xf + 1 < BitmapWidth && xf - 1 > 0 && yf < BitmapHeight && yf > 0)
                        temporaryBitmap.SetPixel(xf, yf, lineColor);
                    if (xb + 1 < BitmapWidth && xb - 1 > 0 && yb < BitmapHeight && yb > 0)
                        temporaryBitmap.SetPixel(xb, yb, lineColor);
                }
            }
            else if (x0 <= x1 && y0 > y1 && x1 - x0 < y0 - y1) //6
            {
                int dx = y0 - y1;
                int dy = x1 - x0;
                int d = 2 * dy - dx;
                int incrE = 2 * dy;
                int incrNE = 2 * (dy - dx);
                int xf = x0, yf = y0, xb = x1, yb = y1;
                if (xf + 1 < BitmapWidth && xf - 1 > 0 && yf < BitmapHeight && yf > 0)
                    temporaryBitmap.SetPixel(xf, yf, lineColor);
                if (xb + 1 < BitmapWidth && xb - 1 > 0 && yb < BitmapHeight && yb > 0)
                    temporaryBitmap.SetPixel(xb, yb, lineColor);
                while (yf > yb)
                {
                    yf--;
                    yb++;
                    if (d < 0)
                    {
                        d += incrE;
                    }
                    else
                    {
                        d += incrNE;
                        xf++;
                        xb--;
                    }
                    if (xf + 1 < BitmapWidth && xf - 1 > 0 && yf < BitmapHeight && yf > 0)
                        temporaryBitmap.SetPixel(xf, yf, lineColor);
                    if (xb + 1 < BitmapWidth && xb - 1 > 0 && yb < BitmapHeight && yb > 0)
                        temporaryBitmap.SetPixel(xb, yb, lineColor);
                }
            }
            else if (x0 < x1 && y0 > y1 && x1 - x0 >= y0 - y1) //7
            {
                int dx = x1 - x0;
                int dy = y0 - y1;
                int d = 2 * dy - dx;
                int incrE = 2 * dy;
                int incrNE = 2 * (dy - dx);
                int xf = x0, yf = y0, xb = x1, yb = y1;
                if (xf < BitmapWidth && xf > 0 && yf + 1 < BitmapHeight && yf - 1 > 0)
                    temporaryBitmap.SetPixel(xf, yf, lineColor);
                if (xb < BitmapWidth && xb > 0 && yb + 1 < BitmapHeight && yb - 1 > 0)
                    temporaryBitmap.SetPixel(xb, yb, lineColor);
                while (xf < xb)
                {
                    xf++;
                    xb--;
                    if (d < 0)
                    {
                        d += incrE;
                    }
                    else
                    {
                        d += incrNE;
                        yf--;
                        yb++;
                    }
                    if (xf < BitmapWidth && xf > 0 && yf + 1 < BitmapHeight && yf - 1 > 0)
                        temporaryBitmap.SetPixel(xf, yf, lineColor);
                    if (xb < BitmapWidth && xb > 0 && yb + 1 < BitmapHeight && yb - 1 > 0)
                        temporaryBitmap.SetPixel(xb, yb, lineColor);
                }
            }
        }

        public bool PointInsidePolygon(Point point)
        {
            bool result = false;
            for (int i = 0, j = Vertices.Count - 1; i < Vertices.Count; j = i++)
            {
                if ((Vertices[i].Y > point.Y) != (Vertices[j].Y > point.Y) && (point.X < (Vertices[j].X - Vertices[i].X) * (point.Y - Vertices[i].Y) / (Vertices[j].Y - Vertices[i].Y) + Vertices[i].X))
                    result = !result;
            }
            return result;
        }

        public void MoveEntirePolygon(Point startPoint, Point endPoint)
        {
            int x = endPoint.X - startPoint.X, y = endPoint.Y - startPoint.Y;
            for (int i = 0; i <= Vertices.Count; i++)
            {
                if (i < Vertices.Count)
                {
                    Vertices[i].X += x;
                    Vertices[i].Y += y;
                }
            }
        }

        public int IsOnVertices(Point clickedPoint)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i].IsTheSamePoint(clickedPoint))
                    return i;
            }
            return -1;
        }

        public void MoveVertex(int vertexIndex, Point newPoint)
        {
            Point vector = new Point(newPoint.X - Vertices[vertexIndex].X, newPoint.Y - Vertices[vertexIndex].Y);
            Vertices[vertexIndex].Move(vector.X, vector.Y);
            CheckPreviousTags(vertexIndex, vector);
            CheckNextTags(vertexIndex, vector);
        }

        private bool CheckNextTags(int movingVertexIndex, Point movingVector)
        {
            if (Vertices[movingVertexIndex].Changed)
                return false;
            bool returnValue = true;
            if (Vertices[movingVertexIndex].Tag != Vertex.Tags.Nothing)
            {
                Vertices[movingVertexIndex].Changed = true;
                int nextVertexIndex = (movingVertexIndex + 1) % Vertices.Count;

                if (Vertices[nextVertexIndex].Tag == Vertex.Tags.Nothing)
                    Vertices[nextVertexIndex].Move(movingVector.X, movingVector.Y);
                else if (Vertices[movingVertexIndex].Tag == Vertex.Tags.VerticalLine && Vertices[nextVertexIndex].Tag == Vertex.Tags.HorizontalLine)
                    Vertices[nextVertexIndex].Move(movingVector.X, 0);
                else if (Vertices[movingVertexIndex].Tag == Vertex.Tags.HorizontalLine && Vertices[nextVertexIndex].Tag == Vertex.Tags.VerticalLine)
                    Vertices[nextVertexIndex].Move(0, movingVector.Y);
                else if (Vertices[movingVertexIndex].Tag == Vertex.Tags.Length && Vertices[nextVertexIndex].Tag == Vertex.Tags.Length)
                {
                    try
                    {
                        Vertices[nextVertexIndex].Point = FindTwoCirclesInterception(Vertices[movingVertexIndex].Point, Vertices[(movingVertexIndex + 2) % Vertices.Count].Point, Vertices[movingVertexIndex].ChosenLength, Vertices[nextVertexIndex].ChosenLength);
                    }
                    catch (IncompatibleTagsException)
                    {
                        Vertices[nextVertexIndex].Move(movingVector.X, movingVector.Y);
                        returnValue = this.CheckNextTags(nextVertexIndex, movingVector);
                    }
                }
                else if (Vertices[movingVertexIndex].Tag == Vertex.Tags.Length)
                {
                    try
                    {
                        Vertices[nextVertexIndex].Point = FindLineAndCircleInterception(Vertices[movingVertexIndex].Point, Vertices[movingVertexIndex].ChosenLength, Vertices[(movingVertexIndex + 2) % Vertices.Count].Point, Vertices[nextVertexIndex].Tag, Vertices[nextVertexIndex].Point);
                    }
                    catch (IncompatibleTagsException)
                    {
                        Vertices[nextVertexIndex].Move(movingVector.X, movingVector.Y);
                        returnValue = this.CheckNextTags(nextVertexIndex, movingVector);
                    }
                }
                else if (Vertices[nextVertexIndex].Tag == Vertex.Tags.Length)
                {
                    try
                    {
                        Vertices[nextVertexIndex].Point = FindLineAndCircleInterception(Vertices[(movingVertexIndex + 2) % Vertices.Count].Point, Vertices[nextVertexIndex].ChosenLength, Vertices[movingVertexIndex].Point, Vertices[movingVertexIndex].Tag, Vertices[nextVertexIndex].Point);
                    }
                    catch (IncompatibleTagsException)
                    {
                        Vertices[nextVertexIndex].Move(movingVector.X, movingVector.Y);
                        returnValue = this.CheckNextTags(nextVertexIndex, movingVector);
                    }
                }
                Vertices[movingVertexIndex].Changed = false;
            }
            return returnValue;
        }

        private bool CheckPreviousTags(int movingVertexIndex, Point movingVector)
        {
            if (Vertices[movingVertexIndex].Changed)
                return false;
            bool returnValue = true;
            int previousVertexIndex = (movingVertexIndex - 1 + Vertices.Count) % Vertices.Count;
            int prePreviousVertexIndex = (movingVertexIndex - 2 + Vertices.Count) % Vertices.Count;
            if (Vertices[previousVertexIndex].Tag != Vertex.Tags.Nothing)
            {
                Vertices[movingVertexIndex].Changed = true;
                if (Vertices[prePreviousVertexIndex].Tag == Vertex.Tags.Nothing)
                    Vertices[previousVertexIndex].Move(movingVector.X, movingVector.Y);
                else if (Vertices[previousVertexIndex].Tag == Vertex.Tags.VerticalLine && Vertices[prePreviousVertexIndex].Tag == Vertex.Tags.HorizontalLine)
                    Vertices[previousVertexIndex].Move(movingVector.X, 0);
                else if (Vertices[previousVertexIndex].Tag == Vertex.Tags.HorizontalLine && Vertices[prePreviousVertexIndex].Tag == Vertex.Tags.VerticalLine)
                    Vertices[previousVertexIndex].Move(0, movingVector.Y);
                else if (Vertices[previousVertexIndex].Tag == Vertex.Tags.Length && Vertices[prePreviousVertexIndex].Tag == Vertex.Tags.Length)
                {
                    try
                    {
                        Vertices[previousVertexIndex].Point = FindTwoCirclesInterception(Vertices[movingVertexIndex].Point, Vertices[prePreviousVertexIndex].Point, Vertices[previousVertexIndex].ChosenLength, Vertices[prePreviousVertexIndex].ChosenLength);
                    }
                    catch (IncompatibleTagsException)
                    {
                        Vertices[previousVertexIndex].Move(movingVector.X, movingVector.Y);
                        returnValue = this.CheckPreviousTags(previousVertexIndex, movingVector);
                    }
                }
                else if (Vertices[previousVertexIndex].Tag == Vertex.Tags.Length)
                {
                    try
                    {
                        Vertices[previousVertexIndex].Point = FindLineAndCircleInterception(Vertices[movingVertexIndex].Point, Vertices[previousVertexIndex].ChosenLength, Vertices[prePreviousVertexIndex].Point, Vertices[prePreviousVertexIndex].Tag, Vertices[previousVertexIndex].Point);
                    }
                    catch (IncompatibleTagsException)
                    {
                        Vertices[previousVertexIndex].Move(movingVector.X, movingVector.Y);
                        returnValue = this.CheckPreviousTags(previousVertexIndex, movingVector);
                    }
                }
                else if (Vertices[prePreviousVertexIndex].Tag == Vertex.Tags.Length)
                {
                    try
                    {
                        Vertices[previousVertexIndex].Point = FindLineAndCircleInterception(Vertices[prePreviousVertexIndex].Point, Vertices[prePreviousVertexIndex].ChosenLength, Vertices[movingVertexIndex].Point, Vertices[previousVertexIndex].Tag, Vertices[previousVertexIndex].Point);
                    }
                    catch (IncompatibleTagsException)
                    {
                        Vertices[previousVertexIndex].Move(movingVector.X, movingVector.Y);
                        returnValue = this.CheckPreviousTags(previousVertexIndex, movingVector);
                    }
                }
                Vertices[movingVertexIndex].Changed = false;
            }
            return returnValue;
        }

        private Point FindTwoCirclesInterception(Point c1, Point c2, double r1, double r2)
        {
            double d = this.GetLineLength(c1, c2);
            if (d > r1 + r2 || (d == 0 && r1 == r2) || d + Math.Min(r1, r2) < Math.Max(r1, r2))
                throw new IncompatibleTagsException();
            double a = (r1 * r1 - r2 * r2 + d * d) / (2 * d);
            double h = Math.Sqrt(r1 * r1 - a * a);
            Point p = new Point((int)(c1.X + (a * (c2.X - c1.X)) / d), (int)(c1.Y + (a * (c2.Y - c1.Y)) / d));
            return new Point((int)(p.X + (h * (c2.Y - c1.Y)) / d), (int)(p.Y - (h * (c2.X - c1.X)) / d));
        }

        private Point FindLineAndCircleInterception(Point c1, double r1, Point c2, Vertex.Tags tag, Point c3)
        {
            int x = 0, y = 0;
            if (tag == Vertex.Tags.VerticalLine)
            {
                int dx = c2.X - c1.X;
                if (Math.Abs(dx) > r1)
                    throw new IncompatibleTagsException();
                int dy = (int)Math.Sqrt(r1 * r1 - dx * dx);
                y = c3.Y > c1.Y ? c1.Y + dy : c1.Y - dy;
                x = c2.X;
            }
            else if (tag == Vertex.Tags.HorizontalLine)
            {
                int dy = c2.Y - c1.Y;
                if (Math.Abs(dy) > r1)
                    throw new IncompatibleTagsException();
                int dx = (int)Math.Sqrt(r1 * r1 - dy * dy);
                x = c3.X > c1.X ? c1.X + dx : c1.X - dx;
                y = c2.Y;
            }
            return new Point(x, y);
        }

        public int IsOnLines(Point point)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                int sumx = Math.Abs(Vertices[i].X - Vertices[(i + 1) % Vertices.Count].X);
                int sumy = Math.Abs(Vertices[i].Y - Vertices[(i + 1) % Vertices.Count].Y);
                int d1x = Math.Abs(Vertices[i].X - point.X);
                int d1y = Math.Abs(Vertices[i].Y - point.Y);
                int d2x = Math.Abs(point.X - Vertices[(i + 1) % Vertices.Count].X);
                int d2y = Math.Abs(point.Y - Vertices[(i + 1) % Vertices.Count].Y);
                int dx = d1x + d2x;
                int dy = d1y + d2y;
                if (dx >= sumx - 2 && dx <= sumx + 2 && dy >= sumy -2 && dy <= sumy + 2)
                {
                    return i;
                }
            }
            return -1;
        }

        public void AddNewVertex(int vertexBeforeIndex)
        {
            Vertices[vertexBeforeIndex].Tag = Vertex.Tags.Nothing;
            Vertices.Insert(vertexBeforeIndex + 1, new Vertex(this.GetMiddle(vertexBeforeIndex)));
        }

        public void DeleteVertex(int vertexIndex)
        {
            Vertices[(vertexIndex - 1 + Vertices.Count) % Vertices.Count].Tag = Vertex.Tags.Nothing;
            Vertices.RemoveAt(vertexIndex);
        }

        public Bitmap DrawEntirePolygon(Bitmap temporaryBitmap)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                this.DrawLine(ref temporaryBitmap, Vertices[i], Vertices[(i + 1) % Vertices.Count]);
            }
            return temporaryBitmap;
        }

        public bool IsTagged(int vertexBeforeIndex, Vertex.Tags tag)
        {
            if (Vertices[vertexBeforeIndex].Tag == tag)
                return true;
            return false;
        }

        public void AddVerticalLineTag(int vertexBeforeIndex)
        {
            if (Vertices[(vertexBeforeIndex - 1 + Vertices.Count) % Vertices.Count].Tag == Vertex.Tags.VerticalLine || Vertices[(vertexBeforeIndex + 1) % Vertices.Count].Tag == Vertex.Tags.VerticalLine)
                throw new IncompatibleTagsException();
            Vertices[vertexBeforeIndex].Tag = Vertex.Tags.VerticalLine;
            Point vector = new Point(Vertices[vertexBeforeIndex].X - Vertices[(vertexBeforeIndex + 1) % Vertices.Count].X, 0);
            if (!CheckNextTags(vertexBeforeIndex, vector))
                Vertices[vertexBeforeIndex].Tag = Vertex.Tags.Nothing;
        }

        public void AddHorizontalLineTag(int vertexBeforeIndex)
        {
            if (Vertices[(vertexBeforeIndex - 1 + Vertices.Count) % Vertices.Count].Tag == Vertex.Tags.HorizontalLine || Vertices[(vertexBeforeIndex + 1) % Vertices.Count].Tag == Vertex.Tags.HorizontalLine)
                throw new IncompatibleTagsException();
            Vertices[vertexBeforeIndex].Tag = Vertex.Tags.HorizontalLine;
            Point vector = new Point(0, Vertices[vertexBeforeIndex].Y - Vertices[(vertexBeforeIndex + 1) % Vertices.Count].Y);
            if (!CheckNextTags(vertexBeforeIndex, vector))
                Vertices[vertexBeforeIndex].Tag = Vertex.Tags.Nothing;
        }

        public void AddLineLengthTag(int vertexBeforeIndex, double chosenLength)
        {
            double percent = chosenLength / this.GetLineLength(vertexBeforeIndex);
            int x = (int)(percent * (Vertices[vertexBeforeIndex].X - Vertices[(vertexBeforeIndex + 1) % Vertices.Count].X) + Vertices[(vertexBeforeIndex + 1) % Vertices.Count].X);
            int y = (int)(percent * (Vertices[vertexBeforeIndex].Y - Vertices[(vertexBeforeIndex + 1) % Vertices.Count].Y) + Vertices[(vertexBeforeIndex + 1) % Vertices.Count].Y);
            Vertices[vertexBeforeIndex].Tag = Vertex.Tags.Length;
            Vertices[vertexBeforeIndex].ChosenLength = chosenLength;
            Point vector = new Point(Vertices[vertexBeforeIndex].X - x, Vertices[vertexBeforeIndex].Y - y);
            if (!CheckNextTags(vertexBeforeIndex, vector))
                Vertices[vertexBeforeIndex].Tag = Vertex.Tags.Nothing;
        }

        public void DeleteTag(int vertexBeforeIndex)
        {
            Vertices[vertexBeforeIndex].Tag = Vertex.Tags.Nothing;
        }

        public double GetLineLength(int vertexBeforeIndex)
        {
            return this.GetLineLength(Vertices[vertexBeforeIndex].Point, Vertices[(vertexBeforeIndex + 1 )% Vertices.Count].Point);
        }

        private double GetLineLength(Point startPoint, Point endPoint)
        {
            return Math.Sqrt(Math.Pow(startPoint.X - endPoint.X, 2) + Math.Pow(startPoint.Y - endPoint.Y, 2));
        }

        private Point GetMiddle(int vertexBeforeIndex)
        {
            return this.GetMiddle(Vertices[vertexBeforeIndex], Vertices[(vertexBeforeIndex + 1) % Vertices.Count]);
        }

        private Point GetMiddle(Vertex startVertex, Vertex endVertex)
        {
            return new Point((startVertex.X + endVertex.X) / 2, (startVertex.Y + endVertex.Y) / 2);

        }
    }
}
