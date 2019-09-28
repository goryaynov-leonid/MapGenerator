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
        private List<double> probability = new List<double>() { 0.25, 0.25, 0.25, 0.25 };
        private List<double> probabilitySum = new List<double>();
        public ref Map BuildLayer(ref Map map, int centersCount, int minSize, int maxSize)
        {
            probabilitySum.Add(probability[0]);
            for (int i = 1; i < probability.Count; i++)
            {
                probabilitySum.Add(probabilitySum.Last() + probability[i]);
            }

            for (int i = 0; i < centersCount; i++)
            {
                Map tempMap = map;

                int curCenter;
                do
                {
                    curCenter = Random.Next(tempMap.Cells.Count);
                }
                while (tempMap.Cells[curCenter] is ForestCell);

                List<ForestCell> curForest = new List<ForestCell>();

                ForestCell forestCell = new ForestCell(curCenter, map.W);
                curForest.Add(forestCell);
                tempMap.Cells[curCenter] = forestCell;


                int size = Random.Next(minSize, maxSize);

                for (int j = 0; j < size; j++)
                {
                    ForestCell curCell;

                    do
                    {
                        curCell = curForest[Random.Next(curForest.Count)];
                    }
                    while (!Check(curCell, ref map));

                    int r = 0;
                    double p;
                    do
                    {
                        p = Random.NextDouble();
                        r = Array.BinarySearch(probabilitySum.ToArray(), p);
                        r = (r >= 0) ? r : ~r;
                    }
                    while (!(Validate(curCell.X + patternX[r], curCell.Y + patternY[r], tempMap.H, tempMap.W) &&
                            !(tempMap.Cells[(curCell.X + patternX[r]) * tempMap.W + curCell.Y + patternY[r]] is ForestCell)));

                    int x = curCell.X + patternX[r];
                    int y = curCell.Y + patternY[r];

                    ForestCell newForestCell = new ForestCell(x * map.H + y, map.H);

                    tempMap.Cells[x * map.H + y] = newForestCell;
                    curForest.Add(newForestCell);
                }
                map = tempMap;
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
