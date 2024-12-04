using System.Drawing;

namespace AdventOfCode._2024.Day4
{
    public class Day4_Part2
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

            var As = letterCoordinates.Where(item => item.Letter == 'A');

            var count = 0;
            foreach (var a in As)
            {
                /*
                 *      M.M
                 *      .A.
                 *      S.S
                 */
                var mNorth = letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == a.Coordinate.X - 1 &&
                    item.Coordinate.Y == a.Coordinate.Y - 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == a.Coordinate.X + 1 &&
                    item.Coordinate.Y == a.Coordinate.Y - 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == a.Coordinate.X - 1 &&
                    item.Coordinate.Y == a.Coordinate.Y + 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == a.Coordinate.X + 1 &&
                    item.Coordinate.Y == a.Coordinate.Y + 1) != null;
                if (mNorth)
                {
                    count++;
                }


                /*
                 *      M.S
                 *      .A.
                 *      M.S
                 */
                var mWest = letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == a.Coordinate.X - 1 &&
                    item.Coordinate.Y == a.Coordinate.Y - 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == a.Coordinate.X - 1 &&
                    item.Coordinate.Y == a.Coordinate.Y + 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == a.Coordinate.X + 1 &&
                    item.Coordinate.Y == a.Coordinate.Y - 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == a.Coordinate.X + 1 &&
                    item.Coordinate.Y == a.Coordinate.Y + 1) != null;
                if (mWest)
                {
                    count++;
                }

                /*
                 *      S.S
                 *      .A.
                 *      M.M
                 */
                var mSouth = letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == a.Coordinate.X - 1 &&
                    item.Coordinate.Y == a.Coordinate.Y + 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == a.Coordinate.X + 1 &&
                    item.Coordinate.Y == a.Coordinate.Y + 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == a.Coordinate.X - 1 &&
                    item.Coordinate.Y == a.Coordinate.Y - 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == a.Coordinate.X + 1 &&
                    item.Coordinate.Y == a.Coordinate.Y - 1) != null;
                if (mSouth)
                {
                    count++;
                }

                /*
                 *      S.M
                 *      .A.
                 *      S.M
                 */
                var mEast = letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == a.Coordinate.X + 1 &&
                    item.Coordinate.Y == a.Coordinate.Y - 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'M' &&
                    item.Coordinate.X == a.Coordinate.X + 1 &&
                    item.Coordinate.Y == a.Coordinate.Y + 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == a.Coordinate.X - 1 &&
                    item.Coordinate.Y == a.Coordinate.Y - 1) != null &&
                letterCoordinates.FirstOrDefault(item =>
                    item.Letter == 'S' &&
                    item.Coordinate.X == a.Coordinate.X - 1 &&
                    item.Coordinate.Y == a.Coordinate.Y + 1) != null;
                if (mEast)
                {
                    count++;
                }
            }

            return count;
        }
    }
}