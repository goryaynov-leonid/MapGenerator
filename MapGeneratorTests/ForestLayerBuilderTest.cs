using MapGenerator.MapBuild;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;

namespace MapGeneratorTests
{
    [TestClass]
    public class ForestLayerBuilderTest
    {
        [TestMethod]
        public void BuildLayer_AddSomeForestCellsWithMap10By10_AnyForestCellsWillBeOnMap()
        {
            //arrange
            var map = new MapGenerator.Map(10, 10);
            var builder = new ForestLayerBuilder();

            //act

            map = builder.BuildLayer(ref map, 1, 10, 20);

            //assert

            Debug.Assert(map.Cells.Any(x => x is MapGenerator.Cells.ForestCell));
        }

        [TestMethod]
        public void BuildLayer_AddSomeForestCellsWithMap20By20_AnyForestCellsWillBeOnMap()
        {
            //arrange
            var map = new MapGenerator.Map(20, 20);
            var builder = new ForestLayerBuilder();

            //act

            map = builder.BuildLayer(ref map, 1, 10, 20);

            //assert

            Debug.Assert(map.Cells.Any(x => x is MapGenerator.Cells.ForestCell));
        }
    }
}
