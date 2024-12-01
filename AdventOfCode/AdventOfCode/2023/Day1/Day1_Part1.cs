namespace AdventOfCode._2023.Day1
{
    public class Day1_Part1
    {
        public int Run(string input)
        {
            var lines = input.Split("\r\n");
            var sum = 0;

            for (var i = 0; i < lines.Length; i++)
            {
                var digits = lines[i].ToCharArray().Where(c => char.IsNumber(c));
                var firstDigit = digits.First();
                var lastDigit = digits.ElementAt(digits.Count() - 1);
                var doubleDigit = int.Parse($"{firstDigit}{lastDigit}");
                sum += doubleDigit;
            }

            return sum;
        }
    }
}
