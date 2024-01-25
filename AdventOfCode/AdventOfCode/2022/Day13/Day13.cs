using System.Text.RegularExpressions;

namespace AdventOfCode._2022.Day13
{
    public class Day13
    {
        private static readonly Regex _bracketsRegex = new(@"(\[[\dA-Za-z,]+\])|(\[\])");

        public bool? ProcessArray(int leftPairIndex, int rightPairIndex, string left, string right,
            Dictionary<(int pairIndex, string id), string> leftArrays, Dictionary<(int pairIndex, string id), string> rightArrays)
        {
            var leftItems = GetItems(leftPairIndex, left, leftArrays);
            var rightItems = GetItems(rightPairIndex, right, rightArrays);

            for (var i = 0; i < Math.Min(leftItems.Count, rightItems.Count); i++)
            {
                // both numbers
                if (int.TryParse(leftItems[i], out var leftInt) && int.TryParse(rightItems[i], out var rightInt))
                {
                    if (leftInt != rightInt)
                    {
                        return leftInt < rightInt;
                    }

                    continue;
                }

                // left is a number, convert it to an array
                if (int.TryParse(leftItems[i], out var _))
                {
                    leftItems[i] = $"[{leftItems[i]}]";
                }

                // right is a number, convert it to an array
                if (int.TryParse(rightItems[i], out var _))
                {
                    rightItems[i] = $"[{rightItems[i]}]";
                }

                // both arrays
                var arrayResult = ProcessArray(leftPairIndex, rightPairIndex, leftItems[i], rightItems[i], leftArrays, rightArrays);
                if (arrayResult != null)
                {
                    return arrayResult;
                }

                continue;
            }

            // individual items in arrays assessed, now check size of array
            if (leftItems.Count != rightItems.Count)
            {
                return leftItems.Count < rightItems.Count;
            }

            return null;
        }

        public string CreateArrays(int pairIndex, string line, Dictionary<(int pairIndex, string id), string> arrays)
        {
            var currentKey = 65;
            while (_bracketsRegex.Match(line) != null && _bracketsRegex.Match(line).ToString() != string.Empty)
            {
                var match = _bracketsRegex.Match(line).ToString();
                var key = ((char)currentKey).ToString();
                arrays[(pairIndex, key)] = match;
                line = line.Replace(match, key);
                currentKey++;
                if (currentKey == 91)
                {
                    currentKey = 97;
                }
            }

            return line;
        }

        private List<string> GetItems(int pairIndex, string item, Dictionary<(int pairIndex, string id), string> arrays)
        {
            if (string.IsNullOrEmpty(item))
            {
                return [];
            }

            var array = arrays.TryGetValue((pairIndex, item), out var _) ? arrays[(pairIndex, item)] : item;

            var items = array.Substring(1, array.Length - 2).Split(',').ToList();

            if (items.Count == 1 && items.First() == string.Empty)
            {
                return [];
            }

            return items;
        }
    }
}
