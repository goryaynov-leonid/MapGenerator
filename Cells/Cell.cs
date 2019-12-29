using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace MapGenerator.Cells
{
    public abstract class Cell
    {
        public Color color;
        public int I { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
