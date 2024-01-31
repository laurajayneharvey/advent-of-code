namespace AdventOfCode._2022.Day8
{
    public class Day8_Part2
    {
        private readonly Day8 _day8 = new();

        public int Run(string input)
        {
            var lines = input.Trim().Split("\r\n");

            var matrix = _day8.CreateSquareMatrix(lines);
            var transposed = _day8.TransposeSquareMatrix(matrix);

            var highestScenicScore = 0;
            for (var i = 0; i < matrix.Count; i++)
            {
                var currentRow = matrix[i];
                for (var j = 0; j < transposed.Count; j++)
                {
                    var currentColumn = transposed[j];
                    var currentValue = matrix[i][j];

                    var upScore = 0;
                    var up = currentColumn.Take(i).ToList();
                    for (var k = up.Count - 1; k >= 0; k--)
                    {
                        if (up[k] >= currentValue)
                        {
                            upScore++;
                            break;
                        }

                        upScore++;
                    }

                    var leftScore = 0;
                    var left = currentRow.Take(j).ToList();
                    for (var k = left.Count - 1; k >= 0; k--)
                    {
                        if (left[k] >= currentValue)
                        {
                            leftScore++;
                            break;
                        }

                        leftScore++;
                    }

                    var rightScore = 0;
                    var right = currentRow.Skip(j + 1).Take(transposed.Count - (j + 1)).ToList();
                    for (var k = 0; k < right.Count; k++)
                    {
                        if (int.Parse(right[k].ToString()) >= int.Parse(currentValue.ToString()))
                        {
                            rightScore++;
                            break;
                        }

                        rightScore++;
                    }

                    var downScore = 0;
                    var down = currentColumn.Skip(i + 1).Take(matrix.Count - (i + 1)).ToList();
                    for (var k = 0; k < down.Count; k++)
                    {
                        if (down[k] >= currentValue)
                        {
                            downScore++;
                            break;
                        }

                        downScore++;
                    }

                    var scenicScore = upScore * downScore * leftScore * rightScore;
                    if (scenicScore > highestScenicScore)
                    {
                        highestScenicScore = scenicScore;
                    }
                }
            }

            return highestScenicScore;
        }
    }
}
