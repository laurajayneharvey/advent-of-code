var input = `A Y
B X
C Z`;
var rounds = input.split('\n');

var totalScore = 0;
rounds.forEach(round => {
	var played = round.split(" ");
	var them = played[0];
	var us = played[1];

	var score = 0;
	if (us == 'X') {
		// Rock
		score += 1
		if (them == 'A') {
			// Rock
			score += 3
		} else if (them == 'B') {
			// Paper
			score += 0
		} else {
			// Scissors
			score += 6
		}
	} else if (us == 'Y') {
		// Paper
		score += 2
		if (them == 'A') {
			// Rock
			score += 6
		} else if (them == 'B') {
			// Paper
			score += 3
		} else {
			// Scissors
			score += 0
		}
	} else {
		// Scissors
		score += 3
		if (them == 'A') {
			// Rock
			score += 0
		} else if (them == 'B') {
			// Paper
			score += 6
		} else {
			// Scissors
			score += 3
		}
	}

    totalScore += score;
});
	
console.log('result', totalScore)