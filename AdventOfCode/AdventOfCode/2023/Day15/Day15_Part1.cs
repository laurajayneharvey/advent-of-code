using System.Text;

namespace AdventOfCode._2023.Day15
{
    public class Day15_Part1
    {
        public int Run(string input)
        {
            var steps = input.Split(',');
            var overall = 0;
            foreach (var step in steps)
            {
                var result = HashAlgorithm(step);
                overall += result;
            }

            return overall;
        }

        public int HashAlgorithm(string input)
        {
            var ascii = Encoding.ASCII.GetBytes(input);
            var currentValue = 0;
            for (var i = 0; i < input.Length; i++)
            {
                currentValue += ascii[i];
                currentValue *= 17;
                currentValue %= 256;
            }
            return currentValue;
        }
    }
}
