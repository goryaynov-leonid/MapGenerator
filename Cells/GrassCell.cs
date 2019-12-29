using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace MapGenerator.Cells
{
    public class GrassCell : Cell
    {
        public GrassCell(int i, int w)
        {
            color = Color.LightGreen;
            I = i;
            X = i / w;
            Y = i % w;
        }
    }
}
