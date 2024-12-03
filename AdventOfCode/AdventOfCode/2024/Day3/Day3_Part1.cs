using System.Text.RegularExpressions;

namespace AdventOfCode._2024.Day3
{
    public class Day3_Part1
    {
        public int Run(string input)
        {
            var regex = new Regex("mul\\([0-9]{1,3},[0-9]{1,3}\\)");
            var matches = regex.Matches(input).Select(x => x.ToString());

            var result = 0;
            foreach (var match in matches)
            {
                var parts = match.Split(",");
                var first = int.Parse(parts[0].Split("(")[1]);
                var second = int.Parse(parts[1].Split(")")[0]);
                result += (first * second);
            }

            return result;
        }
    }
}
