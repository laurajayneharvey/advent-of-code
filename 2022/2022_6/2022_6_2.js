var input = `zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw`;

var stream = [...input];

var requiredUniqueLength = 14;
var index = requiredUniqueLength - 1;
while (index < stream.length) {
  var potentialStart = stream.slice(index - (requiredUniqueLength - 1), index + 1);
  var unique = [...new Set(potentialStart)];
  if (unique.length == requiredUniqueLength) {
    break;
  }
  index++;
}

console.log(index + 1);