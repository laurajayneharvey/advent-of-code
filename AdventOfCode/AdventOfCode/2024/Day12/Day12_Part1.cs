using System.Drawing;

namespace AdventOfCode._2024.Day12
{
    public class Day12_Part1
    {
        public int Run(string input, bool useDistinct = false)
        {
            var plots = GetPlots(input);

            MarkWithGroupIndex(plots);

            var grouped = plots.GroupBy(plot => plot.GroupIndex);

            var areas = grouped.Select(grouped => (grouped.Key, grouped.Count()));
            var perimeters = grouped.Select(group => (group.Key, group.Sum(x => 4 - x.NextTo.Count)));
            var prices = grouped.Select(group => group.Count() * group.Sum(x => 4 - x.NextTo.Count));

            return prices.Sum();
        }

        private static void MarkWithGroupIndex(List<Plot> plots)
        {
            var groupIndex = 0;
            while (plots.Any(x => x.GroupIndex == null))
            {
                var plot = plots.First(x => x.GroupIndex == null);
                Mark(plot, groupIndex);
                groupIndex++;
            }
        }

        private static void Mark(Plot plot, int groupIndex)
        {
            plot.GroupIndex = groupIndex;

            if (plot.NextTo.Count == 0 || plot.NextTo.All(x => x.GroupIndex != null))
            {
                return;
            }
            plot.NextTo.Where(x => x.GroupIndex == null).ToList().ForEach(x => Mark(x, groupIndex));
        }

        private static List<Plot> GetPlots(string input)
        {
            var rows = input.Split("\r\n");
            var plots = new List<Plot>();
            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < rows[0].Length; columnIndex++)
                {
                    plots.Add(new Plot
                    {
                        Coordinate = new Point { X = columnIndex, Y = rowIndex },
                        Plant = rows[rowIndex][columnIndex].ToString()
                    });
                }
            }

            foreach (var plot in plots)
            {
                var above = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plot.Coordinate.X &&
                    p.Coordinate.Y == plot.Coordinate.Y - 1 &&
                    p.Plant == plot.Plant
                );
                if (above != null)
                {
                    plot.NextTo.Add(above);
                }

                var below = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plot.Coordinate.X &&
                    p.Coordinate.Y == plot.Coordinate.Y + 1 &&
                    p.Plant == plot.Plant
                );
                if (below != null)
                {
                    plot.NextTo.Add(below);
                }

                var left = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plot.Coordinate.X - 1 &&
                    p.Coordinate.Y == plot.Coordinate.Y &&
                    p.Plant == plot.Plant
                );
                if (left != null)
                {
                    plot.NextTo.Add(left);
                }

                var right = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plot.Coordinate.X + 1 &&
                    p.Coordinate.Y == plot.Coordinate.Y &&
                    p.Plant == plot.Plant
                );
                if (right != null)
                {
                    plot.NextTo.Add(right);
                }
            }

            return plots;
        }
    }

    public class Plot
    {
        public Point Coordinate { get; set; }
        public string Plant { get; set; } = string.Empty;
        public List<Plot> NextTo { get; set; } = [];
        public int? GroupIndex { get; set; }
    }
}
