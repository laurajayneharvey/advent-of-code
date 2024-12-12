using System.Collections.Concurrent;

namespace AdventOfCode._2024.Day11
{
    public class Day11
    {
        public long Run(string input, int iterations)
        {
            var stones = input.Split(' ').Select(long.Parse).ToList();

            return Blink(stones, iterations);
        }

        private static long Blink(List<long> stones, int iterations)
        {
            var stoneCounts = stones.GroupBy(x => x).ToDictionary(x => x.Key, x => (long)x.Count());

            for (var i = 0; i < iterations; i++)
            {
                var newStoneCounts = new Dictionary<long, long>();
                foreach (var stoneCount in stoneCounts)
                {
                    var stone = stoneCount.Key;
                    var count = stoneCount.Value;
                    if (stone == 0)
                    {
                        AddOrUpdateStoneCount(newStoneCounts, 1, count);
                    }
                    else if (stone.ToString().Length % 2 == 0)
                    {
                        var asString = stone.ToString();
                        var first = long.Parse(asString.Substring(0, asString.Length / 2));
                        var second = long.Parse(asString.Substring(asString.Length / 2, asString.Length / 2));

                        AddOrUpdateStoneCount(newStoneCounts, first, count);
                        AddOrUpdateStoneCount(newStoneCounts, second, count);
                    }
                    else
                    {
                        AddOrUpdateStoneCount(newStoneCounts, stone * 2024, count);
                    }

                    // remove the stone count, it's about to be replaced with counts of its blinked stones
                    stoneCounts.Remove(stone);
                }

                foreach (var newStone in newStoneCounts)
                {
                    stoneCounts[newStone.Key] = newStone.Value;
                }
            }

            return stoneCounts.Values.Sum();
        }

        private static void AddOrUpdateStoneCount(Dictionary<long, long> stoneCounts, long stone, long count)
        {
            if (!stoneCounts.TryGetValue(stone, out var _))
            {
                stoneCounts[stone] = count;
            }
            else
            {
                stoneCounts[stone] += count;
            }
        }
    }
}
