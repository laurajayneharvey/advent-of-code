namespace AdventOfCode._2023.Day1
{
    public class Day1_Part2
    {
        public int Run(string input)
        {
            var lines = input.Split("\r\n");
            var sum = 0;

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var lineLength = line.ToCharArray().Length;
                char? firstDigit = '0';
                char? lastDigit = '0';

                for (var j = 0; j < lineLength; j++)
                {
                    var startIndex = 0;
                    var endIndex = j + 1;
                    var partial = line[startIndex..endIndex];
                    firstDigit = FindNumber(partial);
                    if (firstDigit != null)
                    {
                        break;
                    }
                }

                for (var j = 0; j < lineLength; j++)
                {
                    var startIndex = lineLength - 1 - j;
                    var endIndex = lineLength;
                    var partial = line[startIndex..endIndex];
                    lastDigit = FindNumber(partial);
                    if (lastDigit != null)
                    {
                        break;
                    }
                }

                var doubleDigit = int.Parse($"{firstDigit}{lastDigit}");
                sum += doubleDigit;
            }

            return sum;
        }

        private static string ReplaceSpeltNumber(string input)
        {
            return input
            .Replace("one", "1")
            .Replace("two", "2")
            .Replace("three", "3")
            .Replace("four", "4")
            .Replace("five", "5")
            .Replace("six", "6")
            .Replace("seven", "7")
            .Replace("eight", "8")
            .Replace("nine", "9");
        }

        private static char? FindNumber(string input)
        {
            var digits = input.ToCharArray().Where(c => char.IsNumber(c));
            if (digits.Any())
            {
                return digits.ElementAt(0);
            }

            input = ReplaceSpeltNumber(input);

            digits = input.ToCharArray().Where(c => char.IsNumber(c));
            if (digits.Any())
            {
                return digits.ElementAt(0);
            }

            return null;
        }
    }
}
