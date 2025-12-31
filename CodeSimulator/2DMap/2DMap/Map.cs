using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMap
{
    public class Map
    {
        string[,] grid;

        public Map(string input)
        {
            string[] rows = input.Split(',');
            int height = rows.Length;
            int width = rows[0].Length;
            foreach (var row in rows)
            {
                if (row.Length != width)
                {
                    throw new ArgumentException("All rows must have the same length.");
                }
            }
            
            grid = new string[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    grid[x, y] = rows[y][x].ToString();
                }
            }
        }

        private struct PointInMap
        {
            public int X;
            public int Y;
        }

        public int GetCountMovesBetweenTwoP()
        {
            if (grid == null) return -1;
            
            List<PointInMap> points = new List<PointInMap>();

            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    if (grid[x, y].ToUpper() == "P")
                    {
                        points.Add(new PointInMap { X = x, Y = y });
                    }
                }
            }

            if (points.Count != 2) return -1;

            return Math.Abs(points[1].X - points[0].X) + Math.Abs(points[1].Y - points[0].Y);
        }
    }
}
