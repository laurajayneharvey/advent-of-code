namespace AdventOfCode._2022.Day3
{
    public class Day3_Part2
    {
        private readonly Day3 _day3 = new();

        public int Run(string input)
        {
            var rucksacks = input.Split("\r\n");

            var totalScore = 0;
            for (var i = 0; i < rucksacks.Length; i++)
            {
                if (i % 3 == 0)
                {
                    var elf1 = rucksacks[i];
                    var elf2 = rucksacks[i + 1];
                    var elf3 = rucksacks[i + 2];

                    var commonToTwo = elf1.ToCharArray().Where(value => elf2.ToCharArray().Contains(value));
                    var commonToThree = commonToTwo.Where(value => elf3.ToCharArray().Contains(value));

                    var score = _day3.GetScore(commonToThree);

                    totalScore += score;
                }
            }

            return totalScore;
        }
    }
}
