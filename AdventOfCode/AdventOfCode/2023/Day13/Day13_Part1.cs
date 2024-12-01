namespace AdventOfCode._2023.Day13
{
    public class Day13_Part1
    {
        public int Run(string input)
        {
            var patterns = input.Split("\r\n\r\n");

            var overall = 0;
            foreach (var pattern in patterns)
            {
                var rows = pattern.Split("\r\n").ToList();

                var aboveCount = GetBeforeReflection(rows);
                overall += (aboveCount * 100);

                if (aboveCount > 0)
                {
                    continue;
                }

                var columns = GetColumns(rows);
                var leftCount = GetBeforeReflection(columns);
                overall += leftCount;
            }

            return overall;
        }

        private static List<string> GetColumns(List<string> rows)
        {
            var columnLength = rows[0].Length;
            var matrix = new char[rows.Count, columnLength];
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    matrix[i, j] = rows[i][j];
                }
            }

            var columns = new List<string>();
            for (int i = 0; i < columnLength; i++)
            {
                var column = string.Empty;
                for (int j = 0; j < rows.Count; j++)
                {
                    column += rows[j][i];
                }
                columns.Add(column);
            }

            return columns;
        }

        private static int GetBeforeReflection(List<string> lines)
        {
            var duplicates = lines
                    .Select((t, i) => new { Index = i, Text = t })
                    .GroupBy(g => g.Text)
                    .Where(g => g.Count() > 1)
                    .Select(y => y.Select(x => x.Index).ToList())
                    .ToList();

            var length = lines.Count;

            var fromEnd = GetBeforeReflectionPoint(true, duplicates, length);

            if (fromEnd > 0)
            {
                return fromEnd;
            }

            return GetBeforeReflectionPoint(false, duplicates, length);
        }

        private static int GetBeforeReflectionPoint(bool fromEnd, List<List<int>> duplicates, int length)
        {
            var matchItem = fromEnd ? length - 1 : 0;
            var matchItemDuplicates = duplicates.FirstOrDefault(x => x.Any(y => y == matchItem));

            var hasMatch = false;
            if (matchItemDuplicates != null)
            {
                var with = matchItemDuplicates.Where(x => x != matchItem);
                foreach (var x in with)
                {
                    var sum = x + matchItem;
                    var midpoint = (sum + 1) / 2;
                    hasMatch = true;

                    var start = fromEnd ? midpoint : 0;
                    var end = fromEnd ? length : midpoint;
                    for (var i = start; i < end; i++)
                    {
                        var match = duplicates.FirstOrDefault(x => x.Any(y => y == i) && x.Any(y => y == sum - i));
                        if (match == null)
                        {
                            hasMatch = false;
                            continue; // try next option
                        }
                    }

                    if (hasMatch)
                    {
                        // no need to check any other matches
                        return midpoint;
                    }
                }
            }

            return 0;
        }
    }
}
