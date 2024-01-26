namespace AdventOfCode._2023.Day9
{
    public class Day9
    {
        public int GetResult(string input, bool reverse = false)
        {
            var histories = input.Split("\r\n").ToList();

            var overall = histories.Sum(history =>
            {
                var historyLine = history.Split(" ").Select(x => int.Parse(x)).ToList();
                if (reverse)
                {
                    historyLine.Reverse();
                }
                return GetNextItem(historyLine);
            });

            return overall;
        }

        private int GetNextItem(List<int> history)
        {
            var lines = new List<List<int>>() { history };
            while (!history.All(x => x == 0))
            {
                var newHistoryLine = new List<int>();
                for (var i = 0; i < history.Count() - 1; i++)
                {
                    newHistoryLine.Add(history[i + 1] - history[i]);
                }
                lines.Add(newHistoryLine);
                history = newHistoryLine;
            }

            return lines.Sum(line => line[line.Count() - 1]);
        }
    }
}
