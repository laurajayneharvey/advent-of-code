namespace AdventOfCode._2023.Day16
{
    public class Coordinate(int x, int y, char symbol)
    {
        public int X = x;
        public int Y = y;
        public char Symbol = symbol;
        public bool VisitedFromLeft;
        public bool VisitedFromRight;
        public bool VisitedFromUp;
        public bool VisitedFromDown;
        public bool Energised => (X == 0 && Y == 0) || VisitedFromLeft || VisitedFromRight || VisitedFromUp || VisitedFromDown;
    }

    public class Path
    {
        public Coordinate? CurrentCoordinate;
        public char CurrentDirection;
    }

    public class Day16_Part1
    {
        public int Run(string input)
        {
            var coordinates = GetCoordinates(input);

            var initialCoordinate = coordinates[0];
            var initialDirection = initialCoordinate.Symbol == '|' || initialCoordinate.Symbol == '\\' ? 'D' : 'R';
            var paths = new List<Path>
            {
                new() { CurrentCoordinate = initialCoordinate, CurrentDirection = initialDirection }
            };

            TraverseLayout(coordinates, paths);

            return coordinates.Count(c => c.Energised);
        }

        private static List<Coordinate> GetCoordinates(string input)
        {
            var rows = input.Split("\r\n");
            var rowsLength = rows.Length;
            var columnsLength = rows[0].Length;
            var coordinates = new List<Coordinate>();
            for (var rowIndex = 0; rowIndex < rowsLength; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < columnsLength; columnIndex++)
                {
                    coordinates.Add(new Coordinate(columnIndex, rowIndex, rows[rowIndex][columnIndex]));
                }
            }

            return coordinates;
        }

        private static void TraverseLayout(List<Coordinate> coordinates, List<Path> paths)
        {
            while (paths.Count > 0)
            {
                var path = paths.Last();
                Coordinate? newCoordinate = GetNewCoordinate(coordinates, path);
                if (newCoordinate == null || IsRepeatingPath(newCoordinate, path)) // outside of coordinate system or repeating
                {
                    paths.RemoveAt(paths.Count - 1);
                    continue;
                }

                var newDirection = path.CurrentDirection;
                switch (newCoordinate.Symbol)
                {
                    case '-':
                        if (path.CurrentDirection == 'U' || path.CurrentDirection == 'D')
                        {
                            newDirection = 'L';
                            paths.Add(new Path { CurrentCoordinate = newCoordinate, CurrentDirection = 'R' });
                        }
                        break;
                    case '|':
                        if (path.CurrentDirection == 'L' || path.CurrentDirection == 'R')
                        {
                            newDirection = 'U';
                            paths.Add(new Path { CurrentCoordinate = newCoordinate, CurrentDirection = 'D' });
                        }
                        break;
                    case '/':
                        if (path.CurrentDirection == 'L')
                        {
                            newDirection = 'D';
                        }
                        else if (path.CurrentDirection == 'R')
                        {
                            newDirection = 'U';
                        }
                        else if (path.CurrentDirection == 'U')
                        {
                            newDirection = 'R';
                        }
                        else // 'D'
                        {
                            newDirection = 'L';
                        }
                        break;
                    case '\\':
                        if (path.CurrentDirection == 'L')
                        {
                            newDirection = 'U';
                        }
                        else if (path.CurrentDirection == 'R')
                        {
                            newDirection = 'D';
                        }
                        else if (path.CurrentDirection == 'U')
                        {
                            newDirection = 'L';
                        }
                        else // 'D'
                        {
                            newDirection = 'R';
                        }
                        break;
                    case '.':
                    default:
                        break;
                }

                var coordinateIndex = coordinates.IndexOf(newCoordinate);
                coordinates[coordinateIndex].VisitedFromLeft = path.CurrentDirection == 'L';
                coordinates[coordinateIndex].VisitedFromRight = path.CurrentDirection == 'R';
                coordinates[coordinateIndex].VisitedFromUp = path.CurrentDirection == 'U';
                coordinates[coordinateIndex].VisitedFromDown = path.CurrentDirection == 'D';

                var pathIndex = paths.IndexOf(path);
                paths[pathIndex].CurrentCoordinate = newCoordinate;
                paths[pathIndex].CurrentDirection = newDirection;
            }
        }

        private static Coordinate? GetNewCoordinate(List<Coordinate> coordinates, Path path)
        {
            if (path.CurrentCoordinate == null)
            {
                return null;
            }

            var x = path.CurrentCoordinate.X;
            var y = path.CurrentCoordinate.Y;

            if (path.CurrentDirection == 'L')
            {
                x = path.CurrentCoordinate.X - 1;
            }
            else if (path.CurrentDirection == 'R')
            {
                x = path.CurrentCoordinate.X + 1;
            }
            else if (path.CurrentDirection == 'U')
            {
                y = path.CurrentCoordinate.Y - 1;
            }
            else
            {
                y = path.CurrentCoordinate.Y + 1;
            }

            return coordinates.FirstOrDefault(c => c.X == x && c.Y == y);
        }

        private static bool IsRepeatingPath(Coordinate newCoordinate, Path path)
        {
            return (newCoordinate.VisitedFromLeft && path.CurrentDirection == 'L')
                || (newCoordinate.VisitedFromRight && path.CurrentDirection == 'R')
                || (newCoordinate.VisitedFromUp && path.CurrentDirection == 'U')
                || (newCoordinate.VisitedFromDown && path.CurrentDirection == 'D');
        }
    }
}
