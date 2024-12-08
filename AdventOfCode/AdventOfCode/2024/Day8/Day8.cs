using System.Drawing;

namespace AdventOfCode._2024.Day8
{
    public class Day8
    {
        public int Run(string input, bool useResonantHarmonics = false)
        {
            var nodes = new List<Node>();

            var rows = input.Split("\r\n");
            for (var i = 0; i < rows.Length; i++)
            {
                var columns = rows[i].ToCharArray();
                for (var j = 0; j < columns.Length; j++)
                {
                    nodes.Add(new Node
                    {
                        Frequency = columns[j],
                        Coordinate = new Point
                        {
                            X = j,
                            Y = i
                        },
                        IsAntinode = useResonantHarmonics && columns[j] != '.' // all antennas are antinodes when using resonant harmonics
                    });
                }
            }

            var antennas = nodes.Where(node => node.Frequency != '.');

            foreach (var antenna1 in antennas)
            {
                var matchingAntennas = antennas.Where(antenna => antenna.Frequency == antenna1.Frequency && 
                !(antenna.Coordinate.X == antenna1.Coordinate.X && antenna.Coordinate.Y == antenna1.Coordinate.Y));

                foreach (var antenna2 in matchingAntennas)
                {
                    var xDiff = antenna1.Coordinate.X - antenna2.Coordinate.X;
                    var yDiff = antenna1.Coordinate.Y - antenna2.Coordinate.Y;

                    var antinode1Point = new Point { X = antenna2.Coordinate.X - xDiff, Y = antenna2.Coordinate.Y - yDiff };
                    var antinode1 = nodes.FirstOrDefault(node => node.Coordinate.X == antinode1Point.X && node.Coordinate.Y == antinode1Point.Y);
                    while (antinode1 != null)
                    {
                        if (!antinode1.IsAntinode)
                        {
                            nodes.First(node => node.Coordinate.X == antinode1Point.X && node.Coordinate.Y == antinode1Point.Y).IsAntinode = antinode1.Frequency != antenna1.Frequency;
                        }
                        if (!useResonantHarmonics)
                        {
                            break;
                        }

                        antinode1Point = new Point { X = antinode1.Coordinate.X - xDiff, Y = antinode1.Coordinate.Y - yDiff };
                        antinode1 = nodes.FirstOrDefault(node => node.Coordinate.X == antinode1Point.X && node.Coordinate.Y == antinode1Point.Y);
                    }

                    var antinode2Point = new Point { X = antenna1.Coordinate.X + xDiff, Y = antenna1.Coordinate.Y + yDiff };
                    var antinode2 = nodes.FirstOrDefault(node => node.Coordinate.X == antinode2Point.X && node.Coordinate.Y == antinode2Point.Y);
                    while (antinode2 != null)
                    {
                        if (!antinode2.IsAntinode)
                        {
                            nodes.First(node => node.Coordinate.X == antinode2Point.X && node.Coordinate.Y == antinode2Point.Y).IsAntinode = antinode2.Frequency != antenna1.Frequency;
                        }
                        if (!useResonantHarmonics)
                        {
                            break;
                        }

                        antinode2Point = new Point { X = antinode2.Coordinate.X + xDiff, Y = antinode2.Coordinate.Y + yDiff };
                        antinode2 = nodes.FirstOrDefault(node => node.Coordinate.X == antinode2Point.X && node.Coordinate.Y == antinode2Point.Y);
                    }
                }
            }

            return nodes.Count(node => node.IsAntinode);
        }
    }

    public class Node
    {
        public Point Coordinate;
        public char Frequency;
        public bool IsAntinode;
    }
}