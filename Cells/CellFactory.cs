using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator.Cells
{
    class CellFactory
    {
        public Dictionary<string, Cell> CellCollection { get; }
        public CellFactory()
        {
            CellCollection.Add("Grass", new GrassCell());
            CellCollection.Add("Forest", new ForestCell());
            CellCollection.Add("Mountain", new MountainCell());
            CellCollection.Add("River", new RiverCell());
        }
    }
}
