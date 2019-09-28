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
        private static Random Random = new Random(Guid.NewGuid().GetHashCode());
        private static List<int> patternX = new List<int> { 1, -1, 0, 0 };
        private static List<int> patternY = new List<int> { 0, 0, 1, -1 };
        private List<double> probability;
        private static List<double> probabilitySum;
        public ref Map BuildLayer(ref Map map, int centersCount, int minSize, int maxSize)
        {
            InitProbability();

            for (int i = 0; i < centersCount; i++)
            {
                Map tempMap = map;

                PutForestOnMap(ref tempMap, minSize, maxSize);
                
                map = tempMap;
            }
            return ref map;
        }
        private void PutForestOnMap(ref Map tempMap, int minSize, int maxSize)
        {

            int curCenter = GetNewCenter(ref tempMap);

            List<ForestCell> curForest = new List<ForestCell>();

            ForestCell forestCell = new ForestCell(curCenter, tempMap.W);
            curForest.Add(forestCell);
            tempMap.Cells[curCenter] = forestCell;


            int size = Random.Next(minSize, maxSize);

            for (int j = 0; j < size; j++)
            {
                ForestCell curCell = GetCellToGrow(curForest, ref tempMap);

                int way = GetNewWay(ref tempMap, curCell);

                int x = curCell.X + patternX[way];
                int y = curCell.Y + patternY[way];

                ForestCell newForestCell = new ForestCell(x * tempMap.W + y, tempMap.W);

                tempMap.Cells[x * tempMap.W + y] = newForestCell;
                curForest.Add(newForestCell);
            }
        }

        public static int GetNewWay(ref Map tempMap, ForestCell curCell)
        {
            int way;
            double p;
            do
            {
                p = Random.NextDouble();
                way = Array.BinarySearch(probabilitySum.ToArray(), p);
                way = (way >= 0) ? way : ~way;
            }
            while (!(Validate(curCell.X + patternX[way], curCell.Y + patternY[way], tempMap.H, tempMap.W) &&
                    !(tempMap.Cells[(curCell.X + patternX[way]) * tempMap.W + curCell.Y + patternY[way]] is ForestCell)));
            return way;
        }

        public static ForestCell GetCellToGrow(List<ForestCell> curForest, ref Map tempMap)
        {
            ForestCell curCell;
            do
            {
                curCell = curForest[Random.Next(curForest.Count)];
            }
            while (!Check(curCell, ref tempMap));
            return curCell;
        }

        private int GetNewCenter(ref Map tempMap)
        {
            int curCenter;
            do
            {
                curCenter = Random.Next(tempMap.Cells.Count);
            }
            while (tempMap.Cells[curCenter] is ForestCell);
            return curCenter;
        }

        private static bool Check(Cell cell, ref Map map)
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

        private static bool Validate(int i, int j, int x, int y)
        {
            return i >= 0 && j >= 0 && i < x && j < y;
        }

        private void InitProbability()
        {
            probability = new List<double>() { 0.25, 0.25, 0.25, 0.25 };
            probabilitySum = new List<double>();
            probabilitySum.Add(probability[0]);
            for (int i = 1; i < probability.Count; i++)
            {
                probabilitySum.Add(probabilitySum.Last() + probability[i]);
            }
        }
    }
}
