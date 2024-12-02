namespace AdventOfCode._2024.Day2
{
    public static class Day2
    {
        public static bool IsSafe(List<int> levels)
        {
            var first = levels.First();
            var last = levels.Last();

            if (first == last) // not ascending or descending
            {
                return false;
            }

            var isAscending = last > first;
            for (var i = 1; i < levels.Count; i++)
            {
                var previous = levels[i - 1];
                var current = levels[i];

                if ((previous == current) // not ascending or descending
                || (current > previous && !isAscending) // ascending but should be descending
                || (previous > current && isAscending) // descending but should be ascending
                || (Math.Abs(current - previous) > 3))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
