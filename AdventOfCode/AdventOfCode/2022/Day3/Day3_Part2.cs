namespace AdventOfCode._2022.Day3
{
    public class Day3_Part2
    {
        public int Run(string input)
        {
            var rucksacks = input.Split("\r\n");

            var totalScore = 0;
            for (var i = 0; i < rucksacks.Count(); i++)
            {
                if (i % 3 == 0)
                {
                    var elf1 = rucksacks[i];
                    var elf2 = rucksacks[i + 1];
                    var elf3 = rucksacks[i + 2];

                    var commonToTwo = elf1.ToCharArray().Where(value => elf2.ToCharArray().Contains(value));
                    var commonToThree = commonToTwo.Where(value => elf3.ToCharArray().Contains(value));

                    var charCode = commonToThree.First();

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
            }

            return totalScore;
        }
    }
}
