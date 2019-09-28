using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator.MapBuild
{
    class MapBuilder
    {
        private LayerBuilder LayerBuilder;
        public ref Map StartMapBuild(int Forests, int Rivers, int Mountains, ref Map map)
        {
            ref Map curMap = ref map;
            LayerBuilder = new ForestLayerBuilder();
            curMap = LayerBuilder.BuildLayer(ref curMap, Forests, 100, 200);
            LayerBuilder = new RiverLayerBuilder();
            curMap = LayerBuilder.BuildLayer(ref curMap, Rivers, 100, 200);

            return ref curMap;
        }
    }
}
