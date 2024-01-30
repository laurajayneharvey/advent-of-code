namespace AdventOfCode._2022.Day1
{
    public class Day1
    {
        public List<int> CreateCalorieCounts(string input)
        {
            var elves = input.Split("\r\n\r\n");
            var calorieCounts = new List<int>();
            foreach (var elf in elves)
            {
                var foods = elf.Split("\r\n");
                var sum = foods.Sum(x => int.Parse(x));
                calorieCounts.Add(sum);
            }

            return calorieCounts;
        }
    }
}
