using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

public class Range
{
	public double SourceStart;
	public double SourceEnd;
	public double SourceToDestination;
}

public class AlmanacEntry
{
	public string Destination;
	public List<Range> Ranges;
}
					
public class Program
{
	public static void Main()
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
		
		var tables = Regex.Split(input, "\n\n");
		
		var almanac = new List<AlmanacEntry>();
		var seeds = new List<double>();
		var tableIndex = 0;
		tables.ToList().ForEach(table => {
			if (tableIndex == 0) {
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
			for (var i = 0; i < rangeLines.Count; i++) {
				var parts = rangeLines[i].Split(" ");
				var destinationStart = double.Parse(parts[0]);
				var sourceStart = double.Parse(parts[1]);
				var rangeLength = double.Parse(parts[2]);
				var range = new Range {
					SourceStart = sourceStart,
					SourceEnd = sourceStart + rangeLength - 1,
					SourceToDestination = destinationStart - sourceStart
				};
				ranges.Add(range);
			}

			almanac.Add(new AlmanacEntry {
				Destination = destination,
				Ranges = ranges
			});
		});
		
		var minLocation = double.MaxValue;
		foreach (var seed in seeds) {
			var source = seed;
			foreach (var almanacEntry in almanac) {
				var matchingRange = almanacEntry.Ranges.FirstOrDefault(range => source >= range.SourceStart && source <= range.SourceEnd);

				if (matchingRange != null) {
					source = source + matchingRange.SourceToDestination;
				}
			}

			minLocation = Math.Min(minLocation, source);
		}

		Console.WriteLine(minLocation);
	}
}