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
        private static Map map;

        public List<Cell> Cells { get; set; }
        public int W;
        public int H;
        private Map(int h, int w)
        {
            Cells = new List<Cell>();
            H = h;
            W = w;
            for (int i = 0; i < h*w; i++)
            {
                Cells.Add(new GrassCell() { I = i, X = i / h, Y = i % h });
            }
        }

        public static Map GetMap(int h, int w)
        {
            if (map == null)
            {
                map = new Map(h, w);
            }
            return map;
        }

        public void Reset()
        {
            Cells = new List<Cell>();
            for (int i = 0; i < map.H * map.W; i++)
            {
                Cells.Add(new GrassCell() { I = i, X = i / map.H, Y = i % map.W });
            }
        }
    }
}
