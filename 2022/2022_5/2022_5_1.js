var input = `    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2`;

var parts = input.split('\n\n');

var stackInput = parts[0];
var instructions = parts[1];

var stackLines = stackInput.split('\n');
var lastLine = stackLines[stackLines.length - 1];
var lastLineChars = lastLine.split(' ');
var lastLineLastChar = lastLineChars[lastLineChars.length - 2];
var numberOfStacks = parseInt(lastLineLastChar);

var stacks = [];
for (var i = 0; i < numberOfStacks; i++) {
  stacks.push([]);
}

for (var rowIndex = 0; rowIndex <= stackLines.length - 2; rowIndex++) {
  var currentLine = stackLines[rowIndex];
  var charIndex = 1;
  var stackIndex = 0;
  while (charIndex < currentLine.length) {
    var currentChar = currentLine[charIndex];
    if (currentChar != ' ') {
      stacks[stackIndex].push(currentChar);
    }
    charIndex += 4;
    stackIndex++;
  }
}

var instructionLines = instructions.split('\n');
instructionLines.forEach(instruction => {
  var instructionParts = instruction.split(' ');
  var displacement = parseInt(instructionParts[1]);
  var oldStackIndex = parseInt(instructionParts[3]) - 1;
  var newStackIndex = parseInt(instructionParts[5]) - 1;

  var oldStack = stacks[oldStackIndex];

  var oldStackPart1 = oldStack.slice(0, displacement).reverse();
  var newStack = stacks[newStackIndex];
  stacks[newStackIndex] = oldStackPart1.concat(newStack);

  var oldStackPart2 = oldStack.slice(displacement, oldStack.length);
  stacks[oldStackIndex] = oldStackPart2;
})

var result = '';
stacks.forEach(stack => {
  result += stack[0];
});
console.log(result);
