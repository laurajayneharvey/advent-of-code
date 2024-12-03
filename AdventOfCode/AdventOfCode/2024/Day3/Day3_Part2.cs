using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode._2024.Day3
{
    public class Day3_Part2
    {
        public int Run(string input)
        {
            var regex = new Regex("(mul\\([0-9]{1,3},[0-9]{1,3}\\))|(do\\(\\))|(don't\\(\\))");
            var matches = regex.Matches(input).Select(x => x.ToString());

            var result = 0;
            var enabled = true;
            foreach (var match in matches)
            {
                if (match.StartsWith("mul"))
                {
                    if (enabled)
                    {
                        var parts = match.Split(",");
                        var first = int.Parse(parts[0].Split("(")[1]);
                        var second = int.Parse(parts[1].Split(")")[0]);
                        result += (first * second);
                    }
                }
                else if (match.StartsWith("don't"))
                {
                    enabled = false;
                }
                else if (match.StartsWith("do"))
                {
                    enabled = true;
                }
            }

            return result;
        }
    }
}