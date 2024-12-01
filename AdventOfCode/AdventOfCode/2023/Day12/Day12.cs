using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day12
{
    public class Day12
    {
        public int Run(string input, bool unfold = false)
        {
            var rows = input.Split("\r\n");
            var overallCount = 0;

            foreach (var row in rows)
            {
                var formats = row.Split(" ");
                var format1 = formats[0];
                var groups = formats[1].Split(',').Select(int.Parse).ToList();
                var groupRegex = GetRegex(groups);

                var patterns = FindMatches(0, format1 + "E", format1[0], true, '.', groups[0], 0, groups, string.Empty, groupRegex); // 1

                if (unfold)
                {
                    var extraPatterns = FindMatches(0, format1 + "#E", format1[0], true, '.', groups[0], 0, groups, string.Empty, groupRegex);
                    if (extraPatterns.Count != 0)
                    {
                        var runningPatterns = GetRunningPatternsForExtra(format1, [format1], [format1]); // 2
                        runningPatterns = GetRunningPatternsForExtra(format1, runningPatterns, [format1]); // 3
                        runningPatterns = GetRunningPatternsForExtra(format1, runningPatterns, [format1]); // 4
                        runningPatterns = GetRunningPatternsForExtra(format1, runningPatterns, [format1]); // 5

                        var newGroups = new List<int>(groups);
                        for (var i = 0; i < 4; i++)
                        {
                            newGroups.AddRange(groups);
                        }
                        var newGroupRegex = GetRegex(newGroups);

                        foreach (var runningPattern in runningPatterns)
                        {
                            var matches = FindMatches(0, runningPattern + "E", runningPattern[0], true, '.', newGroups[0], 0, newGroups, string.Empty, newGroupRegex);
                            overallCount += matches.Count;
                        }
                    }
                    else
                    {
                        var runningPatterns = GetRunningPatterns(format1, groups, patterns, patterns, 1); // 2
                        runningPatterns = GetRunningPatterns(format1, groups, runningPatterns, patterns, 2); // 3
                        runningPatterns = GetRunningPatterns(format1, groups, runningPatterns, patterns, 3); // 4
                        runningPatterns = GetRunningPatterns(format1, groups, runningPatterns, patterns, 4); // 5
                        overallCount += runningPatterns.Count;
                    }
                }
                else
                {
                    overallCount += patterns.Count;
                }
            }

            return overallCount;
        }

        private static List<string> GetRunningPatternsForExtra(string format1, List<string> runningPatterns, List<string> patterns)
        {
            var newPatterns = new List<string>();
            foreach (var runningPattern in runningPatterns)
            {
                foreach (var pattern in patterns)
                {
                    // P.P
                    newPatterns.Add(runningPattern + "." + pattern);
                }
                // P#F
                newPatterns.Add(runningPattern + "#" + format1);
            }

            return newPatterns;
        }

        private static List<string> GetRunningPatterns(string format1, List<int> groups, List<string> runningPatterns, List<string> patterns, int addGroups)
        {
            var newGroups = new List<int>(groups);
            for (var i = 0; i < addGroups; i++)
            {
                newGroups.AddRange(groups);
            }
            var newGroupRegex = GetRegex(newGroups);

            var newPatterns = new List<string>();
            foreach (var runningPattern in runningPatterns)
            {
                foreach (var pattern in patterns)
                {
                    // P.P
                    newPatterns.Add(runningPattern + "." + pattern);
                }
                // P#F
                var patternHashFormat = runningPattern + "#" + format1;
                newPatterns.AddRange(FindMatches(0, patternHashFormat + "E", patternHashFormat[0], true, '.', newGroups[0], 0, newGroups, string.Empty, newGroupRegex));
            }

            return newPatterns;
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

        private static List<string> FindMatches(int currentCharIndex, string format1, char currentChar, bool useCurrentCharIndex, char lastChar, int currentGroup, int currentGroupIndex, List<int> groups, string possible, Regex regex)
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
                        if (lastChar != '.' && lastChar != '?')
                        {
                            return possible != null && regex.IsMatch(possible) ? [possible] : [];
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

                    var resultHash = FindMatches(currentCharIndex, format1, '#', useCurrentCharIndex, lastChar, currentGroup, currentGroupIndex, groups, possible, regex);
                    var resultDot = FindMatches(currentCharIndex, format1, '.', useCurrentCharIndex, lastChar, currentGroup, currentGroupIndex, groups, possible, regex);

                    resultHash.AddRange(resultDot);
                    return resultHash;
                }
                else // 'E'
                {
                    return possible != null && regex.IsMatch(possible) ? [possible] : [];
                }
            }

            return [];
        }
    }
}