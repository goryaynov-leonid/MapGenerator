﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapGenerator.Cells;
using System.Threading.Tasks;

namespace MapGenerator.MapBuild
{
    class RiverLayerBuilder : LayerBuilder
    {
        private static Random Random = new Random(Guid.NewGuid().GetHashCode());
        private static List<int> patternX = new List<int> { 1, 1, 0, -1, -1, -1, 0, 1 };
        private static List<int> patternY = new List<int> { 0, 1, 1, 1, 0, -1, -1, -1 };
        private List<List<double>> probability;
        private static List<List<double>> probabilitySum;
        public ref Map BuildLayer(ref Map map, int centersCount, int minSize, int maxSize)
        {
            InitProbability();

            int startWay = Random.Next(probability.Count);

            for (int i = 0; i < centersCount; i++)
            {
                Map tempMap = map;

                PutRiverOnMap(ref tempMap, minSize, maxSize, startWay);
                
                map = tempMap;
            }
            return ref map;
        }

        private void PutRiverOnMap(ref Map tempMap, int minSize, int maxSize, int startWay)
        {
            int curCenter = GetNewCenter(ref tempMap);
            

            List<RiverCell> curRiver = new List<RiverCell>();

            RiverCell riverCell = new RiverCell(curCenter, tempMap.W);
            curRiver.Add(riverCell);
            tempMap.Cells[curCenter] = riverCell;


            int size = Random.Next(minSize, maxSize);

            int way = startWay;

            for (int j = 0; j < size; j++)
            {
                if (CheckToFinishRiver(curRiver.Last(), ref tempMap))
                {
                    break;
                }

                RiverCell curCell = curRiver.Last();

                int w = GetNewWay(way, curCell, ref tempMap);

                way = (w + 4) % 8;
                int x = curCell.X + patternX[w];
                int y = curCell.Y + patternY[w];

                RiverCell newRiverCell = new RiverCell(x * tempMap.W + y, tempMap.W);

                tempMap.Cells[x * tempMap.H + y] = newRiverCell;
                curRiver.Add(newRiverCell);
            }
        }

        public static int GetNewWay(int oldWay, RiverCell curCell, ref Map tempMap)
        {
            int way;
            double p;
            do
            {
                p = Random.NextDouble();
                way = Array.BinarySearch(probabilitySum[oldWay].ToArray(), p);
                way = (way >= 0) ? way : ~way;
            }
            while (!(Validate(curCell.X + patternX[way], curCell.Y + patternY[way], tempMap.H, tempMap.W) &&
                    !(tempMap.Cells[(curCell.X + patternX[way]) * tempMap.H + curCell.Y + patternY[way]] is RiverCell)));
            return way;
        }

        private int GetNewCenter(ref Map tempMap)
        {
            int curCenter;
            do
            {
                curCenter = Random.Next(tempMap.Cells.Count);
            }
            while (!(tempMap.Cells[curCenter] is GrassCell));
            return curCenter;
        }

        public static bool CheckToFinishRiver(RiverCell cell, ref Map map)
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

        public static bool Validate(int i, int j, int x, int y)
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

        public static List<Cell> GetNeigh(Cell cell, ref Map map)
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
