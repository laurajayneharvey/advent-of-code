using System.Collections.Immutable;

namespace AdventOfCode._2023.Day12
{
    public class Day12
    {
        public long Run(string input, bool unfold = false)
        {
            var rows = input.Split("\r\n");
            long overallCount = 0;

            foreach (var row in rows)
            {
                var formats = row.Split(" ");

                var repeat = unfold ? 5 : 1;

                var format1Repeats = Enumerable.Range(0, repeat).Select(x => formats[0]);
                var format1 = string.Join("?", format1Repeats);

                var format2Repeats = formats[1].Split(',').Reverse().Select(int.Parse);
                var format2 = new List<int>();
                Enumerable.Range(0, repeat).ToList().ForEach(x => format2.AddRange(format2Repeats));

                var cachedPatterns = new Dictionary<(string format1, ImmutableStack<int> format2), long>();
                var rowCount = FindMatchesInCache(cachedPatterns, format1, ImmutableStack.CreateRange(format2));
                overallCount += rowCount;
            }

            return overallCount;
        }

        private static long FindMatchesInCache(Dictionary<(string format1, ImmutableStack<int> format2), long> cache, string format1, ImmutableStack<int> format2)
        {
            var key = (format1, format2);

            if (!cache.TryGetValue(key, out var _))
            {
                var value = FindMatches(cache, format1, format2);
                cache.Add(key, value);
            }

            return cache[key];
        }

        private static long FindMatches(Dictionary<(string format1, ImmutableStack<int> format2), long> cache, string format1, ImmutableStack<int> format2)
        {
            // run out of both formats at the same time :)
            if (format1.Length == 0 && format2.IsEmpty)
            {
                return 1;
            }

            // gate check before picking up the first char of remaining format1 string
            if (format1.Length == 0)
            {
                return 0;
            }

            var currentChar = format1[0];

            if (currentChar == '.')
            {
                // skip the dots
                return FindMatchesInCache(cache, format1[format1.TakeWhile(s => s == '.').Count()..], format2);
            }
            else if (currentChar == '#')
            {
                // no more groups to take from :(
                if (format2.IsEmpty)
                {
                    return 0;
                }

                var currentGroup = format2.First();

                // not enough left to make group :(
                if (format1.Length < currentGroup)
                {
                    return 0;
                }

                if (format1.Length >= currentGroup)
                {
                    var hashOrPossibleHash = format1[..currentGroup].All(x => x == '#' || x == '?');
                    if (format1.Length == currentGroup)
                    {
                        // end of format1
                        return hashOrPossibleHash ? FindMatchesInCache(cache, format1[currentGroup..], format2.Pop()) : 0;
                    }

                    // else format1.Length > currentGroup
                    var followedByDotOrPossibleDot = format1.ElementAt(currentGroup) == '.' || format1.ElementAt(currentGroup) == '?';
                    return hashOrPossibleHash && followedByDotOrPossibleDot ? FindMatchesInCache(cache, format1[(currentGroup + 1)..], format2.Pop()) : 0;
                }
            }

            // ?
            var hash = FindMatchesInCache(cache, string.Concat("#", format1.AsSpan(1)), format2);
            var dot = FindMatchesInCache(cache, string.Concat(".", format1.AsSpan(1)), format2);

            return hash + dot;
        }
    }
}