namespace AdventOfCode._2023.Day11
{
    public class Day11_Part1
    {
        public int? Run(string input)
        {
            var rows = input.Split("\r\n");

            var columns = new List<string>();
            for (var colIndex = 0; colIndex < rows[0].Length; colIndex++)
            {
                var column = string.Empty;
                for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
                {
                    column += rows[rowIndex][colIndex];
                }
                columns.Add(column);
            }

            var expandedColumns = new List<int>();
            for (var colIndex = 0; colIndex < rows[0].Length; colIndex++)
            {
                if (!columns[colIndex].Contains('#'))
                {
                    expandedColumns.Add(colIndex);
                }
            }

            var expandedRows = new List<int>();
            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                if (!rows[rowIndex].Contains('#'))
                {
                    expandedRows.Add(rowIndex);
                }
            }

            var coordinates = new List<Coordinate>();
            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                for (var colIndex = 0; colIndex < columns.Count; colIndex++)
                {
                    coordinates.Add(new Coordinate
                    {
                        X = colIndex,
                        Y = rowIndex,
                        Value = rows[rowIndex][colIndex]
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

                    overallDistance += Math.Abs(first.X - second.X) + Math.Abs(first.Y - second.Y);

                    var expandedRowsToAdd = expandedRows.Count(rowIndex => rowIndex > Math.Min(first.Y, second.Y) && rowIndex < Math.Max(first.Y, second.Y));
                    var expandedColsToAdd = expandedColumns.Count(colIndex => colIndex > Math.Min(first.X, second.X) && colIndex < Math.Max(first.X, second.X));
                    overallDistance += expandedRowsToAdd + expandedColsToAdd;
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
