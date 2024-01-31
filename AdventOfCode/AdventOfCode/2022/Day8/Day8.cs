namespace AdventOfCode._2022.Day8
{
    public class Day8
    {
        public List<List<char>> TransposeSquareMatrix(List<List<char>> matrix)
        {
            var transposed = new List<List<char>>();
            for (int i = 0; i < matrix.Count; i++)
            {
                transposed.Add([]);
                for (int j = 0; j < matrix.Count; j++)
                {
                    transposed[i].Add('x');
                }
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix.Count; j++)
                {
                    transposed[j][i] = matrix[i][j];
                }
            }

            return transposed;
        }

        public List<List<char>> CreateSquareMatrix(string[] lines)
        {
            var matrix = new List<List<char>>();
            foreach (string line in lines)
            {
                matrix.Add([.. line.ToCharArray()]);
            }

            return matrix;
        }
    }
}
