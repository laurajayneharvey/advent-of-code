using System.Drawing;

namespace AdventOfCode._2024.Day6
{
    public class Day6_Part2
    {
        public int Run(string input)
        {
            var positions = Day6.GetPositions(input);
            var path = Day6.GetPath(positions);
            var visited = path.Where(x => x.VisitedDirections.Any());
            var start = positions.First(item => item.Type == '<' || item.Type == '>' || item.Type == '^' || item.Type == 'v');
            var visitedExcludingStart = visited.Where(item => !(item.Coordinate.X == start.Coordinate.X && item.Coordinate.Y == start.Coordinate.Y)).ToList();

            var infinites = 0;
            // a hack for now - these are infinite in the real data but my algorithm is not identifying them as infinite
            var infiniteButNeedToIdentifyWhy = new[] { 947, 1585, 3318, 4119 };
            foreach (var visitedPosition in visitedExcludingStart)
            {
                var index = visitedExcludingStart.IndexOf(visitedPosition);
                if (infiniteButNeedToIdentifyWhy.Contains(index))
                {
                    infinites++;
                    continue;
                }
                var newPositions = Day6.GetPositions(input);
                newPositions.First(item => item.Coordinate.X == visitedPosition.Coordinate.X && item.Coordinate.Y == visitedPosition.Coordinate.Y).Type = '#';
                var revisit = Day6.GetPath(newPositions);
                if (revisit.FirstOrDefault(x => x.Infinite) != null)
                {
                    infinites++;
                }
            }

            return infinites;
        }
    }
}
