namespace AdventOfCode._2024.Day14
{
    public class Day14_Part1
    {
        public int Run(string input, int width, int height, int seconds = 100)
        {
            var robots = Day14.GetRobots(input);

            robots = robots.Select(r =>
            {
                var newPositionX = (r.PositionX + (seconds * r.VelocityX)) % width;
                r.PositionX = newPositionX < 0 ? newPositionX + width : newPositionX;

                var newPositionY = (r.PositionY + (seconds * r.VelocityY)) % height;
                r.PositionY = newPositionY < 0 ? newPositionY + height : newPositionY;

                return r;
            }).ToList();

            var xHalf = (width - 1) / 2;
            var yHalf = (height - 1) / 2;

            var quadrant1 = robots.Count(r => r.PositionX >= 0 && r.PositionX <= xHalf - 1
                                                && r.PositionY >= 0 && r.PositionY <= yHalf - 1);
            var quadrant2 = robots.Count(r => r.PositionX >= xHalf + 1 && r.PositionX <= width - 1
                                            && r.PositionY >= 0 && r.PositionY <= yHalf - 1);
            var quadrant3 = robots.Count(r => r.PositionX >= 0 && r.PositionX <= xHalf - 1
                                            && r.PositionY >= yHalf + 1 && r.PositionY <= height - 1);
            var quadrant4 = robots.Count(r => r.PositionX >= xHalf + 1 && r.PositionX <= width - 1
                                            && r.PositionY >= yHalf + 1 && r.PositionY <= height - 1);

            return quadrant1 * quadrant2 * quadrant3 * quadrant4;
        }
    }
}