using System.Drawing;

namespace AdventOfCode._2024.Day6
{
    public static class Day6
    {
        public static List<Position> GetPositions(string input)
        {
            var positions = new List<Position>();

            var rows = input.Split("\r\n");
            for (var i = 0; i < rows.Length; i++)
            {
                var columns = rows[i].ToCharArray();
                for (var j = 0; j < columns.Length; j++)
                {
                    positions.Add(new Position
                    {
                        Type = columns[j],
                        Coordinate = new Point
                        {
                            X = j,
                            Y = i
                        }
                    });
                }
            }

            return positions;
        }

        public static List<Position> GetPath(List<Position> positions)
        {
            while (true)
            {
                var current = positions.FirstOrDefault(item => !item.VisitedDirections.Any() && (item.Type == '<' || item.Type == '>' || item.Type == '^' || item.Type == 'v'));

                if (positions.Any(x => x.VisitedDirections.Count(y => y == 'N') > 1)
                    || positions.Any(x => x.VisitedDirections.Count(y => y == 'E') > 1)
                    || positions.Any(x => x.VisitedDirections.Count(y => y == 'S') > 1)
                    || positions.Any(x => x.VisitedDirections.Count(y => y == 'W') > 1))
                {
                    positions.First().Infinite = true;
                    break;
                }

                if (current == null)
                {
                    break;
                }

                if (current.Type == '^')
                {
                    GoNorth(positions, current);
                }
                else if (current.Type == '>')
                {
                    GoEast(positions, current);
                }
                else if (current.Type == 'v')
                {
                    GoSouth(positions, current);
                }
                else if (current.Type == '<')
                {
                    GoWest(positions, current);
                }
            }

            return positions;
        }

        private static void GoNorth(List<Position> positions, Position? current)
        {
            while (true && current != null)
            {
                positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).VisitedDirections.Add('N');
                var next = positions.FirstOrDefault(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y - 1);
                if (next == null)
                {
                    // reached the edge
                    current = next;
                    break;
                }
                else if (next?.Type == '#')
                {
                    // reached an obstacle
                    break;
                }
                else
                {
                    // keep travelling
                    current = next;
                }
            }

            if (current != null)
            {
                // turn right to go east
                positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).Type = '>';
                positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).VisitedDirections = [];
            }
        }

        private static void GoEast(List<Position> positions, Position? current)
        {
            while (true && current != null)
            {
                positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).VisitedDirections.Add('E');
                var next = positions.FirstOrDefault(item => item.Coordinate.X == current.Coordinate.X + 1 && item.Coordinate.Y == current.Coordinate.Y);
                if (next == null)
                {
                    // reached the edge
                    current = next;
                    break;
                }
                else if (next?.Type == '#')
                {
                    // reached an obstacle
                    break;
                }
                else
                {
                    // keep travelling
                    current = next;
                }
            }

            if (current != null)
            {
                // turn right to go south
                positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).Type = 'v';
                positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).VisitedDirections = [];
            }
        }

        private static void GoSouth(List<Position> positions, Position? current)
        {
            while (true && current != null)
            {
                positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).VisitedDirections.Add('S');
                var next = positions.FirstOrDefault(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y + 1);
                if (next == null)
                {
                    // reached the edge
                    current = next;
                    break;
                }
                else if (next?.Type == '#')
                {
                    // reached an obstacle
                    break;
                }
                else
                {
                    // keep travelling
                    current = next;
                }
            }

            if (current != null)
            {
                // turn right to go west
                positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).Type = '<';
                positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).VisitedDirections = [];
            }
        }

        private static void GoWest(List<Position> positions, Position? current)
        {
            while (true && current != null)
            {
                positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).VisitedDirections.Add('W');
                var next = positions.FirstOrDefault(item => item.Coordinate.X == current.Coordinate.X - 1 && item.Coordinate.Y == current.Coordinate.Y);
                if (next == null)
                {
                    // reached the edge
                    current = next;
                    break;
                }
                else if (next?.Type == '#')
                {
                    // reached an obstacle
                    break;
                }
                else
                {
                    // keep travelling
                    current = next;
                }
            }

            if (current != null)
            {
                // turn right to go north
                positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).Type = '^';
                //var directions = positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).VisitedDirections;
                //directions.RemoveAt(directions.Count - 1);
                //positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).VisitedDirections = directions;
                positions.First(item => item.Coordinate.X == current.Coordinate.X && item.Coordinate.Y == current.Coordinate.Y).VisitedDirections = [];
            }
        }
    }

    public class Position
    {
        public Point Coordinate;
        public char Type;
        public List<char> VisitedDirections = [];
        public bool Infinite = false;
    }
}
