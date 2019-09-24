using System;
using System.Collections.Generic;
using System.Linq;
using MapGenerator.Cells;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator.MapBuild
{
    class ForestLayerBuilder : LayerBuilder
    {
        private Random Random = new Random(Guid.NewGuid().GetHashCode());
        private List<int> patternX = new List<int> { 1, -1, 0, 0 };
        private List<int> patternY = new List<int> { 0, 0, 1, -1 };
        public ref Map BuildLayer(ref Map map, int centersCount, int minSize, int maxSize)
        {
            for (int i = 0; i < centersCount; i++)
            {
                int x;
                do
                {
                    x = Random.Next(map.Cells.Count);
                }
                while (map.Cells[x] is ForestCell);

                map.Cells[x] = new ForestCell() { I = x, X = x / map.H, Y = x % map.H };
            }

            int size = Random.Next(minSize, maxSize);
            for (int j = 0; j < size; j++)
            {
                Cell curCell;
                var curForest = map.Cells.Where(i => i is ForestCell).ToList();
                do
                {
                    curCell = curForest[Random.Next(curForest.Count)];
                }
                while (!Check(curCell, ref map));

                int r;
                do
                {
                    r = Random.Next(patternX.Count);
                }
                while (!(Validate(curCell.X + patternX[r], curCell.Y + patternY[r], map.H, map.W) && 
                        !(map.Cells[(curCell.X + patternX[r]) * map.H + curCell.Y + patternY[r]] is ForestCell)));

                int x = curCell.X + patternX[r];
                int y = curCell.Y + patternY[r];

                map.Cells[x * map.H + y] = new ForestCell() { I = x * map.H + y, X = x, Y = y };
            }
            return ref map;
        }

        private bool Check(Cell cell, ref Map map)
        {
            for (int i = 0; i < patternX.Count; i++)
            {
                if (Validate(cell.X + patternX[i], cell.Y + patternY[i], map.H, map.W))
                {
                    if (!(map.Cells[(cell.X + patternX[i]) * map.H + cell.Y + patternY[i]] is ForestCell))
                        return true;
                }
            }
            return false;
        }

        private bool Validate(int i, int j, int x, int y)
        {
            return i >= 0 && j >= 0 && i < x && j < y;
        }
    }
}
