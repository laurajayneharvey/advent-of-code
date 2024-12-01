namespace AdventOfCode._2022.Day6
{
    public class Day6
    {
        public int Run(string input, int requiredUniqueCount)
        {
            var index = requiredUniqueCount - 1;
            var stream = input.ToCharArray();
            while (index < stream.Count())
            {
                var skip = index - (requiredUniqueCount - 1);
                var take = (index + 1) - skip;
                var potentialStart = stream.Skip(skip).Take(take);

                var uniqueCount = potentialStart.Distinct().Count();
                if (uniqueCount == requiredUniqueCount)
                {
                    break;
                }
                index++;
            }

            return index + 1;
        }
    }
}
