namespace AdventOfCode._2024.Day1
{
    public static class Day1
    {
        public static (List<int>, List<int>) Run(string input)
        {
            var lines = input.Split("\r\n");

            var list1 = new List<int>();
            var list2 = new List<int>();
            foreach (var line in lines)
            {
                var parts = line.Split("   ");
                list1.Add(int.Parse(parts[0]));
                list2.Add(int.Parse(parts[1]));
            }

            return (list1, list2);
        }
    }
}
