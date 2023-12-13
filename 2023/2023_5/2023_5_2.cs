using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Range
{
    public Range(double start, double end)
    {
        Start = start;
        End = end;
    }

    public double Start;
    public double End;
}

public class AlmanacRange
{
    public double SourceToDestination;
    public double SourceStart;
    public double SourceEnd;
}

public class AlmanacEntry
{
    public string Destination;
    public List<AlmanacRange> Ranges;
}

public class IfYouGiveASeedAFertilizer
{
    private List<AlmanacEntry> BuildAlmanac(IEnumerable<string> tables)
    {
        var almanac = new List<AlmanacEntry>();
        tables.ToList().ForEach(table =>
        {
            var lines = table.Split('\n');
            var heading = lines[0];
            var headingParts = heading.Split(' ')[0].Split('-');
            var source = headingParts[0].Trim();
            var destination = headingParts[2];

            var rangeLines = lines.ToList();
            rangeLines.RemoveRange(0, 1);
            var ranges = new List<AlmanacRange>();
            for (var i = 0; i < rangeLines.Count; i++)
            {
                var parts = rangeLines[i].Split(' ');
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

            almanac.Add(new AlmanacEntry
            {
                Destination = destination,
                Ranges = ranges
            });
        });

        return almanac;
    }

    private List<Range> BuildSeedRanges(string table)
    {
        var seedRanges = new List<Range>();
        var seedLineParts = Regex.Split(table, ": ");
        var seeds = seedLineParts[1].Split(' ');
        for (var i = 0; i < seeds.Count(); i++)
        {
            if (i % 2 == 0)
            {
                var start = double.Parse(seeds[i]);
                var end = start + double.Parse(seeds[i + 1]) - 1;
                seedRanges.Add(new Range(start, end));
            }
        }

        return seedRanges;
    }

    private bool HasIntersection(Range range, AlmanacRange almanacRange)
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

    private List<Range> GetIntersectionRanges(Range sourceRange, IEnumerable<AlmanacRange> almanacRangesWithIntersection)
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
            var intersection = new Range(sourceRange.Start + almanacRange.SourceToDestination, sourceRange.End + almanacRange.SourceToDestination);
            return new List<Range> { intersection };
        }
        else if (whollyContains || rangeStartIsInAlmanacRange || rangeEndIsInAlmanacRange)
        {
            var destinationRanges = new List<Range>();

            var orderedAlmanacRanges = almanacRangesWithIntersection.OrderBy(x => x.SourceStart).ToList();
            almanacRange = orderedAlmanacRanges.First();

            var current = sourceRange.Start;
            while (current < sourceRange.End && almanacRange != null)
            {
                Range range;
                double end = 0;
                if (almanacRange == null)
                {
                    // no adjustments needed
                    end = sourceRange.End;
                    range = new Range(current, end);
                }
                else if (current < almanacRange.SourceStart)
                {
                    end = almanacRange.SourceStart - 1;
                    range = new Range(current, end);
                }
                else
                {
                    end = Math.Min(sourceRange.End, almanacRange.SourceEnd);
                    range = new Range(current + almanacRange.SourceToDestination, end + almanacRange.SourceToDestination);
                }

                orderedAlmanacRanges.RemoveAt(0);
                almanacRange = orderedAlmanacRanges.FirstOrDefault();
                current = end + 1;
                destinationRanges.Add(range);
            }

            return destinationRanges;
        }

        return new List<Range>();
    }

    public List<Range> GetNextRanges(Range sourceRange, AlmanacEntry almanacEntry)
    {
        var destinationRanges = new List<Range>();

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

    public List<Range> GetNextRanges(List<Range> sourceRanges, AlmanacEntry almanacEntry)
    {
        var destinationRanges = new List<Range>();

        foreach (var sourceRange in sourceRanges)
        {
            destinationRanges.AddRange(GetNextRanges(sourceRange, almanacEntry));
        }

        return destinationRanges;
    }

    public void Run()
    {
        var input = @"seeds: 79 14 55 13

seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4";

        var tables = Regex.Split(input, "\n\n").ToList();
        var ranges = BuildSeedRanges(tables[0]);
        tables.RemoveRange(0, 1);
        var almanac = BuildAlmanac(tables);

        foreach (var almanacEntry in almanac)
        {
            ranges = GetNextRanges(ranges, almanacEntry);
        }

        ranges = ranges.OrderBy(x => x.Start).ToList();
        Console.WriteLine(ranges.First().Start);
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        var ifYouGiveASeedAFertilizer = new IfYouGiveASeedAFertilizer();
        ifYouGiveASeedAFertilizer.Run();
    }
}