namespace AdventOfCode._2023.Day11
{
    public class Day11_Part1
    {
        private readonly Day11 _day11 = new();

        public int? Run(string input)
        {
            var lines = input.Split("\r\n");

            var columns = new List<string>();
            var columnCount = lines[0].Length;
            for (var colIndex = 0; colIndex < columnCount; colIndex++)
            {
                var column = string.Empty;
                for (var rowIndex = 0; rowIndex < lines.Length; rowIndex++)
                {
                    column += lines[rowIndex][colIndex];
                }
                columns.Add(column);
            }

            var expandedColumns = new List<string>();
            foreach (var column in columns)
            {
                expandedColumns.Add(column);
                if (!column.Contains('#'))
                {
                    expandedColumns.Add(column);
                }
            }

            var rows = new List<string>();
            var rowCount = expandedColumns[0].Length;
            for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                var row = string.Empty;
                for (var colIndex = 0; colIndex < expandedColumns.Count; colIndex++)
                {
                    row += expandedColumns[colIndex][rowIndex];
                }
                rows.Add(row);
            }

            var expandedRows = new List<string>();
            foreach (var row in rows)
            {
                expandedRows.Add(row);
                if (!row.Contains('#'))
                {
                    expandedRows.Add(row);
                }
            }

            var coordinates = new List<Coordinate>();
            for (var rowIndex = 0; rowIndex < expandedRows.Count; rowIndex++)
            {
                for (var colIndex = 0; colIndex < expandedRows[rowIndex].Length; colIndex++)
                {
                    coordinates.Add(new Coordinate
                    {
                        X = colIndex,
                        Y = rowIndex,
                        Value = expandedRows[rowIndex][colIndex]
                    });
                }
            }

            var galaxies = coordinates.Where(item => item.Value == '#').OrderBy(item => item.X).OrderBy(item => item.Y);

            var overallDistance = 0;
            for (var i = 0; i < galaxies.Count(); i++)
            {
                for (var j = i + 1; j < galaxies.Count(); j++)
                {
                    var first = galaxies.ElementAt(i);
                    var second = galaxies.ElementAt(j);

                    var xDiff = Math.Abs(first.X - second.X);
                    var yDiff = Math.Abs(first.Y - second.Y);
                    overallDistance += xDiff + yDiff;
                }
            }

            return overallDistance;
        }
    }

    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
    }
}
