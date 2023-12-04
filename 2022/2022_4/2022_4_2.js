var input = `2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8`;

var elfPairs = input.split('\n');

var totalScore = 0;
elfPairs.forEach(elfPair => {
	var elves = elfPair.split(',');
	
	var elf1 = elves[0];
	var elf1Min = parseInt(elf1.split('-')[0]);
	var elf1Max = parseInt(elf1.split('-')[1]);

	var elf2 = elves[1];
	var elf2Min = parseInt(elf2.split('-')[0]);
	var elf2Max = parseInt(elf2.split('-')[1]);

	var overlap = false;
	var elf1MinTemp = elf1Min;
	while (elf1MinTemp <= elf1Max) {
		if (elf1MinTemp >= elf2Min && elf1MinTemp <= elf2Max) {
			overlap = true;
			break;
		}
		elf1MinTemp++; 
	}

	if (overlap) {
		totalScore++;
	}
});
	
console.log('result', totalScore);