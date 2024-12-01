var input = `vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw`;

var rucksacks = input.split('\n');

var totalScore = 0;
for (var i = 0; i < rucksacks.length; i++) {
	if (i % 3 == 0) {
		var elf1 = rucksacks[i];
		var elf2 = rucksacks[i + 1];
		var elf3 = rucksacks[i + 2];

		var commonToTwo = [...elf1].filter(value => [...elf2].includes(value));
		var commonToThree = [...commonToTwo].filter(value => [...elf3].includes(value));

		var charCode = commonToThree[0].charCodeAt(0);

		var score = 0;
		if (charCode <= 90) {
			// A 65 -> 27 (-38)
			// Z 90 -> 52 (-38)
			score = charCode - 38;
		} else {
			// a 97 -> 1 (-96)
			// z 122 -> 26 (-96)
			score = charCode - 96;
		}

		totalScore += score;
	}
}

console.log('result', totalScore);