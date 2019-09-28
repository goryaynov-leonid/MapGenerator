using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator.MapUpdate
{
    interface IMapUpdaterStrategy
    {
        void UpdateMap(ref Map map);
    }
}
