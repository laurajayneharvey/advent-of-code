namespace AdventOfCode._2023.Day4
{
    public class Day4_Part1
    {
        public double Run(string input)
        {
            double cardValueSum = 0;
            var scratchCards = input.Split("\r\n");
            foreach (var scratchCard in scratchCards)
            {
                var lists = scratchCard.Split("|");
                var winningNumbers = lists[0].Split(":")[1].Split(" ").Where(x => x != string.Empty);
                var numbersYouHave = lists[1].Split(" ").Where(x => x != string.Empty);
                var intersection = winningNumbers.Where(value => numbersYouHave.Contains(value));
                var matchCount = intersection.Count();

                if (matchCount > 0)
                {
                    var cardValue = Math.Pow(2, matchCount - 1);
                    cardValueSum += cardValue;
                }
            }

            return cardValueSum;
        }
    }
}
