namespace AdventOfCode._2025.Day4
{
    public class Day4_Part1
    {
        public int Run(string input)
        {
            var rows = input.Split("\r\n");
            var coordinates = new List<Coordinate>();
            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var columns = rows[rowIndex].ToCharArray();
                for (var columnIndex = 0; columnIndex < rows[rowIndex].Length; columnIndex++)
                {
                    coordinates.Add(new Coordinate
                    {
                        X = columnIndex,
                        Y = rowIndex,
                        Value = columns[columnIndex]
                    });
                }
            }

            var wallpaperCoordinates = coordinates.Where(c => c.IsWallpaper);
            foreach (var wallpaperCoordinate in wallpaperCoordinates)
            {
                var wallpaperAdjacentCount = 0;
                foreach(var (X, Y) in wallpaperCoordinate.Adjacents)
                {
                    var coordinate = coordinates.FirstOrDefault(c => c.X == X && c.Y == Y);
                    if (coordinate != null && coordinate.IsWallpaper)
                    {
                        wallpaperAdjacentCount++;
                    }
                    if (wallpaperAdjacentCount == 4)
                    {
                        break;
                    }
                }
                if (wallpaperAdjacentCount < 4)
                {
                    wallpaperCoordinate.IsAccessible = true;
                }
            }

            return wallpaperCoordinates.Count(c => c.IsAccessible);
        }

        private class Coordinate
        {
            public int X;
            public int Y;

            public char Value;

            public bool IsWallpaper => Value == '@';
            public bool IsAccessible = false;

            public (int X, int Y) North => new(X, Y - 1);
            public (int X, int Y) South => new(X, Y + 1);
            public (int X, int Y) East => new(X + 1, Y);
            public (int X, int Y) West => new(X - 1, Y);
            public (int X, int Y) NorthWest => new(West.X, North.Y);
            public (int X, int Y) NorthEast => new(East.X, North.Y);
            public (int X, int Y) SouthWest => new(West.X, South.Y);
            public (int X, int Y) SouthEast => new(East.X, South.Y);
            public IList<(int X, int Y)> Adjacents => [North, South, East, West, NorthWest, NorthEast, SouthWest, SouthEast];
        }
    }
}
