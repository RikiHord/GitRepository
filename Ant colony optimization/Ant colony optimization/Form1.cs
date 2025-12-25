using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ant_colony_optimization
{
    public partial class Form1 : Form
    {
        // ---------- Anthill ----------
        class Anthill
        {
            private static Random rand = new Random();
            public Point Location { get; }

            public Anthill()
            {
                Location = new Point(rand.Next(20, 350), rand.Next(20, 350));
            }

            public void Draw(Graphics g)
            {
                g.FillEllipse(Brushes.Red, Location.X - 3, Location.Y - 3, 6, 6);
            }
        }

        // ---------- Fields ----------
        const int COUNT_ANTHILL = 30;
        const int ITERATIONS = 200;
        const double alpha = 1.0;
        const double beta = 0.8;
        const double Q = 200;

        Random random = new Random();

        List<Anthill> anthills = new List<Anthill>();
        List<List<int>> currentPaths = new List<List<int>>();
        List<int> finalPath = new List<int>();

        double[,] distance;
        double[,] pheromone;
        double bestDistance = double.MaxValue;

        // ---------- Constructor ----------
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true; // зменшення мерехтіння
            Paint += Form1_Paint;
        }

        // ---------- Paint ----------
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Black, 10, 10, 360, 360);

            // anthills
            foreach (var a in anthills)
                a.Draw(g);

            // current paths
            foreach (var path in currentPaths)
            {
                for (int i = 0; i < path.Count - 1; i++)
                    g.DrawLine(Pens.LightGray,
                        anthills[path[i]].Location,
                        anthills[path[i + 1]].Location);
            }

            // final path
            if (finalPath.Count > 1)
            {
                Pen p = new Pen(Color.Blue, 2);
                for (int i = 0; i < finalPath.Count - 1; i++)
                    g.DrawLine(p,
                        anthills[finalPath[i]].Location,
                        anthills[finalPath[i + 1]].Location);
            }
        }

        // ---------- Init ----------
        void InitMatrices()
        {
            distance = new double[COUNT_ANTHILL, COUNT_ANTHILL];
            pheromone = new double[COUNT_ANTHILL, COUNT_ANTHILL];

            for (int i = 0; i < COUNT_ANTHILL; i++)
            {
                for (int j = 0; j < COUNT_ANTHILL; j++)
                {
                    if (i == j)
                        distance[i, j] = double.MaxValue;
                    else
                    {
                        distance[i, j] = Math.Sqrt(
                            Math.Pow(anthills[i].Location.X - anthills[j].Location.X, 2) +
                            Math.Pow(anthills[i].Location.Y - anthills[j].Location.Y, 2));
                        pheromone[i, j] = 0.5; // start pheromone level
                    }
                }
            }
        }

        // ---------- Ant ----------
        List<int> RunAnt(int start)
        {
            List<int> path = new List<int> { start };
            int current = start;

            while (path.Count < COUNT_ANTHILL)
            {
                double[] prob = new double[COUNT_ANTHILL];
                double sum = 0;

                for (int i = 0; i < COUNT_ANTHILL; i++)
                {
                    if (!path.Contains(i))
                    {
                        prob[i] = Math.Pow(pheromone[current, i], alpha) *
                                  Math.Pow(Q / distance[current, i], beta);
                        sum += prob[i];
                    }
                }

                double r = random.NextDouble() * sum;
                double acc = 0;

                for (int i = 0; i < COUNT_ANTHILL; i++)
                {
                    acc += prob[i];
                    if (r <= acc)
                    {
                        path.Add(i);
                        current = i;
                        break;
                    }
                }
            }
            return path;
        }

        double PathLength(List<int> path)
        {
            double len = 0;
            for (int i = 0; i < path.Count - 1; i++)
                len += distance[path[i], path[i + 1]];
            return len;
        }

        void UpdatePheromones(List<List<int>> paths)
        {
            // pheromone evaporation
            for (int i = 0; i < COUNT_ANTHILL; i++)
                for (int j = 0; j < COUNT_ANTHILL; j++)
                    pheromone[i, j] *= 0.65;

            foreach (var p in paths)
            {
                double d = PathLength(p);

                if (d < bestDistance)
                {
                    bestDistance = d;
                    finalPath = p.ToList();
                }

                double add = Q / d;
                for (int i = 0; i < p.Count - 1; i++)
                    pheromone[p[i], p[i + 1]] += add;
            }
        }

        // ---------- Optimization ----------
        async Task RunACO()
        {
            for (int iter = 0; iter < ITERATIONS; iter++)
            {
                progressBar1.Value = iter + 1;
                currentPaths.Clear();

                for (int a = 0; a < COUNT_ANTHILL; a++)
                    currentPaths.Add(RunAnt(a));

                UpdatePheromones(currentPaths);

                Invalidate();
                await Task.Delay(30); //async delay for visualization
            }
        }

        // ---------- Button ----------
        private async void button1_Click(object sender, EventArgs e)
        {
            anthills.Clear();
            finalPath.Clear();
            currentPaths.Clear();
            bestDistance = double.MaxValue;
            label1.Text = $"Best Distance: Calculate...";

            button1.Enabled = false;
            progressBar1.Maximum = ITERATIONS;
            progressBar1.Value = 0;

            for (int i = 0; i < COUNT_ANTHILL; i++)
                anthills.Add(new Anthill()); // create anthills

            InitMatrices();
            await RunACO();

            label1.Text = $"Best Distance: {bestDistance:F2}";
            progressBar1.Value = ITERATIONS;
            button1.Enabled = true;
        }
    }
}
