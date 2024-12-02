namespace AdventOfCode._2024.Day2
{
    public class Day2_Part1
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
                }
            }

            return safeCount;
        }
    }
}
