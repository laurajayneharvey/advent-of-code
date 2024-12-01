using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day12
{
    public class Day12_Part1
    {
        private static readonly Regex _unknownRegex = new Regex(Regex.Escape("?"));

        public int Run(string input)
        {
            var rows = input.Split("\r\n");
            var overallMatchCount = 0;
            foreach (var row in rows)
            {
                var formats = row.Split(" ");
                var format1 = formats[0];
                var format2 = formats[1];

                var unknownCount = format1.Count(x => x == '?');
                var combos = Enumerable.Range(0, (int)Math.Pow(2, unknownCount)).Select(x => format1).ToArray();

                while (unknownCount > 0)
                {
                    unknownCount--;

                    var i = 0;
                    var count = 1;
                    var isHash = false;
                    while (i < combos.Length)
                    {
                        var newChar = isHash ? "#" : ".";
                        combos[i] = _unknownRegex.Replace(combos[i], newChar, 1);
                        if (count == (int)Math.Pow(2, unknownCount))
                        {
                            isHash = !isHash;
                            count = 0;
                        }
                        i++;
                        count++;
                    }
                }

                var groups = format2.Split(',');
                var pattern = @"^\.*";
                foreach (var group in groups)
                {
                    pattern += "#{";
                    pattern += group;
                    pattern += "}";
                    pattern += @"\.+";
                }
                // remove last 2 chars
                pattern = pattern.Substring(0, pattern.Length - 3);
                pattern += @"\.*$";
                var groupRegex = new Regex(pattern);

                var matchCount = combos.Count(x => groupRegex.IsMatch(x));
                overallMatchCount += matchCount;
            }

            return overallMatchCount;
        }
    }
}
