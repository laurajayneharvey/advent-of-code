namespace AdventOfCode._2024.Day15
{
    public class Day15_Part1
    {
        public int Run(string input)
        {
            var parts = input.Split("\r\n\r\n");
            var map = parts[0];

            var rows = map.Split("\r\n");
            var mapItems = new List<MapItem>();
            var rowCount = rows.Count();
            var columnCount = rows[0].Count();
            for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                var columns = rows[rowIndex].ToCharArray();
                for (var colIndex = 0; colIndex < columnCount; colIndex++)
                {
                    mapItems.Add(new MapItem
                    {
                        X = colIndex,
                        Y = rowIndex,
                        Value = columns[colIndex]
                    });
                }
            }

            var directions = parts[1].Replace("\r\n", string.Empty).ToCharArray();
            //var output = string.Empty;
            for (var i = 0; i < directions.Count(); i++)
            {
                var robot = mapItems.First(m => m.IsRobot);
                var x = robot.X;
                var y = robot.Y;
                var robotMoved = false;
                var direction = directions[i];

                if (direction == '<')
                {
                    var nextDot = mapItems.LastOrDefault(m => m.X < x && m.Y == y && m.IsSpace);
                    if (nextDot == null)
                    {
                        //output += Day15.Print(mapItems, rowCount, columnCount, direction);
                        continue;
                    }
                    var nextWall = mapItems.Last(m => m.X < x && m.Y == y && m.IsWall);
                    if (nextDot.X < nextWall.X)
                    {
                        //output += Day15.Print(mapItems, rowCount, columnCount, direction);
                        continue;
                    }

                    robotMoved = true;

                    for (var current = nextDot.X; current < robot.X; current++)
                    {
                        mapItems.First(m => m.X == current && m.Y == y).Value = mapItems.First(m => m.X == current + 1 && m.Y == y).Value;
                    }
                }
                else if (direction == '>')
                {
                    var nextDot = mapItems.FirstOrDefault(m => m.X > x && m.Y == y && m.IsSpace);
                    if (nextDot == null)
                    {
                        //output += Day15.Print(mapItems, rowCount, columnCount, direction);
                        continue;
                    }
                    var nextWall = mapItems.First(m => m.X > x && m.Y == y && m.IsWall);
                    if (nextDot.X > nextWall.X)
                    {
                        //output += Day15.Print(mapItems, rowCount, columnCount, direction);
                        continue;
                    }

                    robotMoved = true;

                    for (var current = nextDot.X; current > robot.X; current--)
                    {
                        mapItems.First(m => m.X == current && m.Y == y).Value = mapItems.First(m => m.X == current - 1 && m.Y == y).Value;
                    }
                }
                else if (direction == 'v')
                {
                    var nextDot = mapItems.FirstOrDefault(m => m.X == x && m.Y > y && m.IsSpace);
                    if (nextDot == null)
                    {
                        //output += Day15.Print(mapItems, rowCount, columnCount, direction);
                        continue;
                    }
                    var nextWall = mapItems.First(m => m.X == x && m.Y > y && m.IsWall);
                    if (nextDot.Y > nextWall.Y)
                    {
                        //output += Day15.Print(mapItems, rowCount, columnCount, direction);
                        continue;
                    }

                    robotMoved = true;

                    for (var current = nextDot.Y; current > robot.Y; current--)
                    {
                        mapItems.First(m => m.X == x && m.Y == current).Value = mapItems.First(m => m.X == x && m.Y == current - 1).Value;
                    }
                }
                else if (direction == '^')
                {
                    var nextDot = mapItems.LastOrDefault(m => m.X == x && m.Y < y && m.IsSpace);
                    if (nextDot == null)
                    {
                        //output += Day15.Print(mapItems, rowCount, columnCount, direction);
                        continue;
                    }
                    var nextWall = mapItems.Last(m => m.X == x && m.Y < y && m.IsWall);
                    if (nextDot.Y < nextWall.Y)
                    {
                        //output += Day15.Print(mapItems, rowCount, columnCount, direction);
                        continue;
                    }

                    robotMoved = true;

                    for (var current = nextDot.Y; current < robot.Y; current++)
                    {
                        mapItems.First(m => m.X == x && m.Y == current).Value = mapItems.First(m => m.X == x && m.Y == current + 1).Value;
                    }
                }

                if (robotMoved)
                {
                    mapItems.First(map => map.X == robot.X && map.Y == robot.Y).Value = '.';
                }

                //output += Day15.Print(mapItems, rowCount, columnCount, direction);
            }

            return mapItems.Where(m => m.IsBox).Select(m => m.Y * 100 + m.X).Sum();
        }
    }
}
