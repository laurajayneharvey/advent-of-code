namespace AdventOfCode._2025.Day5
{
    public class Day5_Part1
    {
        public int Run(string input)
        {
            var database = input.Split("\r\n\r\n");

            var ranges = database[0].Split("\r\n").Select(x =>
            {
                var parts = x.Split('-');
                return (Start: ulong.Parse(parts[0]), End: ulong.Parse(parts[1]));
            }).ToList();

            var ingredients = database[1].Split("\r\n").Select(ulong.Parse).ToList();

            var freshCount = 0;

            foreach (var ingredient in ingredients)
            {
                foreach(var range in ranges)
                {
                    if(ingredient >= range.Start && ingredient <= range.End)
                    {
                        freshCount++;
                        break;
                    }
                }
            }

            return freshCount;
        }
    }
}
