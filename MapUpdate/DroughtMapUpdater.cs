using System;
using System.Collections.Generic;
using System.Linq;
using MapGenerator.Cells;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator.MapUpdate
{
    class DroughtMapUpdater : IMapUpdaterStrategy
    {
        private Random Random = new Random(Guid.NewGuid().GetHashCode());
        public void UpdateMap(ref Map map)
        {
            RemoveRiverCells(ref map);
            RemoveForestCells(ref map);
        }

        void RemoveRiverCells(ref Map map)
        {
            List<Cell> riverCells = map.Cells.Where(cell => cell is RiverCell).ToList();
            for (int i = 0; i < riverCells.Count * 0.05; i++)
            {
                int ind = Random.Next(riverCells.Count);
                Cell curCell = riverCells[ind];
                riverCells.RemoveAt(ind);
                map.Cells[curCell.I] = new GrassCell(curCell.I, map.W);
            }
        }

        void RemoveForestCells(ref Map map)
        {
            List<Cell> forestCells = map.Cells.Where(cell => cell is ForestCell).ToList();
            for (int i = 0; i < forestCells.Count * 0.05; i++)
            {
                int ind = Random.Next(forestCells.Count);
                Cell curCell = forestCells[ind];
                forestCells.RemoveAt(ind);
                map.Cells[curCell.I] = new GrassCell(curCell.I, map.W);
            }
        }
    }
}
