using AdventOfCode._2023.Day10;
using System.Drawing;

namespace AdventOfCode._2024.Day4
{
    public class Day4_Part1
    {
        public int Run(string input)
        {
            var letterCoordinates = new List<LetterCoordinate>();

            var rows = input.Split("\r\n");
            for (var i = 0; i < rows.Length; i++)
            {
                var columns = rows[i].ToCharArray();
                for (var j = 0; j < columns.Length; j++)
                {
                    letterCoordinates.Add(new LetterCoordinate
                    {
                        Letter = columns[j],
                        Coordinate = new Point
                        {
                            X = j,
                            Y = i
                        }
                    });
                }
            }

            var Xs = letterCoordinates.Where(item => item.Letter == 'X');

            var count = 0;
            foreach (var x in Xs)
            {
                var north = letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == x.Coordinate.X &&
                    item.Coordinate.Y == x.Coordinate.Y - 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'A' &&
                    item.Coordinate.X == x.Coordinate.X &&
                    item.Coordinate.Y == x.Coordinate.Y - 2) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == x.Coordinate.X &&
                    item.Coordinate.Y == x.Coordinate.Y - 3) != null;
                if (north)
                {
                    count++;
                }

                var south = letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == x.Coordinate.X &&
                    item.Coordinate.Y == x.Coordinate.Y + 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'A' &&
                    item.Coordinate.X == x.Coordinate.X &&
                    item.Coordinate.Y == x.Coordinate.Y + 2) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == x.Coordinate.X &&
                    item.Coordinate.Y == x.Coordinate.Y + 3) != null;
                if (south)
                {
                    count++;
                }

                var west = letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == x.Coordinate.X - 1 &&
                    item.Coordinate.Y == x.Coordinate.Y) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'A' &&
                    item.Coordinate.X == x.Coordinate.X - 2 &&
                    item.Coordinate.Y == x.Coordinate.Y) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == x.Coordinate.X - 3 &&
                    item.Coordinate.Y == x.Coordinate.Y) != null;
                if (west)
                {
                    count++;
                }

                var east = letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == x.Coordinate.X + 1 &&
                    item.Coordinate.Y == x.Coordinate.Y) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'A' &&
                    item.Coordinate.X == x.Coordinate.X + 2 &&
                    item.Coordinate.Y == x.Coordinate.Y) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == x.Coordinate.X + 3 &&
                    item.Coordinate.Y == x.Coordinate.Y) != null;
                if (east)
                {
                    count++;
                }

                var northwest = letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == x.Coordinate.X - 1 &&
                    item.Coordinate.Y == x.Coordinate.Y - 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'A' &&
                    item.Coordinate.X == x.Coordinate.X - 2 &&
                    item.Coordinate.Y == x.Coordinate.Y - 2) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == x.Coordinate.X - 3 &&
                    item.Coordinate.Y == x.Coordinate.Y - 3) != null;
                if (northwest)
                {
                    count++;
                }

                var southwest = letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == x.Coordinate.X - 1 &&
                    item.Coordinate.Y == x.Coordinate.Y + 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'A' &&
                    item.Coordinate.X == x.Coordinate.X - 2 &&
                    item.Coordinate.Y == x.Coordinate.Y + 2) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == x.Coordinate.X - 3 &&
                    item.Coordinate.Y == x.Coordinate.Y + 3) != null;
                if (southwest)
                {
                    count++;
                }

                var northeast = letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == x.Coordinate.X + 1 &&
                    item.Coordinate.Y == x.Coordinate.Y - 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'A' &&
                    item.Coordinate.X == x.Coordinate.X + 2 &&
                    item.Coordinate.Y == x.Coordinate.Y - 2) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == x.Coordinate.X + 3 &&
                    item.Coordinate.Y == x.Coordinate.Y - 3) != null;
                if (northeast)
                {
                    count++;
                }

                var southeast = letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == x.Coordinate.X + 1 &&
                    item.Coordinate.Y == x.Coordinate.Y + 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'A' &&
                    item.Coordinate.X == x.Coordinate.X + 2 &&
                    item.Coordinate.Y == x.Coordinate.Y + 2) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == x.Coordinate.X + 3 &&
                    item.Coordinate.Y == x.Coordinate.Y + 3) != null;
                if (southeast)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
