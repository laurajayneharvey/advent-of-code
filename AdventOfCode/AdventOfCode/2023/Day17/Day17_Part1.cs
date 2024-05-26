using System.Drawing;

namespace AdventOfCode._2023.Day17
{
    public class Day17_Part1
    {
        public class CityBlock
        {
            public Point Coordinate;
            public int HeatLoss;
            public int TotalHeatLoss = int.MaxValue;
            public int Step;
            public char Direction;
            public bool Visited;
        }

        public int Run(string input)
        {
            var cityBlocks = new List<CityBlock>();
            var y = 0;
            var possibleSteps = new[] { 0, 1, 2, 3 }; // opportunity to tidy up - only need the step 0s for the sources
            var possibleDirections = new[] { 'N', 'S', 'E', 'W' };
            foreach (var row in input.Split())
            {
                int x = 0;

                foreach (var column in row)
                {
                    foreach (var possibleStep in possibleSteps)
                    {
                        foreach (var possibleDirection in possibleDirections)
                        {
                            var cityBlock = new CityBlock
                            {
                                Coordinate = new Point(x, y),
                                HeatLoss = int.Parse(column.ToString()),
                                Step = possibleStep,
                                Direction = possibleDirection,
                            };
                            cityBlocks.Add(cityBlock);
                        }
                    }
                    x++;
                }

                if (row == string.Empty)
                {
                    y++;
                }
            }

            var size = input.Split()[0].Length;

            var eastMinimum = GetMinimum(cityBlocks, size, 'E');
            var southMinimum = GetMinimum(cityBlocks, size, 'S');

            return Math.Min(eastMinimum, southMinimum);
        }

        private static int GetMinimum(List<CityBlock> cityBlocks, int size, char direction)
        {
            // source (lava pool) setting off in direction
            cityBlocks.First(block => block.Coordinate.X == 0 && block.Coordinate.Y == 0 && block.Step == 0 && block.Direction == direction).TotalHeatLoss = 0;

            // while not at a destination (machine part factory)
            while (cityBlocks.FirstOrDefault(block => block.Coordinate.X == size - 1 && block.Coordinate.Y == size - 1 && block.TotalHeatLoss != int.MaxValue) == null)
            {
                cityBlocks = AdvanceTheCrucible(cityBlocks);
            }

            return cityBlocks.FirstOrDefault(block => block.Coordinate.X == size - 1 && block.Coordinate.Y == size - 1 && block.TotalHeatLoss != int.MaxValue)?.TotalHeatLoss ?? int.MaxValue;
        }

        private static List<CityBlock> AdvanceTheCrucible(List<CityBlock> cityBlocks)
        {
            //var crucible = cityBlocks.OrderBy(block => block.TotalHeatLoss).First(block => !block.Visited);
            var unvisited = cityBlocks.Where(block => !block.Visited && block.TotalHeatLoss != int.MaxValue);
            var lowestTotalHeatLoss = unvisited.Min(block => block.TotalHeatLoss);
            var lowestBatch = unvisited.Where(block => block.TotalHeatLoss == lowestTotalHeatLoss);
            var orderedByClosenessToEnd = lowestBatch.OrderByDescending(block => block.Coordinate.X + block.Coordinate.Y);
            var crucible = orderedByClosenessToEnd.First();

            if (crucible.Step < 3)
            {
                var direction = crucible.Direction;
                var oneStepStraight = new Point(crucible.Coordinate.X, crucible.Coordinate.Y - 1); // N
                if (direction == 'S')
                {
                    oneStepStraight = new Point(crucible.Coordinate.X, crucible.Coordinate.Y + 1);
                }
                else if (direction == 'E')
                {
                    oneStepStraight = new Point(crucible.Coordinate.X + 1, crucible.Coordinate.Y);
                }
                else if (direction == 'W')
                {
                    oneStepStraight = new Point(crucible.Coordinate.X - 1, crucible.Coordinate.Y);
                }

                var straight = cityBlocks.FirstOrDefault(block => block.Coordinate.X == oneStepStraight.X && block.Coordinate.Y == oneStepStraight.Y && block.Step == crucible.Step + 1 && block.Direction == crucible.Direction);
                if (straight != null)
                {
                    straight.TotalHeatLoss = Math.Min(straight.TotalHeatLoss, crucible.TotalHeatLoss + straight.HeatLoss);
                }
            }

            var leftDirection = crucible.Direction == 'N' ? 'W' : crucible.Direction == 'S' ? 'E' : crucible.Direction == 'E' ? 'N' : 'S';
            var oneStepLeft = new Point(crucible.Coordinate.X, crucible.Coordinate.Y - 1); // N
            if (leftDirection == 'S')
            {
                oneStepLeft = new Point(crucible.Coordinate.X, crucible.Coordinate.Y + 1);
            }
            else if (leftDirection == 'E')
            {
                oneStepLeft = new Point(crucible.Coordinate.X + 1, crucible.Coordinate.Y);
            }
            else if (leftDirection == 'W')
            {
                oneStepLeft = new Point(crucible.Coordinate.X - 1, crucible.Coordinate.Y);
            }

            var left = cityBlocks.FirstOrDefault(block => block.Coordinate.X == oneStepLeft.X && block.Coordinate.Y == oneStepLeft.Y && block.Step == 1 && block.Direction == leftDirection);
            if (left != null)
            {
                left.TotalHeatLoss = Math.Min(left.TotalHeatLoss, crucible.TotalHeatLoss + left.HeatLoss);
            }

            var rightDirection = crucible.Direction == 'N' ? 'E' : crucible.Direction == 'S' ? 'W' : crucible.Direction == 'E' ? 'S' : 'N';
            var oneStepRight = new Point(crucible.Coordinate.X, crucible.Coordinate.Y - 1); // N
            if (rightDirection == 'S')
            {
                oneStepRight = new Point(crucible.Coordinate.X, crucible.Coordinate.Y + 1);
            }
            else if (rightDirection == 'E')
            {
                oneStepRight = new Point(crucible.Coordinate.X + 1, crucible.Coordinate.Y);
            }
            else if (rightDirection == 'W')
            {
                oneStepRight = new Point(crucible.Coordinate.X - 1, crucible.Coordinate.Y);
            }

            var right = cityBlocks.FirstOrDefault(block => block.Coordinate.X == oneStepRight.X && block.Coordinate.Y == oneStepRight.Y && block.Step == 1 && block.Direction == rightDirection);
            if (right != null)
            {
                right.TotalHeatLoss = Math.Min(right.TotalHeatLoss, crucible.TotalHeatLoss + right.HeatLoss);
            }

            crucible.Visited = true;

            return cityBlocks;
        }
    }
}
