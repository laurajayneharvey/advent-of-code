namespace AdventOfCode._2023.Day13
{
    public class Day14_Part1
    {
        public int Run(string input)
        {
            var coordinates = new List<(int X, int Y, char Rock)>();
            var rows = input.Split("\r\n");
            var colCount = rows[0].Length;
            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                for (var colIndex = 0; colIndex < colCount; colIndex++)
                {
                    var coordinate = (colIndex, rowIndex, rows[rowIndex][colIndex]);
                    coordinates.Add(coordinate);
                }
            }

            var roundRocks = coordinates.Where(x => x.Rock == 'O').ToList();
            for (var coordinateIndex = 0; coordinateIndex < roundRocks.Count; coordinateIndex++)
            {
                var coordinate = roundRocks[coordinateIndex];
                var proposedCoordinate = coordinate;
                while (proposedCoordinate.Y > 0)
                {
                    var proposedRowIndex = proposedCoordinate.Y - 1;
                    var oneUp = coordinates.First(c => c.X == coordinate.X && c.Y == proposedRowIndex);
                    if (oneUp.Rock != '.')
                    {
                        break;
                    }
                    proposedCoordinate = oneUp;
                }

                if (proposedCoordinate != coordinate)
                {
                    var oldIndex = coordinates.IndexOf(coordinate);
                    coordinates[oldIndex] = new(coordinate.X, coordinate.Y, '.');

                    var newIndex = coordinates.IndexOf(proposedCoordinate);
                    coordinates[newIndex] = new(proposedCoordinate.X, proposedCoordinate.Y, 'O');
                }
            }

            var overall = 0;
            for (var rowIndex = rows.Length - 1; rowIndex >= 0; rowIndex--)
            {
                var multiplier = rows.Length - rowIndex;
                var roundRockCountForRow = coordinates.Where(c => c.Y == rowIndex).Count(c => c.Rock == 'O');
                var load = roundRockCountForRow * multiplier;
                overall += load;
            }

            return overall;
        }
    }
}
