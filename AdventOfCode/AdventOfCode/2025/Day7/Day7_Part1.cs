namespace AdventOfCode._2025.Day7
{
    public class Day7_Part1
    {
        public int Run(string input)
        {
            var coordinates = new List<Coordinate>();

            var rows = input.Split("\r\n");
            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var columns = rows[rowIndex].ToCharArray();
                for (var columnIndex = 0; columnIndex < columns.Length; columnIndex++)
                {
                    coordinates.Add(new Coordinate
                    {
                        X = columnIndex,
                        Y = rowIndex,
                        Value = columns[columnIndex]
                    });
                }
            }

            while (coordinates.Where(c => c.IsBeam && !c.HasBeenChecked).Any())
            {
                foreach (var uncheckedBeam in coordinates.Where(c => c.IsBeam && !c.HasBeenChecked))
                {
                    var below = coordinates.FirstOrDefault(c => c.X == uncheckedBeam.X && c.Y == uncheckedBeam.Y + 1);

                    if (below != null)
                    {
                        if (below.Value == '.')
                        {
                            coordinates.First(c => c.X == uncheckedBeam.X && c.Y == uncheckedBeam.Y + 1).Value = '|';
                        }
                        else if (below.Value == '^')
                        {
                            var left = coordinates.FirstOrDefault(c => c.X == uncheckedBeam.X - 1 && c.Y == uncheckedBeam.Y + 1);
                            if (left != null)
                            {
                                coordinates.First(c => c.X == uncheckedBeam.X - 1 && c.Y == uncheckedBeam.Y + 1).Value = '|';
                            }

                            var right = coordinates.FirstOrDefault(c => c.X == uncheckedBeam.X + 1 && c.Y == uncheckedBeam.Y + 1);
                            if (right != null)
                            {
                                coordinates.First(c => c.X == uncheckedBeam.X + 1 && c.Y == uncheckedBeam.Y + 1).Value = '|';
                            }
                        }
                    }

                    uncheckedBeam.HasBeenChecked = true;
                }
            }

            var count = 0;
            foreach (var splitter in coordinates.Where(c => c.Value == '^'))
            {
                var above = coordinates.FirstOrDefault(c => c.X == splitter.X && c.Y == splitter.Y - 1);
                if (above != null && above.IsBeam)
                {
                    count++;
                }
            }

            return count;
        }

        private class Coordinate
        {
            public int X;
            public int Y;

            public char Value;

            public bool IsBeam => Value == 'S' || Value == '|';
            public bool HasBeenChecked = false;
        }
    }
}
