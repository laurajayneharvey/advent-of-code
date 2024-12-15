using System.Drawing;

namespace AdventOfCode._2024.Day12
{
    public class Day12
    {
        public int Run(string input, bool part2 = false)
        {
            var plots = GetPlots(input);

            MarkWithGroupIndex(plots);

            var grouped = plots.GroupBy(plot => plot.GroupIndex);

            if (part2)
            {
                return grouped.Select(group => group.Count() * group.Sum(x => x.CornerCount)).Sum();
            }

            return grouped.Select(group => group.Count() * group.Sum(x => 4 - x.NextTo.Count)).Sum();
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
                var north = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plot.Coordinate.X &&
                    p.Coordinate.Y == plot.Coordinate.Y - 1 &&
                    p.Plant == plot.Plant
                );
                var south = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plot.Coordinate.X &&
                    p.Coordinate.Y == plot.Coordinate.Y + 1 &&
                    p.Plant == plot.Plant
                );
                var west = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plot.Coordinate.X - 1 &&
                    p.Coordinate.Y == plot.Coordinate.Y &&
                    p.Plant == plot.Plant
                );
                var east = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plot.Coordinate.X + 1 &&
                    p.Coordinate.Y == plot.Coordinate.Y &&
                    p.Plant == plot.Plant
                );

                var northwest = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plot.Coordinate.X - 1 &&
                    p.Coordinate.Y == plot.Coordinate.Y - 1 &&
                    p.Plant == plot.Plant
                );
                var northeast = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plot.Coordinate.X + 1 &&
                    p.Coordinate.Y == plot.Coordinate.Y - 1 &&
                    p.Plant == plot.Plant
                );
                var southwest = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plot.Coordinate.X - 1 &&
                    p.Coordinate.Y == plot.Coordinate.Y + 1 &&
                    p.Plant == plot.Plant
                );
                var southeast = plots.FirstOrDefault(p =>
                    p.Coordinate.X == plot.Coordinate.X + 1 &&
                    p.Coordinate.Y == plot.Coordinate.Y + 1 &&
                    p.Plant == plot.Plant
                );

                var cornerCount = 0;// side count == corner count
                if (HasCorner(plot, north, west, northwest))
                {
                    cornerCount++;
                }
                if (HasCorner(plot, north, east, northeast))
                {
                    cornerCount++;
                }
                if (HasCorner(plot, south, west, southwest))
                {
                    cornerCount++;
                }
                if (HasCorner(plot, south, east, southeast))
                {
                    cornerCount++;
                }
                plot.CornerCount = cornerCount;

                if (north != null)
                {
                    plot.NextTo.Add(north);
                }
                if (south != null)
                {
                    plot.NextTo.Add(south);
                }
                if (west != null)
                {
                    plot.NextTo.Add(west);
                }
                if (east != null)
                {
                    plot.NextTo.Add(east);
                }
            }

            return plots;
        }

        private static bool HasCorner(Plot current, Plot? northOrSouth = null, Plot? westOrEast = null, Plot? diagonal = null)
        {
            // examples below are all for NW check from a plant A

            //A
            if (northOrSouth == null && westOrEast == null)
            {
                return true;
            }

            //XA    AA
            if (northOrSouth == null && westOrEast?.Plant != current.Plant)
            {
                return true;
            }

            //X     A
            //A     A
            if (westOrEast == null && northOrSouth?.Plant != current.Plant)
            {
                return true;
            }

            //XX    AX      XA      AA
            //AA    AA      XA      XA
            if (northOrSouth?.Plant != westOrEast?.Plant) // diagonals don't match
            {
                return false;
            }

            //AA
            //AA
            if (northOrSouth?.Plant == current.Plant && diagonal?.Plant == current.Plant)
            {
                return false;
            }

            //AX    XX      XA
            //XA    XA      AA
            return true;
        }
    }

    public class Plot
    {
        public Point Coordinate { get; set; }
        public string Plant { get; set; } = string.Empty;
        public List<Plot> NextTo { get; set; } = [];
        public int? GroupIndex { get; set; }
        public int CornerCount { get; set; } = 0;
    }
}
