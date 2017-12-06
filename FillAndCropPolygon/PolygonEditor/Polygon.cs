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
        public static int BitmapWidth, BitmapHeight;

        public Polygon()
        {
        }

        public void DrawLine(ref Bitmap stableBitmap, Vertex lineStart, Vertex lineEnd)
        {
            this.DrawLine(ref stableBitmap, lineStart.Point, lineEnd.Point, LineColor);
        }

        public void DrawLine(ref Bitmap temporaryBitmap, Point lineStart, Point lineEnd, Color lineColor)
        {
            using (Graphics g = Graphics.FromImage(temporaryBitmap))
            {
                g.DrawLine(new Pen(lineColor), lineStart, lineEnd);
            }
            Vertex vertex = new Vertex(lineStart);
            vertex.DrawPoint(ref temporaryBitmap);
            vertex = new Vertex(lineEnd);
            vertex.DrawPoint(ref temporaryBitmap);
        }

        public void SelectPolygon(bool select)
        {
            foreach (Vertex vertex in Vertices)
                vertex.SelectPoint(select);
        }

        public void FillPolygon(Bitmap bitmap)
        {
            List<Edge> AET = new List<Edge>();
            List<int> sortedIndices = new List<int>();
            for (int i = 0; i < Vertices.Count; i++)
                sortedIndices.Add(i);
            sortedIndices.Sort((s, t) => { if (Vertices[s].Y < Vertices[t].Y) return -1; if (Vertices[s].Y == Vertices[t].Y) return 0; return 1; });
            int y = Vertices[sortedIndices[0]].Y;
            int ymax = Vertices[sortedIndices[sortedIndices.Count - 1]].Y;
            int j = 0;
            for (; y <= ymax; y++)
            {
                for (; j < sortedIndices.Count && Vertices[sortedIndices[j]].Y == y - 1; j++)
                {
                    if (Vertices[(sortedIndices[j] - 1 + Vertices.Count) % Vertices.Count].Y > Vertices[sortedIndices[j]].Y)
                    {
                        AET.Add(new Edge(
                            Vertices[sortedIndices[j]],
                            Vertices[(sortedIndices[j] - 1 + Vertices.Count) % Vertices.Count]
                        ));
                    }
                    else
                        AET.RemoveAll(e => e.Vmax == Vertices[sortedIndices[j]] && e.Vmin == Vertices[(sortedIndices[j] - 1 + Vertices.Count) % Vertices.Count]);
                    if (Vertices[(sortedIndices[j] + 1) % Vertices.Count].Y > Vertices[sortedIndices[j]].Y)
                    {
                        AET.Add(new Edge(
                            Vertices[sortedIndices[j]],
                            Vertices[(sortedIndices[j] + 1) % Vertices.Count]
                        ));
                    }
                    else
                        AET.RemoveAll(e => e.Vmax == Vertices[sortedIndices[j]] && e.Vmin == Vertices[(sortedIndices[j] + 1) % Vertices.Count]);
                }
                AET.Sort((e1, e2) => { if (e1.X < e2.X) return -1; if (e1.X == e2.X) return 0; return 1; });
                for (int i = 0; i < AET.Count; i += 2)
                {
                    this.DrawScanLine(bitmap, (int)AET[i].X, (int)AET[i + 1].X, y);
                    AET[i].ActualizeX();
                    AET[i + 1].ActualizeX();
                }
            }
        }

        private void DrawScanLine(Bitmap bitmap, int xStart, int xEnd, int y)
        {
            if (y < 0 || y >= bitmap.Height)
                return;
            if (xStart < 0)
                xStart = 0;
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                for (int x = xStart; x <= xEnd; x++)
                {
                    if (x >= bitmap.Width)
                        return;
                    Color color = PaintingManager.GetColor(x, y);
                    bitmap.SetPixel(x, y, color);
                }
            }
        }

        public void ClipPolygon(Polygon polygon)
        {
            Vertex v;
            List<Vertex>[] verticesAddToThis = new List<Vertex>[Vertices.Count];
            List<Vertex>[] verticesAddToPolygon = new List<Vertex>[polygon.Vertices.Count];
            for (int i = 0; i < polygon.Vertices.Count; i++)
                verticesAddToPolygon[i] = new List<Vertex>();
            for (int i = 0; i < Vertices.Count; i++)
            {
                verticesAddToThis[i] = new List<Vertex>();
                for (int j = 0; j < polygon.Vertices.Count; j++)
                {
                    if ((v = this.GetIntersectionPoint(Vertices[i], Vertices[(i + 1) % Vertices.Count], polygon.Vertices[j], polygon.Vertices[(j + 1) % polygon.Vertices.Count])) != null)
                    {
                        verticesAddToThis[i].Add(v);
                        verticesAddToPolygon[j].Add(v);
                    }
                }
            }
            List<Vertex> intersections = new List<Vertex>();
            bool outVertex = false;
            for (int i = 0, j = 0; j < Vertices.Count; i++, j++)
            {
                verticesAddToThis[i].Sort((v1, v2) =>
                {
                    double l1 = this.GetLineLength(Vertices[j], v1);
                    double l2 = this.GetLineLength(Vertices[j], v2);
                    if (l1 < l2) return -1;
                    if (l1 == l2) return 0;
                    return 1;
                });
                foreach (Vertex ve in verticesAddToThis[i])
                {
                    j++;
                    Vertices.Insert(j, ve);
                    if (outVertex)
                    {
                        intersections.Add(ve);
                        outVertex = false;
                    }
                    else
                        outVertex = true;
                }
            }
            for (int i = 0, j = 0; j < polygon.Vertices.Count; i++, j++)
            {
                verticesAddToPolygon[i].Sort((v1, v2) =>
                {
                    double l1 = this.GetLineLength(polygon.Vertices[j], v1);
                    double l2 = this.GetLineLength(polygon.Vertices[j], v2);
                    if (l1 < l2) return -1;
                    if (l1 == l2) return 0;
                    return 1;
                });
                polygon.Vertices.InsertRange(j + 1, verticesAddToPolygon[i]);
                j += verticesAddToPolygon[i].Count;
            }
            List<Vertex> newVertices = new List<Vertex>();
            while (intersections.Count > 0)
            {
                int index = Vertices.FindIndex(ve => ve == intersections[0]);
                Vertex vertex = Vertices[index];
                bool thisList = true;
                newVertices.Add(vertex);
               
                while (true)
                {
                    if (thisList)
                    {
                        index = (index + 1) % Vertices.Count;
                        vertex = Vertices[index];
                        if (vertex.Intersection)
                        {
                            if (vertex == intersections[0])
                                break;
                            intersections.Remove(vertex);
                            thisList = false;
                            index = polygon.Vertices.FindIndex(ve => ve == vertex);
                        }
                    }
                    else
                    {
                        index = (index + 1) % polygon.Vertices.Count;
                        vertex = polygon.Vertices[index];
                        if (vertex.Intersection)
                        {
                            if (vertex == intersections[0])
                                break;
                            intersections.Remove(vertex);
                            thisList = true;
                            index = Vertices.FindIndex(ve => ve == vertex);
                        }
                    }
                    newVertices.Add(vertex);
                }
                intersections.RemoveAt(0);
            }
            Vertices = newVertices;
        }

        private Vertex GetIntersectionPoint(Vertex a, Vertex b, Vertex c, Vertex d)
        {
            double deltaACy = a.Y - c.Y;
            double deltaDCx = d.X - c.X;
            double deltaACx = a.X - c.X;
            double deltaDCy = d.Y - c.Y;
            double deltaBAx = b.X - a.X;
            double deltaBAy = b.Y - a.Y;

            double denominator = deltaBAx * deltaDCy - deltaBAy * deltaDCx;
            double numerator = deltaACy * deltaDCx - deltaACx * deltaDCy;

            if (denominator == 0)
            {
                if (numerator == 0)
                {
                    if (a.X >= c.X && a.X <= d.X)
                    {
                        return a;
                    }
                    else if (c.X >= a.X && c.X <= b.X)
                    {
                        return c;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            double r = numerator / denominator;
            if (r < 0 || r > 1)
            {
                return null;
            }

            double s = (deltaACy * deltaBAx - deltaACx * deltaBAy) / denominator;
            if (s < 0 || s > 1)
            {
                return null;
            }

            return new Vertex(new Point((int)(a.X + r * deltaBAx), (int)(a.Y + r * deltaBAy)), true);
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

        public void MoveVertex(int vertexIndex, Point newPoint)
        {
            Point vector = new Point(newPoint.X - Vertices[vertexIndex].X, newPoint.Y - Vertices[vertexIndex].Y);
            Vertices[vertexIndex].Move(vector.X, vector.Y);
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

        public int IsOnVertices(Point clickedPoint)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i].IsTheSamePoint(clickedPoint))
                    return i;
            }
            return -1;
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
            Vertices.Insert(vertexBeforeIndex + 1, new Vertex(this.GetMiddle(vertexBeforeIndex)));
        }

        public void DeleteVertex(int vertexIndex)
        {
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

        private double GetLineLength(Vertex start, Vertex end)
        {
            return this.GetLineLength(start.Point, end.Point);
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
