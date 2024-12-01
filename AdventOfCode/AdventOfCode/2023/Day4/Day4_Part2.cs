namespace AdventOfCode._2023.Day4
{
    public class Day4_Part2
    {
        public int Run(string input)
        {
            var sum = 0;

            var scratchCards = input.Split("\r\n");
            var map = new Dictionary<int, List<int>>();
            var currentCards = new List<int>();
            for (var i = 0; i < scratchCards.Length; i++)
            {
                var scratchCard = scratchCards[i];

                var lists = scratchCard.Split("|");
                var winningNumbers = lists[0].Split(":")[1].Split(" ").Where(x => x != string.Empty);
                var numbersYouHave = lists[1].Split(" ").Where(x => x != string.Empty);
                var intersection = winningNumbers.Where(value => numbersYouHave.Contains(value));
                var matchCount = intersection.Count();

                var current = i + 1;
                currentCards.Add(current);
                if (matchCount > 0)
                {
                    map[current] = Enumerable.Range(current + 1, matchCount).ToList();
                }
                else
                {
                    map[current] = [];
                }
            }

            var addTo = new List<int>();
            while (currentCards.Count > 0)
            {
                addTo = [];

                sum += currentCards.Count;

                var counts = new Dictionary<int, int>();
                foreach (var currentValue in currentCards)
                {
                    counts[currentValue] = counts.TryGetValue(currentValue, out var existing) ? existing + 1 : 1;
                }

                foreach (var key in counts.Keys)
                {
                    if (map.TryGetValue(key, out var mapValue))
                    {
                        for (var i = 0; i < counts[key]; i++)
                        {
                            addTo.AddRange(mapValue);
                        }
                    }
                }

                currentCards = addTo;
            }

            return sum;
        }
    }
}
