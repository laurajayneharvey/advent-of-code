namespace AdventOfCode._2025.Day9
{
    public class Day9_Part1
    {
        public long Run(string input)
        {
            var coordinateRows = input.Split("\r\n");
            var coordinates = new List<Coordinate>();
            for (var i = 0; i < coordinateRows.Length; i++)
            {
                var coordinateRow = coordinateRows[i];
                var parts = coordinateRow.Split(',');
                coordinates.Add(new Coordinate
                {
                    X = int.Parse(parts[0]),
                    Y = int.Parse(parts[1])
                });
            }

            long largest = 0;
            for (var i = 0; i < coordinates.Count; i++)
            {
                for (var j = i + 1; j < coordinates.Count; j++)
                {
                    var a = coordinates[i];
                    var b = coordinates[j];
                    long xDiff = Math.Abs(a.X - b.X) + 1;
                    long yDiff = Math.Abs(a.Y - b.Y) + 1;
                    long area = xDiff * yDiff;
                    largest = Math.Max(largest, area);
                }
            }

            return largest;
        }

        private class Coordinate
        {
            public int X;
            public int Y;
        }
    }
}
