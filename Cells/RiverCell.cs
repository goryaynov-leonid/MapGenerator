using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace MapGenerator.Cells
{
    public class RiverCell : Cell
    {
        public RiverCell(int i, int w)
        {
            color = Color.Blue;
            I = i;
            X = i / w;
            Y = i % w;
        }
    }
}
