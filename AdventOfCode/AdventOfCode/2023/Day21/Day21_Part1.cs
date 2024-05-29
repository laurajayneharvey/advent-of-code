using System.Drawing;

namespace AdventOfCode._2023.Day21
{
    public class Plot
    {
        public Point Coordinate;
        public bool Occupied = false;
    }

    public class Day21_Part1
    {
        public int Run(string input, int steps)
        {
            var plots = new List<Plot>();
            var rows = input.Split("\r\n");
            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var row = rows[rowIndex];
                for (var colIndex = 0; colIndex < row.ToCharArray().Length; colIndex++)
                {
                    if (row[colIndex] != '#')
                    {
                        plots.Add(new Plot
                        {
                            Coordinate = new Point(colIndex, rowIndex),
                            Occupied = row[colIndex] == 'S'
                        });
                    }
                }
            }

            for (var i = 0; i < steps; i++)
            {
                // pick up currently occupied
                var plotsToAssess = plots.Where(p => p.Occupied).ToList();

                // reset occupied
                plots = plots.Select(p =>
                {
                    p.Occupied = false;
                    return p;
                }).ToList();

                foreach (var plotToAssess in plotsToAssess)
                {
                    var up = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plotToAssess.Coordinate.X &&
                    p.Coordinate.Y == plotToAssess.Coordinate.Y + 1);
                    if (up != null)
                    {
                        up.Occupied = true;
                    }

                    var down = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plotToAssess.Coordinate.X &&
                    p.Coordinate.Y == plotToAssess.Coordinate.Y - 1);
                    if (down != null)
                    {
                        down.Occupied = true;
                    }

                    var left = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plotToAssess.Coordinate.X - 1 &&
                    p.Coordinate.Y == plotToAssess.Coordinate.Y);
                    if (left != null)
                    {
                        left.Occupied = true;
                    }

                    var right = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plotToAssess.Coordinate.X + 1 &&
                    p.Coordinate.Y == plotToAssess.Coordinate.Y);
                    if (right != null)
                    {
                        right.Occupied = true;
                    }
                }
            }

            return plots.Count(p => p.Occupied);
        }
    }
}
