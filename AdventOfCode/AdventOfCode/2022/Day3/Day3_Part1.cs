namespace AdventOfCode._2022.Day3
{
    public class Day3_Part1
    {
        public int Run(string input)
        {
            var rucksacks = input.Split("\r\n");

            var totalScore = 0;
            foreach (var rucksack in rucksacks)
            {
                var numberOfItems = rucksack.Count();
                var halfSize = numberOfItems / 2;
                var firstHalf = rucksack.Substring(0, halfSize);
                var secondHalf = rucksack.Substring(halfSize, halfSize);

                var common = firstHalf.ToCharArray().Where(value => secondHalf.ToCharArray().Contains(value));

                var charCode = common.First();

                var score = 0;
                if (charCode <= 90)
                {
                    // A 65 -> 27 (-38)
                    // Z 90 -> 52 (-38)
                    score = charCode - 38;
                }
                else
                {
                    // a 97 -> 1 (-96)
                    // z 122 -> 26 (-96)
                    score = charCode - 96;
                }

                totalScore += score;
            }

            return totalScore;
        }
    }
}
