using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public class Edge
    {
        public Vertex Vmax { get; private set; }
        public Vertex Vmin { get; private set; }
        public double X { get; private set; }
        private double tg;

        public Edge(Vertex vmin, Vertex vmax)

        {
            Vmax = vmax;
            Vmin = vmin;
            X = Vmin.X;
            if (Vmax.Y == Vmin.Y)
                tg = 1;
            else
                tg = (double)((double)(Vmax.X - Vmin.X) / (Vmax.Y - Vmin.Y));
        }
        
        public void ActualizeX()
        {
            X = X + tg;
        }
    }
}
