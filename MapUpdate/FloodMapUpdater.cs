using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapGenerator.Cells;
using MapGenerator.MapBuild;
using System.Threading.Tasks;

namespace MapGenerator.MapUpdate
{
    class FloodMapUpdater : IMapUpdaterStrategy
    {
        private static List<int> patternXForest = new List<int> { 1, -1, 0, 0 };
        private static List<int> patternYForest = new List<int> { 0, 0, 1, -1 };
        private static List<int> patternXRiver = new List<int> { 1, 1, 0, -1, -1, -1, 0, 1 };
        private static List<int> patternYRiver = new List<int> { 0, 1, 1, 1, 0, -1, -1, -1 };

        private Random Random = new Random(Guid.NewGuid().GetHashCode());
        public void UpdateMap(ref Map map)
        {
            AddForestCells(ref map);
            AddRiverCells(ref map);
        }

        private void AddForestCells(ref Map map)
        {
            List<ForestCell> curForest = map.Cells.Where(cell => cell is ForestCell).ToList().ConvertAll(cell => (ForestCell)cell);
            int growCount = curForest.Count;

            for (int i = 0; i < growCount * 0.05; i++)
            {
                ForestCell growCell = ForestLayerBuilder.GetCellToGrow(curForest, ref map);

                int way = ForestLayerBuilder.GetNewWay(ref map, growCell);

                int x = growCell.X + patternXForest[way];
                int y = growCell.Y + patternYForest[way];

                ForestCell newForestCell = new ForestCell(x * map.W + y, map.W);
                map.Cells[newForestCell.I] = newForestCell;
                curForest.Add(newForestCell);
            }
        }
        private void AddRiverCells(ref Map map)
        {
            List<RiverCell> curRiver = map.Cells.Where(cell => cell is RiverCell).ToList().ConvertAll(cell => (RiverCell)cell);
            int growCount = curRiver.Count;

            for (int i = 0; i < growCount * 0.05; i++)
            {
                RiverCell growCell;

                do
                {
                    growCell = curRiver[Random.Next(curRiver.Count)];
                }
                while (RiverLayerBuilder.CheckToFinishRiver(growCell, ref map));

                int way = RiverLayerBuilder.GetNewWay((FindFreeCell(growCell, ref map) + 4) % 8, growCell, ref map);

                int x = growCell.X + patternXRiver[way];
                int y = growCell.Y + patternYRiver[way];

                RiverCell newRiverCell = new RiverCell(x * map.W + y, map.W);
                map.Cells[newRiverCell.I] = newRiverCell;
                curRiver.Add(newRiverCell);
            }
        }

        private int FindFreeCell(RiverCell riverCell, ref Map map)
        {
            for (int i = 0; i < patternXRiver.Count; i++)
            {
                if (RiverLayerBuilder.Validate(riverCell.X + patternXRiver[i], riverCell.Y + patternYRiver[i], map.H, map.W) &&
                    !(map.Cells[(riverCell.X + patternXRiver[i]) * map.W + riverCell.Y + patternYRiver[i]] is RiverCell))
                {
                    return i;
                }
            }
            return Random.Next(patternXForest.Count);
        }
    }
}
