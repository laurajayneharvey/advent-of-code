using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day5
{
    public class Day5_Part1
    {
        public double Run(string input)
        {
            var tables = input.Split("\r\n\r\n");

            var almanac = new List<AlmanacEntry>();
            var seeds = new List<double>();
            var tableIndex = 0;
            tables.ToList().ForEach(table =>
            {
                if (tableIndex == 0)
                {
                    var seedParts = Regex.Split(table, ": ");
                    seeds = seedParts[1].Split(" ").Select(s => double.Parse(s)).ToList();
                    tableIndex++;
                    return;
                }

                var lines = table.Split("\n");
                var heading = lines[0];
                var headingParts = heading.Split(" ")[0].Split("-");
                var source = headingParts[0].Trim();
                var destination = headingParts[2];

                var rangeLines = lines.ToList();
                rangeLines.RemoveRange(0, 1);
                var ranges = new List<Range>();
                for (var i = 0; i < rangeLines.Count; i++)
                {
                    var parts = rangeLines[i].Split(" ");
                    var destinationStart = double.Parse(parts[0]);
                    var sourceStart = double.Parse(parts[1]);
                    var rangeLength = double.Parse(parts[2]);
                    var range = new Range
                    {
                        SourceStart = sourceStart,
                        SourceEnd = sourceStart + rangeLength - 1,
                        SourceToDestination = destinationStart - sourceStart
                    };
                    ranges.Add(range);
                }

                almanac.Add(new AlmanacEntry
                {
                    Destination = destination,
                    Ranges = ranges
                });
            });

            var minLocation = double.MaxValue;
            foreach (var seed in seeds)
            {
                var source = seed;
                foreach (var almanacEntry in almanac)
                {
                    var matchingRange = almanacEntry.Ranges.FirstOrDefault(range => source >= range.SourceStart && source <= range.SourceEnd);

                    if (matchingRange != null)
                    {
                        source += matchingRange.SourceToDestination;
                    }
                }

                minLocation = Math.Min(minLocation, source);
            }

            return minLocation;
        }
    }

    public class Range
    {
        public double SourceStart;
        public double SourceEnd;
        public double SourceToDestination;
    }

    public class AlmanacEntry
    {
        public required string Destination;
        public List<Range> Ranges = [];
    }
}