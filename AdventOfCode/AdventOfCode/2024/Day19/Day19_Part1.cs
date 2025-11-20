using System.Text.RegularExpressions;

namespace AdventOfCode._2024.Day19
{
    public class Day19_Part1
    {
        public int Run(string input)
        {
            var lines = input.Split("\r\n");
            var towels = lines[0].Split(", ");

            var pattern = "^(" + string.Join("|", towels) + ")*$";
            var regex = new Regex(pattern);

            var patternsToMatch = lines.Skip(2);
            var count = patternsToMatch.Count(x => regex.IsMatch(x));

            return count;
        }
    }
}