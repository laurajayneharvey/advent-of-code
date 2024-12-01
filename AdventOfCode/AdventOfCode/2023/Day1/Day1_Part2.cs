namespace AdventOfCode._2023.Day1
{
    public class Day1_Part2
    {
        private string ReplaceSpeltNumber(string input)
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

        private char? FindNumber(string input)
        {
            var digits = input.ToCharArray().Where(c => char.IsNumber(c));
            if (digits.Count() > 0)
            {
                return digits.ElementAt(0);
            }

            input = ReplaceSpeltNumber(input);
            digits = input.ToCharArray().Where(c => char.IsNumber(c));
            if (digits.Count() > 0)
            {
                return digits.ElementAt(0);
            }

            return null;
        }

        public int Run(string input)
        {
            var lines = input.Split("\r\n");
            var sum = 0;

            for (var i = 0; i < lines.Count(); i++)
            {
                var line = lines[i];
                var lineLength = line.ToCharArray().Count();
                char? firstDigit = '0';
                char? lastDigit = '0';

                for (var j = 0; j < lineLength; j++)
                {
                    var startIndex = 0;
                    var endIndex = j + 1;
                    var length = endIndex - startIndex;
                    var partial = line.Substring(startIndex, length);
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
                    var length = endIndex - startIndex;
                    var partial = line.Substring(startIndex, length);
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
    }
}
