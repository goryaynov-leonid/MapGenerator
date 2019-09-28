using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MapGenerator.MapUpdate;
using MapGenerator.MapBuild;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapGenerator
{
    public partial class Form1 : Form
    {
        Map Map;
        List<List<double>> probability;
        List<List<double>> probabilitySum;
        Random Random = new Random(Guid.NewGuid().GetHashCode());
        List<IMapUpdaterStrategy> mapUpdaters = new List<IMapUpdaterStrategy> { new StableMapUpdater(), new DroughtMapUpdater(), new FloodMapUpdater() };
        IMapUpdaterStrategy curMapUpdater = new StableMapUpdater();
        int curState = 0;
        public Form1()
        {
            InitializeComponent();
            InitProbability();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(mapHeight.Text) > 250 || Convert.ToInt32(mapWidth.Text) > 250)
            {
                MessageBox.Show("Too large map");
                return;
            }
            Map = new Map(Convert.ToInt32(mapHeight.Text), Convert.ToInt32(mapWidth.Text));
            MapBuilder mapBuilder = new MapBuilder();
            Map = mapBuilder.StartMapBuild(Convert.ToInt32(forestsCountTextBox.Text), Convert.ToInt32(riversCountTextBox.Text), 
                Convert.ToInt32(mountainsCountTextBox.Text), ref Map);
            pictureBox1.Size = new Size(Map.W, Map.H);
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            curMapUpdater.UpdateMap(ref Map);
            UpdateState();
            pictureBox1.Image = GetBitmap();
        }
        private void UpdateState()
        {
            double p;
            int way;
            p = Random.NextDouble();
            way = Array.BinarySearch(probabilitySum[curState].ToArray(), p);
            way = (way >= 0) ? way : ~way;
            curState = way;
            curMapUpdater = mapUpdaters[curState];
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void InitProbability()
        {
            probability = new List<List<double>>();
            probabilitySum = new List<List<double>>();
            probability.Add(new List<double> { 0.5, 0.25, 0.25 });
            probability.Add(new List<double> { 0.3, 0.7, 0 });
            probability.Add(new List<double> { 0.3, 0.0, 0.7 });
            for (int i = 0; i < probability.Count; i++)
            {
                probabilitySum.Add(new List<double>() { probability[i][0] });
                for (int j = 1; j < probability[i].Count; j++)
                {
                    probabilitySum[i].Add(probabilitySum[i].Last() + probability[i][j]);
                }
            }

        }
    }
}
