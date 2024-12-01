namespace AdventOfCode._2022.Day1
{
    public class Day1_Part2
    {
        private readonly Day1 _day1 = new();

        public int Run(string input)
        {
            var calorieCounts = _day1.CreateCalorieCounts(input);

            calorieCounts.Sort();
            var length = calorieCounts.Count;

            var one = calorieCounts[length - 1];
            var two = calorieCounts[length - 2];
            var three = calorieCounts[length - 3];

            return one + two + three;
        }
    }
}
