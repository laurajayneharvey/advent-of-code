namespace AdventOfCode._2022.Day1
{
    public class Day1_Part1
    {
        private readonly Day1 _day1 = new();

        public int Run(string input)
        {
            var calorieCounts = _day1.CreateCalorieCounts(input);

            return calorieCounts.Max();
        }
    }
}
