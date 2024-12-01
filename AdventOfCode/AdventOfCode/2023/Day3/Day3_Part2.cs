namespace AdventOfCode._2023.Day3
{
    public class Day3_Part2
    {
        public int Run(string input)
        {
            var possibleGearsOverall = new List<(int rowIndex, int colIndex, int partNumber)>();
            var rows = input.Split("\r\n");
            for (var i = 0; i < rows.Length; i++)
            {
                var row = rows[i];
                var cols = row.ToCharArray();
                for (var j = 0; j < cols.Length; j++)
                {
                    var col = cols[j];
                    if (char.IsNumber(col))
                    {
                        var possibleGearsHere = GetSurrounding(i, j, rows, cols);
                        if (possibleGearsHere.Count > 0)
                        {
                            var partNumber = col.ToString();

                            // find numbers before
                            var k = j - 1;
                            while (k >= 0 && char.IsNumber(cols[k]))
                            {
                                partNumber = cols[k] + partNumber;
                                k--;
                            }
                            // find numbers after
                            var l = j + 1;
                            while (l < cols.Length && char.IsNumber(cols[l]))
                            {
                                partNumber = partNumber + cols[l];
                                l++;
                                j = l;
                            }

                            possibleGearsOverall.AddRange(possibleGearsHere.Select(x =>
                            {
                                x.partNumber = int.Parse(partNumber);
                                return x;
                            }));
                        }
                    }
                }
            }

            var possibleGears = new Dictionary<string, (int gearRatio, int count)>();
            foreach (var possibleGear in possibleGearsOverall)
            {
                var key = $"{possibleGear.rowIndex}-{possibleGear.colIndex}";
                var found = possibleGears.TryGetValue(key, out var group);

                var existingGearRatio = found ? group.gearRatio : 1;
                var newGearRatio = existingGearRatio *= possibleGear.partNumber;

                var existingCount = found ? group.count : 0;
                existingCount++;

                possibleGears[key] = (newGearRatio, existingCount);
            }

            var gearRatioSum = possibleGears.Keys
              .Where((key) => possibleGears[key].count == 2)
              .Select((key) => possibleGears[key].gearRatio)
              .Aggregate(0, (sum, current) => sum + current);

            return gearRatioSum;
        }

        private List<(int rowIndex, int colIndex, int partNumber)> GetSurrounding(int i, int j, string[] rows, char[] cols)
        {
            var surrounding = new List<(int rowIndex, int colIndex, int partNumber)>();
            // row above
            if (i - 1 >= 0)
            {
                var north = rows[i - 1].ToCharArray();
                if (j - 1 >= 0)
                {
                    var NW = north[j - 1];
                    if (NW == '*')
                    {
                        surrounding.Add((i - 1, j - 1, 0));
                    }
                }
                var N = north[j];
                if (N == '*')
                {
                    surrounding.Add((i - 1, j, 0));
                }
                if (j + 1 < cols.Length)
                {
                    var NE = north[j + 1];
                    if (NE == '*')
                    {
                        surrounding.Add((i - 1, j + 1, 0));
                    }
                }
            }
            // same row
            if (j - 1 >= 0)
            {
                var W = cols[j - 1];
                if (W == '*')
                {
                    surrounding.Add((i, j - 1, 0));
                }
            }
            if (j + 1 < cols.Length)
            {
                var E = cols[j + 1];
                if (E == '*')
                {
                    surrounding.Add((i, j + 1, 0));
                }
            }
            // row below
            if (i + 1 < rows.Length)
            {
                var south = rows[i + 1].ToCharArray();
                if (j - 1 >= 0)
                {
                    var SW = south[j - 1];
                    if (SW == '*')
                    {
                        surrounding.Add((i + 1, j - 1, 0));
                    }
                }
                var S = south[j];
                if (S == '*')
                {
                    surrounding.Add((i + 1, j, 0));
                }
                if (j + 1 < cols.Length)
                {
                    var SE = south[j + 1];
                    if (SE == '*')
                    {
                        surrounding.Add((i + 1, j + 1, 0));
                    }
                }
            }
            return surrounding;
        }
    }
}
