using System.Drawing;

namespace AdventOfCode._2024.Day14
{
    public class Day14
    {
        public int Run(string input, int width, int height)
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

            var xHalf = (width - 1) / 2;
            var yHalf = (height - 1) / 2;

            var quadrant1 = 0;
            var quadrant2 = 0;
            var quadrant3 = 0;
            var quadrant4 = 0;

            for (var second = 1; second <= 100; second++)
            {
                foreach (var robot in robots)
                {
                    var currentPositionX = robot.PositionX;
                    var currentPositionY = robot.PositionY;


                    var newPositionX = currentPositionX + robot.VelocityX;
                    if (newPositionX < 0)
                    {
                        currentPositionX = newPositionX + width;
                    }
                    else
                    {
                        currentPositionX = newPositionX % width;
                    }

                    var newPositionY = currentPositionY + robot.VelocityY;
                    if (newPositionY < 0)
                    {
                        currentPositionY = newPositionY + height;
                    }
                    else
                    {
                        currentPositionY = newPositionY % height;
                    }

                    robot.PositionX = currentPositionX;
                    robot.PositionY = currentPositionY;
                }

                quadrant1 = robots.Count(r => r.PositionX >= 0 && r.PositionX <= xHalf - 1
                                            && r.PositionY >= 0 && r.PositionY <= yHalf - 1);
                quadrant2 = robots.Count(r => r.PositionX >= xHalf + 1 && r.PositionX <= width - 1
                                                && r.PositionY >= 0 && r.PositionY <= yHalf - 1);
                quadrant3 = robots.Count(r => r.PositionX >= 0 && r.PositionX <= xHalf - 1
                                                && r.PositionY >= yHalf + 1 && r.PositionY <= height - 1);
                quadrant4 = robots.Count(r => r.PositionX >= xHalf + 1 && r.PositionX <= width - 1
                                                && r.PositionY >= yHalf + 1 && r.PositionY <= height - 1);
            }

            return quadrant1 * quadrant2 * quadrant3 * quadrant4;
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