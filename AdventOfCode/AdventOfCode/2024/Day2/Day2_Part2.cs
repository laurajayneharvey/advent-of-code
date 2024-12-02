using System.Linq;
using System.Runtime.CompilerServices;

namespace AdventOfCode._2024.Day2
{
    public class Day2_Part2
    {
        public int Run(string input)
        {
            var reports = input.Split("\r\n");
            var safeCount = 0;
            foreach (var report in reports)
            {
                var levels = report.Split(" ").Select(int.Parse).ToList();
                var isSafe = Day2.IsSafe(levels);
                if (isSafe)
                {
                    safeCount++;
                    continue;
                }


                for (var i = 0; i < levels.Count; i++)
                {
                    var clonedLevels = new List<int>(levels);
                    clonedLevels.RemoveAt(i);
                    isSafe = Day2.IsSafe(clonedLevels);
                    if (isSafe)
                    {
                        safeCount++;
                        break;
                    }
                }
            }

            return safeCount;
        }
    }
}