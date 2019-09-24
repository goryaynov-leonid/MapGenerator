using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapGenerator.Cells;
using System.Threading.Tasks;

namespace MapGenerator.MapBuild
{
    interface LayerBuilder
    {
        ref Map BuildLayer(ref Map map, int centersCount, int minSize, int maxSize);
    }
}
