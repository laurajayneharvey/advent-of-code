using AdventOfCode._2024.Day6;
using System.Drawing;

namespace AdventOfCode._2024.Day10
{
    public class Day10_Part1
    {
        public long Run(string input)
        {
            var positions = GetPositions(input);

            var possibleTrailHeads = positions.Where(p => p.Height == 0);
            var trailHeadScoreSum = 0;

            foreach (var position in possibleTrailHeads)
            {
                var oldList = position.NextTo;
                while (oldList.FirstOrDefault() != null && oldList.First().Height < 9)
                {
                    var newList = new List<Position>();
                    foreach (var old in oldList)
                    {
                        newList.AddRange(old.NextTo);
                    }
                    oldList = newList.Distinct().ToList();
                }

                trailHeadScoreSum += oldList.Count;
            }

            return trailHeadScoreSum;
        }

        private static List<Position> GetPositions(string input)
        {
            var rows = input.Split("\r\n");
            var positions = new List<Position>();
            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < rows[0].Length; columnIndex++)
                {
                    positions.Add(new Position
                    {
                        Coordinate = new Point { X = columnIndex, Y = rowIndex },
                        Height = int.Parse(rows[rowIndex][columnIndex].ToString())
                    });
                }
            }

            foreach (var position in positions)
            {
                var above = positions.FirstOrDefault(p =>
                    p.Coordinate.X == position.Coordinate.X &&
                    p.Coordinate.Y == position.Coordinate.Y - 1 &&
                    p.Height == position.Height + 1
                );
                if (above != null)
                {
                    position.NextTo.Add(above);
                }

                var below = positions.FirstOrDefault(p =>
                    p.Coordinate.X == position.Coordinate.X &&
                    p.Coordinate.Y == position.Coordinate.Y + 1 &&
                    p.Height == position.Height + 1
                );
                if (below != null)
                {
                    position.NextTo.Add(below);
                }

                var left = positions.FirstOrDefault(p =>
                    p.Coordinate.X == position.Coordinate.X - 1 &&
                    p.Coordinate.Y == position.Coordinate.Y &&
                    p.Height == position.Height + 1
                );
                if (left != null)
                {
                    position.NextTo.Add(left);
                }

                var right = positions.FirstOrDefault(p =>
                    p.Coordinate.X == position.Coordinate.X + 1 &&
                    p.Coordinate.Y == position.Coordinate.Y &&
                    p.Height == position.Height + 1
                );
                if (right != null)
                {
                    position.NextTo.Add(right);
                }
            }

            return positions;
        }
    }

    public class Position
    {
        public Point Coordinate { get; set; }
        public int Height { get; set; }
        public List<Position> NextTo { get; set; } = [];
    }
}
