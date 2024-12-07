namespace AdventOfCode._2024.Day6
{
    public class Day6_Part1
    {
        public int Run(string input)
        {
            var positions = Day6.GetPositions(input);
            var path = Day6.GetPath(positions);
            return path.Count(x => x.VisitedDirections.Any());
        }
    }
}
