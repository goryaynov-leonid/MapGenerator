using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapGenerator.Cells;
using System.Threading.Tasks;

namespace MapGenerator.MapBuild
{
    class RiverLayerBuilder : LayerBuilder
    {
        private Random Random = new Random(Guid.NewGuid().GetHashCode());
        private List<int> patternX = new List<int> { 1, 1, 0, -1, -1, -1, 0, 1 };
        private List<int> patternY = new List<int> { 0, 1, 1, 1, 0, -1, -1, -1 };
        private List<List<double>> probability = new List<List<double>>();
        private List<List<double>> probabilitySum = new List<List<double>>();
        public ref Map BuildLayer(ref Map map, int centersCount, int minSize, int maxSize)
        {
            InitProbability();

            for (int i = 0; i < centersCount; i++)
            {
                Map tempMap = map;

                int curCenter;
                do
                {
                    curCenter = Random.Next(tempMap.Cells.Count);
                }
                while (!(tempMap.Cells[curCenter] is GrassCell));

                List<RiverCell> curRiver = new List<RiverCell>();

                RiverCell riverCell = new RiverCell(curCenter, tempMap.W);
                curRiver.Add(riverCell);
                tempMap.Cells[curCenter] = riverCell;


                int size = Random.Next(minSize, maxSize);

                int way = Random.Next(probability.Count);

                for (int j = 0; j < size; j++)
                {
                    if (CheckToFinishRiver(curRiver.Last(), ref tempMap))
                    {
                        break;
                    }

                    RiverCell curCell = curRiver.Last();

                    int r;
                    double p;
                    do
                    {
                        p = Random.NextDouble();
                        r = Array.BinarySearch(probabilitySum[way].ToArray(), p);
                        r = (r >= 0) ? r : ~r;
                    }
                    while (!(Validate(curCell.X + patternX[r], curCell.Y + patternY[r], tempMap.H, tempMap.W) &&
                            !(tempMap.Cells[(curCell.X + patternX[r]) * tempMap.H + curCell.Y + patternY[r]] is RiverCell)));
                    way = (r + 4) % 8;
                    int x = curCell.X + patternX[r];
                    int y = curCell.Y + patternY[r];

                    RiverCell newRiverCell = new RiverCell(x * map.W + y, map.W);

                    tempMap.Cells[x * map.H + y] = newRiverCell;
                    curRiver.Add(newRiverCell);
                }
                map = tempMap;
            }
            return ref map;
        }

        private bool CheckToFinishRiver(RiverCell cell, ref Map map)
        {
            for (int i = 0; i < patternX.Count; i++)
            {
                if (Validate(cell.X + patternX[i], cell.Y + patternY[i], map.H, map.W) && 
                    !(map.Cells[(cell.X + patternX[i]) * map.W + cell.Y + patternY[i]] is RiverCell))
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
            probability.Add(new List<double>() { 0, 1.0 / 16, 1.0 / 8, 3.0 / 16, 1.0 / 4, 3.0 / 16, 1.0 / 8, 1.0 / 16 });
            probability.Add(new List<double>() { 1.0 / 16, 0, 1.0 / 16, 1.0 / 8, 3.0 / 16, 1.0 / 4, 3.0 / 16, 1.0 / 8 });
            probability.Add(new List<double>() { 1.0 / 8, 1.0 / 16, 0, 1.0 / 16, 1.0 / 8, 3.0 / 16, 1.0 / 4, 3.0 / 16 });
            probability.Add(new List<double>() { 3.0 / 16, 1.0 / 8, 1.0 / 16, 0, 1.0 / 16, 1.0 / 8, 3.0 / 16, 1.0 / 4 });
            probability.Add(new List<double>() { 1.0 / 4, 3.0 / 16, 1.0 / 8, 1.0 / 16, 0, 1.0 / 16, 1.0 / 8, 3.0 / 16 });
            probability.Add(new List<double>() { 3.0 / 16, 1.0 / 4, 3.0 / 16, 1.0 / 8, 1.0 / 16, 0, 1.0 / 16, 1.0 / 8 });
            probability.Add(new List<double>() { 1.0 / 8, 3.0 / 16, 1.0 / 4, 3.0 / 16, 1.0 / 8, 1.0 / 16, 0, 1.0 / 16 });
            probability.Add(new List<double>() { 1.0 / 16, 1.0 / 8, 3.0 / 16, 1.0 / 4, 3.0 / 16, 1.0 / 8, 1.0 / 16, 0 });
            for (int i = 0; i < probability.Count; i++)
            {
                probabilitySum.Add(new List<double>() { probability[i][0] });
                for (int j = 1; j < probability[i].Count; j++)
                {
                    probabilitySum[i].Add(probabilitySum[i].Last() + probability[i][j]);
                }
            }
        }
    }
}
