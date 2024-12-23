namespace AdventOfCode._2024.Day14
{
    public static class Day14
    {
        public static List<Robot> GetRobots(string input)
        {
            var rows = input.Split("\r\n");
            var robots = new List<Robot>();
            foreach (var row in rows)
            {
                var parts = row.Split(" ");
                var position = parts[0].Split(",");
                var velocity = parts[1].Split(",");
                robots.Add(new Robot
                {
                    PositionX = int.Parse(position[0].Replace("p=", string.Empty)),
                    PositionY = int.Parse(position[1]),
                    VelocityX = int.Parse(velocity[0].Replace("v=", string.Empty)),
                    VelocityY = int.Parse(velocity[1])
                });
            }

            return robots;
        }
    }

    public class Robot
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int VelocityX { get; set; }
        public int VelocityY { get; set; }
    }
}