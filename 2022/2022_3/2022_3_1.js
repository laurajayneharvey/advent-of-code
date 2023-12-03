var input = `vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw`;

var rucksacks = input.split('\n');

var totalScore = 0;
rucksacks.forEach(rucksack => {
	var numberOfItems = rucksack.length;
	var firstHalf = rucksack.substring(0, ((numberOfItems/2)));
	var secondHalf = rucksack.substring(numberOfItems/2, numberOfItems);

	var common = [...firstHalf].filter(value => [...secondHalf].includes(value));

	var charCode = common[0].charCodeAt(0);

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
});

console.log('result', totalScore);