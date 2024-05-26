using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day5
{
    public partial class Day5_Part2
    {
        public double Run(string input)
        {
            var tables = input.Split("\r\n\r\n").ToList();
            var ranges = BuildSeedRanges(tables[0]);
            tables.RemoveRange(0, 1);
            var almanac = BuildAlmanac(tables);

            foreach (var almanacEntry in almanac)
            {
                ranges = GetNextRanges(ranges, almanacEntry);
            }

            ranges = [.. ranges.OrderBy(x => x.Start)];

            return ranges.First().Start;
        }

        private static List<AlmanacEntryPart2> BuildAlmanac(IEnumerable<string> tables)
        {
            var almanac = new List<AlmanacEntryPart2>();
            tables.ToList().ForEach(table =>
            {
                var lines = table.Split("\r\n");
                var heading = lines[0];
                var headingParts = heading.Split(' ')[0].Split("-");
                var source = headingParts[0].Trim();
                var destination = headingParts[2];

                var rangeLines = lines.ToList();
                rangeLines.RemoveRange(0, 1);
                var ranges = new List<AlmanacRange>();
                for (var i = 0; i < rangeLines.Count; i++)
                {
                    var parts = rangeLines[i].Split(" ");
                    var destinationStart = double.Parse(parts[0]);
                    var sourceStart = double.Parse(parts[1]);
                    var rangeLength = double.Parse(parts[2]);
                    var range = new AlmanacRange
                    {
                        SourceToDestination = destinationStart - sourceStart,
                        SourceStart = sourceStart,
                        SourceEnd = sourceStart + rangeLength - 1
                    };

                    ranges.Add(range);
                }

                almanac.Add(new AlmanacEntryPart2
                {
                    Destination = destination,
                    Ranges = ranges
                });
            });

            return almanac;
        }

        private static List<RangePart2> BuildSeedRanges(string table)
        {
            var seedRanges = new List<RangePart2>();
            var seedLineParts = ColonSeparator().Split(table);
            var seeds = seedLineParts[1].Split(" ");
            for (var i = 0; i < seeds.Length; i++)
            {
                if (i % 2 == 0)
                {
                    var start = double.Parse(seeds[i]);
                    var end = start + double.Parse(seeds[i + 1]) - 1;
                    seedRanges.Add(new RangePart2(start, end));
                }
            }

            return seedRanges;
        }

        private static bool HasIntersection(RangePart2 range, AlmanacRange almanacRange)
        {
            var rangeStartIsInAlmanacRange = range.Start >= almanacRange.SourceStart && range.Start <= almanacRange.SourceEnd;
            var rangeEndIsInAlmanacRange = range.End >= almanacRange.SourceStart && range.End <= almanacRange.SourceEnd;

            var almanacRangeStartIsInRange = almanacRange.SourceStart >= range.Start && almanacRange.SourceStart <= range.End;
            var almanacRangeEndIsInRange = almanacRange.SourceEnd >= range.Start && almanacRange.SourceEnd <= range.End;

            var equal = range.Start == almanacRange.SourceStart && range.End == almanacRange.SourceEnd;
            var whollyContained = rangeStartIsInAlmanacRange && rangeEndIsInAlmanacRange;
            var whollyContains = almanacRangeStartIsInRange && almanacRangeEndIsInRange;

            return equal || whollyContained || whollyContains || rangeStartIsInAlmanacRange || rangeEndIsInAlmanacRange;
        }

        private static List<RangePart2> GetIntersectionRanges(RangePart2 sourceRange, IEnumerable<AlmanacRange> almanacRangesWithIntersection)
        {
            var almanacRange = almanacRangesWithIntersection.First();

            var rangeStartIsInAlmanacRange = sourceRange.Start >= almanacRange.SourceStart && sourceRange.Start <= almanacRange.SourceEnd;
            var rangeEndIsInAlmanacRange = sourceRange.End >= almanacRange.SourceStart && sourceRange.End <= almanacRange.SourceEnd;

            var almanacRangeStartIsInRange = almanacRange.SourceStart >= sourceRange.Start && almanacRange.SourceStart <= sourceRange.End;
            var almanacRangeEndIsInRange = almanacRange.SourceEnd >= sourceRange.Start && almanacRange.SourceEnd <= sourceRange.End;

            var equal = sourceRange.Start == almanacRange.SourceStart && sourceRange.End == almanacRange.SourceEnd;
            var whollyContained = rangeStartIsInAlmanacRange && rangeEndIsInAlmanacRange;
            var whollyContains = almanacRangeStartIsInRange && almanacRangeEndIsInRange;

            if (equal || whollyContained)
            {
                var intersection = new RangePart2(sourceRange.Start + almanacRange.SourceToDestination, sourceRange.End + almanacRange.SourceToDestination);
                return [intersection];
            }
            else if (whollyContains || rangeStartIsInAlmanacRange || rangeEndIsInAlmanacRange)
            {
                var destinationRanges = new List<RangePart2>();

                var orderedAlmanacRanges = almanacRangesWithIntersection.OrderBy(x => x.SourceStart).ToList();
                almanacRange = orderedAlmanacRanges.First();

                var current = sourceRange.Start;
                while (current < sourceRange.End && almanacRange != null)
                {
                    RangePart2 range;
                    double end = 0;
                    if (almanacRange == null)
                    {
                        // no adjustments needed
                        end = sourceRange.End;
                        range = new RangePart2(current, end);
                    }
                    else if (current < almanacRange.SourceStart)
                    {
                        end = almanacRange.SourceStart - 1;
                        range = new RangePart2(current, end);
                    }
                    else
                    {
                        end = Math.Min(sourceRange.End, almanacRange.SourceEnd);
                        range = new RangePart2(current + almanacRange.SourceToDestination, end + almanacRange.SourceToDestination);
                    }

                    orderedAlmanacRanges.RemoveAt(0);
                    almanacRange = orderedAlmanacRanges.FirstOrDefault();
                    current = end + 1;
                    destinationRanges.Add(range);
                }

                return destinationRanges;
            }

            return [];
        }

        private static List<RangePart2> GetNextRanges(RangePart2 sourceRange, AlmanacEntryPart2 almanacEntry)
        {
            var destinationRanges = new List<RangePart2>();

            var almanacRangesWithIntersection = almanacEntry.Ranges.Where(x => HasIntersection(sourceRange, x));

            if (!almanacRangesWithIntersection.Any())
            {
                // no adjustments needed
                destinationRanges.Add(sourceRange);
            }
            else
            {
                var adjustedRanges = GetIntersectionRanges(sourceRange, almanacRangesWithIntersection);
                destinationRanges.AddRange(adjustedRanges);
            }

            return destinationRanges;
        }

        private static List<RangePart2> GetNextRanges(List<RangePart2> sourceRanges, AlmanacEntryPart2 almanacEntry)
        {
            var destinationRanges = new List<RangePart2>();

            foreach (var sourceRange in sourceRanges)
            {
                destinationRanges.AddRange(GetNextRanges(sourceRange, almanacEntry));
            }

            return destinationRanges;
        }

        [GeneratedRegex(": ")]
        private static partial Regex ColonSeparator();
    }

    public class RangePart2(double start, double end)
    {
        public double Start = start;
        public double End = end;
    }

    public class AlmanacRange
    {
        public double SourceToDestination;
        public double SourceStart;
        public double SourceEnd;
    }

    public class AlmanacEntryPart2
    {
        public required string Destination;
        public List<AlmanacRange> Ranges = [];
    }
}