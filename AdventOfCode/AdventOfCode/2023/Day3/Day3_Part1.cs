namespace AdventOfCode._2023.Day3
{
    public class Day3_Part1
    {
        public int Run(string input)
        {
            var partNumberSum = 0;
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
                        var surrounding = GetSurrounding(i, j, rows, cols);
                        var hasSymbol = surrounding.Any(x => x != '.' && !char.IsNumber(x));
                        if (hasSymbol)
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

                            partNumberSum += int.Parse(partNumber);
                        }
                    }
                }
            }

            return partNumberSum;
        }

        private List<char> GetSurrounding(int i, int j, string[] rows, char[] cols)
        {
            var surrounding = new List<char>();
            // row above
            if (i - 1 >= 0)
            {
                var north = rows[i - 1].ToCharArray();
                if (j - 1 >= 0)
                {
                    var NW = north[j - 1];
                    surrounding.Add(NW);
                }
                var N = north[j];
                surrounding.Add(N);
                if (j + 1 < cols.Length)
                {
                    var NE = north[j + 1];
                    surrounding.Add(NE);
                }
            }
            // same row
            if (j - 1 >= 0)
            {
                var W = cols[j - 1];
                surrounding.Add(W);
            }
            if (j + 1 < cols.Length)
            {
                var E = cols[j + 1];
                surrounding.Add(E);
            }
            // row below
            if (i + 1 < rows.Length)
            {
                var south = rows[i + 1].ToCharArray();
                if (j - 1 >= 0)
                {
                    var SW = south[j - 1];
                    surrounding.Add(SW);
                }
                var S = south[j];
                surrounding.Add(S);
                if (j + 1 < cols.Length)
                {
                    var SE = south[j + 1];
                    surrounding.Add(SE);
                }
            }
            return surrounding;
        }
    }
}
