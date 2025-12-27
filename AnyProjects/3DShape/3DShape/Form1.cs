using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DShape
{
    public partial class Form1 : Form
    {
        public class Point3D
        {
            public int IndexPoint { get; set; }

            public float X3D { get; set; }
            public float Y3D { get; set; }
            public float Z3D { get; set; }

            public float X { get; set; }
            public float Y { get; set; }

            public int[] ConectedArr { get; set; }

            public Point3D(int indexPoint, float x, float y, float z)
            {
                IndexPoint = indexPoint;
                X3D = x;
                Y3D = y;
                Z3D = z;
            }

            public void DrawPoint(Graphics g)
            {
                g.FillEllipse(Brushes.Red, X - 2, Y - 2, 4, 4);
            }

            public void ConnectPoints(Graphics g, List<Point3D> points)
            {
                if (ConectedArr == null) return;

                foreach (int index in ConectedArr)
                {
                    Point3D targetPoint = points.FirstOrDefault(p => p.IndexPoint == index);
                    if (targetPoint != null)
                    {
                        g.DrawLine(Pens.Black, X, Y, targetPoint.X, targetPoint.Y);
                    }
                }
            }
        }

        const int COUNT_POINTS = 8;
        readonly int COUNT_CONNECTIONS = (int)Math.Round(COUNT_POINTS * 0.2);
        public List<Point3D> points3D = new List<Point3D>();
        static Random rand = new Random();

        float angleX = 0f;
        float angleY = 0f;
        Point lastMouse;

        public void ConnectPoints()
        {
            var usedConnections = new HashSet<(int, int)>();

            foreach (var point in points3D)
            {
                var connections = new List<int>();

                foreach (var candidate in points3D
                    .Where(p => p.IndexPoint != point.IndexPoint)
                    .OrderBy(p => DistanceSquared(point, p)))
                {
                    if (connections.Count >= COUNT_CONNECTIONS)
                        break;

                    int a = point.IndexPoint;
                    int b = candidate.IndexPoint;

                    var key = a < b ? (a, b) : (b, a);

                    if (usedConnections.Contains(key))
                        continue;

                    usedConnections.Add(key);
                    connections.Add(b);
                }

                point.ConectedArr = connections.ToArray();
            }
        }

        private static float DistanceSquared(Point3D a, Point3D b)
        {
            float dx = a.X3D - b.X3D;
            float dy = a.Y3D - b.Y3D;
            float dz = a.Z3D - b.Z3D;
            return dx * dx + dy * dy + dz * dz;
        }

        public void InitializePoints()
        {
            for (int indexPoint = 0; indexPoint < COUNT_POINTS; indexPoint++)
            {
                points3D.Add(new Point3D(indexPoint, rand.Next(10, 300), rand.Next(10, 300), rand.Next(-50, 50)));
            }
        }

        public void UpdateProjection()
        {
            float cosX = (float)Math.Cos(angleX);
            float sinX = (float)Math.Sin(angleX);
            float cosY = (float)Math.Cos(angleY);
            float sinY = (float)Math.Sin(angleY);

            float distance = 600f;
            int cx = pb_forShape.Width / 2;
            int cy = pb_forShape.Height / 2;

            foreach (var p in points3D)
            {
                // X rotation
                float y1 = p.Y3D * cosX - p.Z3D * sinX;
                float z1 = p.Y3D * sinX + p.Z3D * cosX;

                // Y rotation
                float x2 = p.X3D * cosY + z1 * sinY;
                float z2 = -p.X3D * sinY + z1 * cosY;

                float scale = distance / (distance + z2);

                p.X = cx + x2 * scale;
                p.Y = cy + y1 * scale;
            }
        }

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;

            InitializePoints();
            ConnectPoints();
        }

        private void pb_forShape_Paint(object sender, PaintEventArgs e)
        {
            UpdateProjection();

            foreach (var point in points3D)
            {
                point.ConnectPoints(e.Graphics, points3D);
            }

            foreach (var point in points3D)
            {
                point.DrawPoint(e.Graphics);
            }
        }

        private void pb_forShape_MouseDown(object sender, MouseEventArgs e)
        {
            lastMouse = e.Location;
        }

        private void pb_forShape_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                angleY += (e.X - lastMouse.X) * 0.01f;
                angleX += (e.Y - lastMouse.Y) * 0.01f;
                lastMouse = e.Location;
                pb_forShape.Invalidate();
            }
        }
    }
}
