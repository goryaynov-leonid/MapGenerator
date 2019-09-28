using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace MapGenerator.Cells
{
    class MountainCell : Cell
    {
        public MountainCell(int i, int w)
        {
            color = Color.Gray;
            I = i;
            X = i / w;
            Y = i % w;
        }
    }
}
