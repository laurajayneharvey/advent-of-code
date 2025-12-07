using System.Text.RegularExpressions;

namespace AdventOfCode._2025.Day3
{
    public class Day3_Part1
    {
        public int Run(string input)
        {
            var banks = input.Split("\r\n");

            var joltageSum = 0;

            foreach (var bank in banks)
            {
                for (var i = 99; i >= 11; i--)
                {
                    // if it contains a 0, skip since can only have digits 1-9
                    if (i % 10 == 0)
                    {
                        continue;
                    }

                    var digits = i.ToString().ToCharArray();
                    var pattern = new Regex($"{digits[0]}\\d{{0,}}{digits[1]}");

                    if (pattern.IsMatch(bank))
                    {
                        joltageSum += i;
                        break;
                    }
                }
            }

            return joltageSum;
        }
    }
}
