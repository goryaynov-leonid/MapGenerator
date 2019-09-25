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

                ForestCell forestCell = new ForestCell()
                {
                    I = map.Cells[curCenter].I,
                    X = map.Cells[curCenter].X,
                    Y = map.Cells[curCenter].Y
                };
                curRiver.Add(forestCell);
                tempMap.Cells[curCenter] = forestCell;


                int size = Random.Next(minSize, maxSize);

                for (int j = 0; j < size; j++)
                {
                    Cell curCell;

                    do
                    {
                        curCell = curRiver[Random.Next(curRiver.Count)];
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
                            !(tempMap.Cells[(curCell.X + patternX[r]) * tempMap.H + curCell.Y + patternY[r]] is ForestCell)));

                    int x = curCell.X + patternX[r];
                    int y = curCell.Y + patternY[r];

                    ForestCell newForestCell = new ForestCell() { I = x * map.H + y, X = x, Y = y };

                    tempMap.Cells[x * map.H + y] = newForestCell;
                    curRiver.Add(newForestCell);
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
                for (int j = 0; j < probability[i].Count; j++)
                {
                    probabilitySum[i].Add(probabilitySum[i].Last() + probability[i][j]);
                }
            }
        }
    }
}
