using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace MapGenerator.Cells
{
    public class ForestCell : Cell
    {
        public ForestCell(int i, int w)
        {
            color = Color.DarkGreen;
            I = i;
            X = i / w;
            Y = i % w;
        }
    }
}
