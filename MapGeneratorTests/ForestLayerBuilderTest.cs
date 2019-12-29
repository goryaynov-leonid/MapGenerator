using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapGenerator.MapBuild;
using System.Diagnostics;
using System.Linq;

namespace MapGeneratorTests
{
    [TestClass]
    public class ForestLayerBuilderTest
    {
        [TestMethod]
        public void BuildLayer_AddSomeForestCells_AnyForestCellsWillBeOnMap()
        {
            //arrange
            var map = new MapGenerator.Map(10, 10);
            var builder = new ForestLayerBuilder();

            //act

            map = builder.BuildLayer(ref map, 1, 10, 20);

            //assert

            Debug.Assert(map.Cells.Count(x => x is MapGenerator.Cells.ForestCell) > 0);
        }
    }
}
