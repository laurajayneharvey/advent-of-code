namespace AdventOfCode._2024.Day1
{
    public class Day1_Part1
    {
        public int Run(string input)
        {
            (var list1, var list2) = Day1.Run(input);

            list1 = [.. list1.Order()];
            list2 = [.. list2.Order()];

            var sum = 0;
            for (var i = 0; i < list1.Count; i++)
            {
                sum += Math.Abs(list1[i] - list2[i]);
            }

            return sum;
        }
    }
}
