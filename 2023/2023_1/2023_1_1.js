var input = `1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet`;

var lines = input.split('\n');
var sum = 0;
for (var i = 0; i < lines.length; i++) {
	var line = lines[i];
  var digits = line.split('').filter(c => !isNaN(c));
  var firstDigit = digits[0];
  var lastDigit = digits[digits.length - 1];
  var doubleDigit = parseInt(`${firstDigit}${lastDigit}`);
  sum += doubleDigit;
}
console.log(sum);