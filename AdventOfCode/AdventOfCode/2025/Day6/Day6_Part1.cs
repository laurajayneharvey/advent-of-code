using System.Reflection.Metadata;

namespace AdventOfCode._2025.Day6
{
    public class Day6_Part1
    {
        public long Run(string input)
        {
            var rows = input.Split("\r\n");
            var columnCount = rows[0].Split(' ').Where(x => x != string.Empty).Count();

            var operands = new Dictionary<int, List<long>>();
            var operators = new List<char>();

            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var columns = rows[rowIndex].Split(' ').Where(x => x != string.Empty).ToList();
                for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    if (rowIndex == rows.Length - 1)
                    {
                        operators.Add(columns[columnIndex][0]);
                    }
                    else 
                    {
                        if (!operands.ContainsKey(columnIndex))
                        {
                            operands.Add(columnIndex, []);
                        }
                        operands[columnIndex].Add(long.Parse(columns[columnIndex]));
                    }
                }
            }

            long overall = 0;
            for (var i = 0; i < operators.Count; i++)
            {
                if (operators[i] == '+')
                {
                    var result = operands[i].Sum();
                    overall += result;
                }
                else
                {
                    long result = 1;
                    foreach(var operand in operands[i])
                    {
                        result *= operand;
                    }
                    overall += result;
                }
            }

            return overall;
        }
    }
}
