namespace AdventOfCode._2024.Day11
{
    public class Day11_Part1
    {
        public int Run(string input)
        {
            var stones = input.Split(' ').Select(UInt128.Parse).ToList();

            for (var i = 0; i < 25; i++)
            {
                stones = Blink(stones);
            }

            return stones.Count;
        }

        public List<UInt128> Blink(List<UInt128> oldStones)
        {
            var newStones = new List<UInt128>();

            for (var index = 0; index < oldStones.Count; index++)
            {
                var stone = oldStones[index];
                if (stone == 0)
                {
                    newStones.Add(1);
                }
                else if (stone.ToString().Length % 2 == 0)
                {
                    var asString = stone.ToString();
                    var first = UInt128.Parse(asString.Substring(0, asString.Length / 2));
                    var second = UInt128.Parse(asString.Substring(asString.Length / 2, asString.Length / 2));
                    newStones.Add(first);
                    newStones.Add(second);
                }
                else
                {
                    newStones.Add(stone * 2024);
                }
            }

            return newStones;
        }
    }
}
