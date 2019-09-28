using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapGenerator.Cells;
using System.Threading.Tasks;

namespace MapGenerator.MapBuild
{
    class MountainLayerBuilder : LayerBuilder
    {
        private Random Random = new Random(Guid.NewGuid().GetHashCode());
        private List<int> patternX = new List<int> { 1, 1, 0, -1, -1, -1, 0, 1 };
        private List<int> patternY = new List<int> { 0, 1, 1, 1, 0, -1, -1, -1 };
        private List<List<double>> probability;
        private List<List<double>> probabilitySum;
        public ref Map BuildLayer(ref Map map, int centersCount, int minSize, int maxSize)
        {
            InitProbability();

            for (int i = 0; i < centersCount; i++)
            {
                Map tempMap = map;

                PutMountainOnMap(ref tempMap, minSize, maxSize);

                map = tempMap;
            }
            return ref map;
        }

        private void PutMountainOnMap(ref Map tempMap, int minSize, int maxSize)
        {
            int curCenter = FindNewCenter(ref tempMap);

            List<(MountainCell, int)> curMountain = new List<(MountainCell, int)>();

            MountainCell MountainCell = new MountainCell(curCenter, tempMap.W);
            curMountain.Add((MountainCell, Random.Next(probability.Count)));
            tempMap.Cells[curCenter] = MountainCell;


            int size = Random.Next(minSize, maxSize);

            for (int j = 0; j < size; j++)
            {
                (MountainCell, int) curCell = GetCurCellToGrow(curMountain, ref tempMap);

                int w = GetNewWay(curCell, ref tempMap);

                int way = (w + 4) % 8;
                int x = curCell.Item1.X + patternX[w];
                int y = curCell.Item1.Y + patternY[w];

                MountainCell newMountainCell = new MountainCell(x * tempMap.W + y, tempMap.W);

                tempMap.Cells[x * tempMap.H + y] = newMountainCell;
                curMountain.Add((newMountainCell, way));
            }
        }

        private int GetNewWay((MountainCell, int) curCell, ref Map tempMap)
        {
            int way;
            double p;
            do
            {
                p = Random.NextDouble();
                way = Array.BinarySearch(probabilitySum[curCell.Item2].ToArray(), p);
                way = (way >= 0) ? way : ~way;
            }
            while (!(Validate(curCell.Item1.X + patternX[way], curCell.Item1.Y + patternY[way], tempMap.H, tempMap.W) &&
                    !(tempMap.Cells[(curCell.Item1.X + patternX[way]) * tempMap.H + curCell.Item1.Y + patternY[way]] is MountainCell)));
            return way;
        }

        private (MountainCell, int) GetCurCellToGrow(List<(MountainCell, int)> curMountain, ref Map tempMap)
        {
            (MountainCell, int) curCell;
            do
            {
                curCell = curMountain[curMountain.Count - 1 - (int)(Random.Next(curMountain.Count) * 0.2)];
            }
            while (Check(curCell.Item1, ref tempMap));
            return curCell;
        }

        private int FindNewCenter(ref Map tempMap)
        {
            int curCenter;
            do
            {
                curCenter = Random.Next(tempMap.Cells.Count);
            }
            while (!(tempMap.Cells[curCenter] is GrassCell));
            return curCenter;
        }

        private bool Check(MountainCell cell, ref Map map)
        {
            for (int i = 0; i < patternX.Count; i++)
            {
                if (Validate(cell.X + patternX[i], cell.Y + patternY[i], map.H, map.W) &&
                    !(map.Cells[(cell.X + patternX[i]) * map.W + cell.Y + patternY[i]] is MountainCell))
                {
                    return false;
                }
            }
            return true;
        }

        private bool Validate(int i, int j, int x, int y)
        {
            return i >= 0 && j >= 0 && i < x && j < y;
        }

        private void InitProbability()
        {
            probability = new List<List<double>>();
            probabilitySum = new List<List<double>>();
            probability.Add(new List<double>() { 0, 1.0 / 16, 1.0 / 8, 3.0 / 16, 1.0 / 4, 3.0 / 16, 1.0 / 8, 1.0 / 16 });
            for (int i = 1; i < probability[0].Count; i++)
            {
                List<double> curProb = new List<double>();
                for (int j = 0; j < probability[0].Count; j++)
                {
                    curProb.Add(probability[0][(probability[0].Count - i + j) % probability[0].Count]);
                }
                probability.Add(curProb);
            }

            for (int i = 0; i < probability.Count; i++)
            {
                probabilitySum.Add(new List<double>() { probability[i][0] });
                for (int j = 1; j < probability[i].Count; j++)
                {
                    probabilitySum[i].Add(probabilitySum[i].Last() + probability[i][j]);
                }
            }
        }

        //func to debug
        private List<Cell> GetNeigh(Cell cell, ref Map map)
        {
            List<Cell> ans = new List<Cell>();
            for (int i = 0; i < 8; i++)
            {
                if (Validate(cell.X + patternX[i], cell.Y + patternY[i], map.H, map.W))
                {
                    ans.Add(map.Cells[(cell.X + patternX[i]) * map.W + cell.Y + patternY[i]]);
                }
            }
            return ans;
        }
    }
}
