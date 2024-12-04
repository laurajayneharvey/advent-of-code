namespace AdventOfCode._2024.Day1
{
    public class Day1_Part2
    {
        public int Run(string input)
        {
            (var list1, var list2) = Day1.Run(input);

            var list2Counts = list2.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            return list1.Sum(x =>
            {
                var inList2 = list2Counts.TryGetValue(x, out var count);
                return x * (inList2 ? count : 0);
            });
        }
    }
}
