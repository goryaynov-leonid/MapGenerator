using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MapGenerator.MapBuild;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapGenerator
{
    public partial class Form1 : Form
    {
        Map Map;
        public Form1()
        {
            InitializeComponent();
            Map = Map.GetMap(100, 100);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Map.Reset();
            MapBuilder mapBuilder = new MapBuilder();
            Map = mapBuilder.StartMapBuild(2, 0, 0, ref Map);
            pictureBox1.Image = GetBitmap();
        }

        public Bitmap GetBitmap()
        {
            Bitmap bitmap = new Bitmap(Map.W, Map.H);
            for (int i = 0; i < Map.H; i++)
                for (int j = 0; j < Map.W; j++)
                    bitmap.SetPixel(j, i, Map.Cells[i * Map.H + j].color);
            return bitmap;
        }
    }
}
