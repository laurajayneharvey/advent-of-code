namespace AdventOfCode._2022.Day4
{
    public class Day4_Part2
    {
        public int Run(string input)
        {
            var elfPairs = input.Split("\r\n");

            var totalScore = 0;
            foreach (var elfPair in elfPairs)
            {
                var elves = elfPair.Split(",");

                var elf1 = elves[0];
                var elf1Min = int.Parse(elf1.Split("-")[0]);
                var elf1Max = int.Parse(elf1.Split("-")[1]);

                var elf2 = elves[1];
                var elf2Min = int.Parse(elf2.Split("-")[0]);
                var elf2Max = int.Parse(elf2.Split("-")[1]);

                var overlap = false;
                var elf1MinTemp = elf1Min;
                while (elf1MinTemp <= elf1Max)
                {
                    if (elf1MinTemp >= elf2Min && elf1MinTemp <= elf2Max)
                    {
                        overlap = true;
                        break;
                    }
                    elf1MinTemp++;
                }

                if (overlap)
                {
                    totalScore++;
                }
            }

            return totalScore;
        }
    }
}
