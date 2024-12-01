using System.Drawing;

namespace AdventOfCode._2023.Day18
{
    public class Day18_Part1
    {
        public int Run(string input)
        {
            var coordinates = new List<Point> { new(0, 0) };

            var trenchLength = 0;
            foreach (var line in input.Split("\r\n"))
            {
                var parts = line.Split(' ');

                var direction = parts[0];
                var distance = int.Parse(parts[1]);

                var x = direction == "L" ? coordinates.Last().X - distance
                : direction == "R" ? coordinates.Last().X + distance
                : coordinates.Last().X;

                var y = direction == "U" ? coordinates.Last().Y + distance
                    : direction == "D" ? coordinates.Last().Y - distance
                    : coordinates.Last().Y;

                coordinates.Add(new(x, y));

                trenchLength += distance;
            }

            coordinates = coordinates.Distinct().ToList();

            // find area using shoelace method
            var running = 0;
            for (var i = 0; i < coordinates.Count; i++)
            {
                var next = i == coordinates.Count - 1 ? 0 : i + 1;

                var x1 = coordinates[i].X;
                var x2 = coordinates[next].X;

                var y1 = coordinates[i].Y;
                var y2 = coordinates[next].Y;

                running += (x1 * y2) - (x2 * y1);
            }
            var area = Math.Abs(running) / 2;

            return area + (trenchLength / 2) + 1;
        }
    }
}
