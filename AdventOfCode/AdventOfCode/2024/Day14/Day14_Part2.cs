namespace AdventOfCode._2024.Day14
{
    public class Day14_Part2
    {
        public int Run(string input, int width, int height)
        {
            var robots = Day14.GetRobots(input);

            var seconds = 1;
            while (true)
            {
                robots = robots.Select(r =>
                {
                    var newPositionX = r.PositionX + r.VelocityX;
                    r.PositionX = newPositionX < 0 ? newPositionX + width : newPositionX % width;

                    var newPositionY = r.PositionY + r.VelocityY;
                    r.PositionY = newPositionY < 0 ? newPositionY + height : newPositionY % height;

                    return r;
                }).ToList();


                if (GetCrudeCluster(robots, width, height))
                {
                    PrintQuadrant(robots, width, height);
                    return seconds;
                }

                seconds++;
            }
        }

        private static bool GetCrudeCluster(List<Robot> robots, int width, int height)
        {
            for (var i = 0; i < height; i++)
            {
                var line = string.Empty;
                for (var j = 0; j < width; j++)
                {
                    line += robots.FirstOrDefault(r => r.PositionX == j && r.PositionY == i) != null ? "@" : ".";
                }

                if (line.Contains("@@@@@@@@@@"))
                {
                    return true;
                }
            }

            return false;
        }

        private static void PrintQuadrant(List<Robot> robots, int width, int height)
        {
            var output = string.Empty;
            for (var i = 0; i < height; i++)
            {
                var line = string.Empty;
                for (var j = 0; j < width; j++)
                {
                    line += robots.FirstOrDefault(r => r.PositionX == j && r.PositionY == i) != null ? "@" : ".";
                }

                output += line;
                output += "\r\n";
            }
        }
    }
}