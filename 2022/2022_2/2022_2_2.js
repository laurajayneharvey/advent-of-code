var input = `A Y
B X
C Z`;

var rounds = input.split('\n');

// X means you need to lose, Y means you need to end the round in a draw, and Z

var totalScore = 0;
rounds.forEach(round => {
	var played = round.split(" ");
	var them = played[0];
	var us = played[1];

	var score = 0;
	var shape = '';
	if (us == 'X') {
		// lose
		score += 0
		if (them == 'A') {
			// Rock, so we play Scissors to lose
			shape = 'scissors'
		} else if (them == 'B') {
			// Paper, so we play Rock to lose
			shape = 'rock'
		} else {
			// Scissors, so we play Paper to lose
			shape = 'paper'
		}
	} else if (us == 'Y') {
		// draw
		score += 3
		if (them == 'A') {
			// Rock
			shape = 'rock'
		} else if (them == 'B') {
			// Paper
			shape = 'paper'
		} else {
			// Scissors
			shape = 'scissors'
		}
	} else {
		// win
		score += 6
		if (them == 'A') {
			// Rock, so we play Paper to win
			shape = 'paper'
		} else if (them == 'B') {
			// Paper, so we play Scissors to win
			shape = 'scissors'
		} else {
			// Scissors, so we play Rock to win
			shape = 'rock'
		}
	}

	var shapeScore = 0;
	// 1 for Rock, 2 for Paper, and 3 for Scissors
	if (shape == 'rock') {
		score += 1
	} else if (shape == 'paper') {
		score += 2
	} else {
		score += 3
	}

    totalScore += score;
});

console.log('result', totalScore)