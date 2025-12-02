namespace AdventOfCode._2025.Day2
{
    public class Day2_Part1
    {
        public ulong Run(string input)
        {
            var ranges = input.Split(',').Select(x =>
            {
                var endpoints = x.Split('-');
                return endpoints.Select(ulong.Parse).ToList();
            });

            ulong invalidIdSum = 0;
            foreach (var range in ranges)
            {
                for (var i = range[0]; i <= range[1]; i++)
                {
                    var asString = i.ToString();
                    var length = asString.Length;
                    if (length % 2 != 0)
                    {
                        continue;
                    }

                    var a = asString[..(length / 2)];
                    var b = asString.Substring(length / 2, length / 2);
                    if (a == b)
                    {
                        invalidIdSum += i;
                    }
                }
            }

            return invalidIdSum;
        }
    }
}
