namespace AdventOfCode._2022.Day8
{
    public class Day8_Part1
    {
        private readonly Day8 _day8 = new();

        public int Run(string input)
        {
            var lines = input.Trim().Split("\r\n");

            var matrix = _day8.CreateSquareMatrix(lines);
            var transposed = _day8.TransposeSquareMatrix(matrix);

            var edge = 0;
            var interior = 0;
            for (var i = 0; i < matrix.Count(); i++)
            {
                var currentRow = matrix[i];
                for (var j = 0; j < transposed.Count(); j++)
                {
                    var currentValue = currentRow[j].ToString();

                    if (i == 0 || i == matrix.Count() - 1 || j == 0 || j == transposed.Count() - 1)
                    {
                        edge++;
                        continue;
                    }

                    var left = currentRow.Take(j);
                    if (!left.Any(tree => int.Parse(tree.ToString()) >= int.Parse(currentValue)))
                    {
                        interior++;
                        continue;
                    }
                    var right = currentRow.Skip(j + 1).Take(transposed.Count() - (j + 1));
                    if (!right.Any(tree => int.Parse(tree.ToString()) >= int.Parse(currentValue)))
                    {
                        interior++;
                        continue;
                    }

                    var currentColumn = transposed[j];
                    var above = currentColumn.Take(i);
                    if (!above.Any(tree => int.Parse(tree.ToString()) >= int.Parse(currentValue)))
                    {
                        interior++;
                        continue;
                    }
                    var below = currentColumn.Skip(i + 1).Take(matrix.Count() - (i + 1));
                    if (!below.Any(tree => int.Parse(tree.ToString()) >= int.Parse(currentValue)))
                    {
                        interior++;
                        continue;
                    }
                }
            }

            return edge + interior;
        }
    }
}
