namespace AdventOfCode._2025.Day10
{
    public class Day10_Part1
    {
        public int Run(string input)
        {
            var machines = input.Split("\r\n");
            var minsSum = 0;
            foreach (var machine in machines)
            {
                var withoutJoltage = machine.Split('{')[0];
                var goal = withoutJoltage.Split(']')[0].Skip(1).Select(c => c == '#').ToArray();
                var buttons = withoutJoltage.Split(']')[1].Replace(" ", "").Replace("(", "").Split(')').Where(b => b != string.Empty).Select(b =>
                {
                    return b.Split(',').Select(int.Parse).ToList();
                }).ToArray();

                var indicatorLight = Enumerable.Repeat(false, goal.Length).ToArray();

                var min = Blah(buttons, indicatorLight, goal, int.MaxValue, []);

                minsSum += min;
            }

            return minsSum;
        }

        private int Blah(List<int>[] buttons, bool[] indicatorLight, bool[] goal, int min, List<int>[] buttonsToExclude)
        {
            foreach (var button in buttons.Except(buttonsToExclude))
            {
                var clonedButtonsToExclude = ((List<int>[])buttonsToExclude.Clone()).ToList();
                clonedButtonsToExclude.Add(button);
                var clonedIndicatorLight = (bool[])indicatorLight.Clone();
                foreach (var toggle in button)
                {
                    clonedIndicatorLight[toggle] = !clonedIndicatorLight[toggle];
                }
                if (clonedIndicatorLight.SequenceEqual(goal))
                {
                    min = Math.Min(min, clonedButtonsToExclude.Count);
                    break;
                }
                else if (min <= clonedButtonsToExclude.Count + 1)
                {
                    continue;
                }
                else
                {
                    min = Math.Min(Blah(buttons, clonedIndicatorLight, goal, min, [.. clonedButtonsToExclude]), min);
                }

            }

            return min;
        }
    }
}
