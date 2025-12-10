namespace AdventOfCode._2025.Day10
{
    public class Day10_Part1
    {
        public int Run(string input)
        {
            var machines = input.Split("\r\n");
            var sum = 0;
            foreach (var machine in machines)
            {
                var partsWithoutJoltage = machine.Split('{')[0].Split(']');
                var goal = partsWithoutJoltage[0].Skip(1).Select(c => c == '#');
                var buttons = partsWithoutJoltage[1].Replace(" ", "").Replace("(", "").Split(')').Where(b => b != string.Empty).Select(b => b.Split(',').Select(int.Parse));

                sum += GetMinimumPresses(buttons, [.. Enumerable.Repeat(false, goal.Count())], goal, int.MaxValue, []);
            }

            return sum;
        }

        private static int GetMinimumPresses(IEnumerable<IEnumerable<int>> buttons, bool[] indicatorLight, IEnumerable<bool> goal, int min, IEnumerable<int>[] buttonsToExclude)
        {
            foreach (var button in buttons.Except(buttonsToExclude))
            {
                var clonedButtonsToExclude = (IEnumerable<int>[])buttonsToExclude.Clone();
                var clonedIndicatorLight = (bool[])indicatorLight.Clone();

                foreach (var toggle in button)
                {
                    clonedIndicatorLight[toggle] = !clonedIndicatorLight[toggle];
                }
                if (clonedIndicatorLight.SequenceEqual(goal))
                {
                    min = Math.Min(min, clonedButtonsToExclude.Length + 1); // already excluded + current button
                    break;
                }
                else if (min <= clonedButtonsToExclude.Length + 2) // already excluded + current button + next button
                {
                    continue;
                }
                else
                {
                    min = Math.Min(GetMinimumPresses(buttons, clonedIndicatorLight, goal, min, [.. clonedButtonsToExclude, button]), min);
                }
            }

            return min;
        }
    }
}
