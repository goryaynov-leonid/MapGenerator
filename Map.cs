using System;
using System.Collections.Generic;
using System.Linq;
using MapGenerator.Cells;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator
{
    sealed class Map
    {
        public List<Cell> Cells { get; set; }
        public int W;
        public int H;
        public Map(int h, int w)
        {
            Cells = new List<Cell>();
            H = h;
            W = w;
            for (int i = 0; i < h*w; i++)
            {
                Cells.Add(new GrassCell(i, w));
            }
        }
    }
}
