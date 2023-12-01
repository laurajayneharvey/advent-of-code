var replaceSpeltNumber = (input) => {
	return input
  	.replace("one", 1)
    .replace("two", 2)
    .replace("three", 3)
    .replace("four", 4)
    .replace("five", 5)
    .replace("six", 6)
    .replace("seven", 7)
    .replace("eight", 8)
    .replace("nine", 9);
}

var findNumber = (input) => {
	var digits = input.split('').filter(c => !isNaN(c));
		if (digits.length > 0) {
        return digits[0];
    }

    input = replaceSpeltNumber(input);
    digits = input.split('').filter(c => !isNaN(c));
		if (digits.length > 0) {
    	return digits[0];
    }

    return null;
}

var input = `two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen`;

var lines = input.split('\n');
var sum = 0;
for (var i = 0; i < lines.length; i++) {
	var line = lines[i];
  var lineLength = line.split('').length;
  var firstDigit = '';
  var lastDigit = '';

  for (var j = 0; j < lineLength; j++) {
  	var partial = line.substring(0, j + 1);
		var firstDigit = findNumber(partial);
    if (firstDigit != null) {
      break;
    }
  }

  for (var j = 0; j < lineLength; j++) {
  	var partial = line.substring(lineLength - 1 - j, lineLength);
		var lastDigit = findNumber(partial);
    if (lastDigit != null) {
      break;
    }
  }
	
	var doubleDigit = parseInt(`${firstDigit}${lastDigit}`);
	sum += doubleDigit;
}

console.log(sum);