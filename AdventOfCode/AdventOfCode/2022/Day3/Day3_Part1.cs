namespace AdventOfCode._2022.Day3
{
    public class Day3_Part1
    {
        private readonly Day3 _day3 = new();

        public int Run(string input)
        {
            var rucksacks = input.Split("\r\n");

            var totalScore = 0;
            foreach (var rucksack in rucksacks)
            {
                var numberOfItems = rucksack.Length;
                var halfSize = numberOfItems / 2;
                var firstHalf = rucksack[..halfSize];
                var secondHalf = rucksack.Substring(halfSize, halfSize);

                var common = firstHalf.ToCharArray().Where(value => secondHalf.ToCharArray().Contains(value));
                var score = _day3.GetScore(common);

                totalScore += score;
            }

            return totalScore;
        }
    }
}
