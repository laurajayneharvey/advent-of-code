using System.Text.RegularExpressions;

namespace AdventOfCode._2025.Day2
{
    public class Day2_Part2
    {
        public ulong Run(string input)
        {
            var ranges = input.Split(',').Select(x =>
            {
                var endpoints = x.Split('-');
                return endpoints.Select(ulong.Parse).ToList();
            });

            // knew I wanted to use a Regex for this and Praful's AOC on github provided
            var regex = new Regex("^(\\d+?)\\1+$");

            ulong invalidIdSum = 0;
            foreach (var range in ranges)
            {
                for (var i = range[0]; i <= range[1]; i++)
                {
                    var asString = i.ToString();

                    if (regex.IsMatch(asString))
                    {
                        invalidIdSum += i;
                    }
                }
            }

            return invalidIdSum;
        }
    }
}
