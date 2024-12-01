namespace AdventOfCode._2022.Day5
{
    public class Day5
    {
        public string Run(string input, bool reverse = false)
        {
            var parts = input.Split("\r\n\r\n");

            var stackInput = parts[0];
            var instructions = parts[1];

            var stackLines = stackInput.Split("\r\n");
            var lastLine = stackLines[stackLines.Count() - 1];
            var lastLineChars = lastLine.Split(" ");
            var lastLineLastChar = lastLineChars[lastLineChars.Count() - 2];
            var numberOfStacks = int.Parse(lastLineLastChar);

            var stacks = new List<List<char>>();
            for (var i = 0; i < numberOfStacks; i++)
            {
                stacks.Add(new List<char>());
            }

            for (var rowIndex = 0; rowIndex <= stackLines.Count() - 2; rowIndex++)
            {
                var currentLine = stackLines[rowIndex];
                var charIndex = 1;
                var stackIndex = 0;
                while (charIndex < currentLine.Count())
                {
                    var currentChar = currentLine[charIndex];
                    if (currentChar != ' ')
                    {
                        stacks[stackIndex].Add(currentChar);
                    }
                    charIndex += 4;
                    stackIndex++;
                }
            }

            var instructionLines = instructions.Split("\r\n");
            foreach (var instruction in instructionLines)
            {
                var instructionParts = instruction.Split(" ");
                var displacement = int.Parse(instructionParts[1]);
                var oldStackIndex = int.Parse(instructionParts[3]) - 1;
                var newStackIndex = int.Parse(instructionParts[5]) - 1;

                var oldStack = stacks[oldStackIndex];

                var oldStackPart1 = oldStack.Take(displacement);
                if (reverse)
                {
                    oldStackPart1 = oldStackPart1.Reverse();
                }

                var newStack = stacks[newStackIndex];
                stacks[newStackIndex] = oldStackPart1.Concat(newStack).ToList();

                var oldStackPart2 = oldStack.Skip(displacement).Take(oldStack.Count - displacement);
                stacks[oldStackIndex] = oldStackPart2.ToList();
            }

            return stacks.Aggregate(string.Empty, (result, stack) => result += stack[0]);
        }
    }
}
