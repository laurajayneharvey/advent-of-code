using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day12
{
    public class Day12
    {
        private static readonly Regex _unknownRegex = new Regex(Regex.Escape("?"));

        public int Run(string input)
        {
            var rows = input.Split("\r\n");
            var matchCountOverall = 0;

            foreach (var row in rows)
            {
                var formats = row.Split(" ");
                var format1 = formats[0];
                var groups = formats[1].Split(',').Select(x => int.Parse(x)).ToList();
                var groupRegex = GetRegex(groups);
                var minimumLength = groups.Sum() + groups.Count - 1;

                matchCountOverall += FindMatch(0, format1 + "E", format1[0], true, '.', groups[0], 0, groups, string.Empty, groupRegex, minimumLength);
            }

            return matchCountOverall;
        }

        private static Regex GetRegex(List<int> groups)
        {
            var pattern = @"^\.*";
            foreach (var group in groups)
            {
                pattern += "#{";
                pattern += group;
                pattern += "}";
                pattern += @"\.+";
            }
            pattern = pattern.Substring(0, pattern.Length - 3);
            pattern += @"\.*$";

            return new Regex(pattern);
        }

        private static int FindMatch(int currentCharIndex, string format1, char currentChar, bool useCurrentCharIndex, char lastChar, int currentGroup, int currentGroupIndex, List<int> groups, string possible, Regex regex, int minimumLength)
        {
            while (currentCharIndex < format1.Length)
            {
                currentChar = useCurrentCharIndex ? format1[currentCharIndex] : currentChar;
                useCurrentCharIndex = true;
                if (currentChar == '.')
                {
                    possible += ".";
                    lastChar = '.';
                    currentCharIndex++;
                    while (currentCharIndex < format1.Length && format1[currentCharIndex] == '.')
                    {
                        currentCharIndex++;
                    }
                }
                else if (currentChar == '#')
                {
                    possible += "#";
                    if (currentGroup != 0)
                    {
                        currentCharIndex++;
                        currentGroup--;
                    }
                    else
                    {
                        if (lastChar != '.')
                        {
                            return possible != null && possible.Length >= minimumLength && regex.IsMatch(possible) ? 1 : 0;
                        }

                        currentCharIndex++;
                        currentGroupIndex++;
                        if (currentGroupIndex < groups.Count)
                        {
                            currentGroup = groups[currentGroupIndex];
                            currentGroup--;
                        }
                    }
                    lastChar = '#';
                }
                else if (currentChar == '?')
                {
                    useCurrentCharIndex = false;

                    var resultHash = FindMatch(currentCharIndex, format1, '#', useCurrentCharIndex, lastChar, currentGroup, currentGroupIndex, groups, possible, regex, minimumLength);
                    var resultDot = FindMatch(currentCharIndex, format1, '.', useCurrentCharIndex, lastChar, currentGroup, currentGroupIndex, groups, possible, regex, minimumLength);

                    return resultHash + resultDot;
                }
                else // 'E'
                {
                    return possible != null && possible.Length >= minimumLength && regex.IsMatch(possible) ? 1 : 0;
                }
            }

            return 0;
        }
    }
}