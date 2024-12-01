var input = `zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw`;

var stream = [...input];

var index = 3;
while (index < stream.length) {
  var first = stream[index - 3];
  var second = stream[index - 2];
  var third = stream[index - 1];
  var fourth = stream[index];

  var potentialStartOfPacket = [first, second, third, fourth];
  var unique = [...new Set(potentialStartOfPacket)];
  if (unique.length == 4) {
    break;
  }
  index++;
}

console.log(index + 1);