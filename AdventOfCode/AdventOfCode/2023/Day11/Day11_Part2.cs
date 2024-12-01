namespace AdventOfCode._2023.Day11
{
    public class Day11_Part2
    {
        private readonly Day11 _day11 = new();

        public long Run(string input, int expansion)
        {
            return _day11.Run(input, expansion - 1);
        }
    }
}
