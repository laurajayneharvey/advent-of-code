var input = `seeds: 79 14 55 13

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
56 93 4`;

var almanac = {};
var seeds = [];

var tables = input.split("\n\n");
tables.forEach(table => {
	var lines = table.split("\n");
	if (lines.length === 1) {
		seeds = lines[0].split(": ")[1].split(" ");
		return;
	}
	
	var heading = lines[0];
	var headingParts = heading.split(" ")[0].split("-");
	var source = headingParts[0];
	var destination = headingParts[2];
	
	var rangeLines = lines.splice(1);
	var ranges = [];
	for (var i = 0; i < rangeLines.length; i++) {
		var parts = rangeLines[i].split(" ");
		var destinationStart = parseInt(parts[0]);
		var sourceStart = parseInt(parts[1]);
		var rangeLength = parseInt(parts[2]);
		ranges.push({ sourceStart, "sourceEnd": sourceStart + rangeLength - 1, "sourceToDestination": destinationStart - sourceStart });
	}
	
	almanac[source] = { destination, ranges };
});

var locations = [];
seeds.forEach(seed => {
	var source = parseInt(seed);	
	var sourceName = "seed";
	
	while (almanac[sourceName] !== undefined) {
		var almanacEntry = almanac[sourceName];
		var destination = source;
		
		var matchingRange = almanacEntry.ranges.find(range => source >= range.sourceStart && source <= range.sourceEnd);
		
		if (matchingRange !== undefined) {
			destination = source + matchingRange.sourceToDestination;
		}
		
    source = destination;
		sourceName = almanacEntry.destination;
	}

  locations.push(source);
});

var minLocation = Math.min(...locations)
console.log(minLocation)