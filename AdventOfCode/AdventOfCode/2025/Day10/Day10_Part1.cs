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
                    return new Button
                    {
                        Toggles = [.. b.Split(',').Select(int.Parse)]
                    };
                }).ToArray();

                var indicatorLight = Enumerable.Repeat(false, goal.Length).ToArray();

                var min = Blah(buttons, indicatorLight, goal, int.MaxValue, []);

                minsSum += min;
            }

            return minsSum;
        }

        private int Blah(Button[] buttons, bool[] indicatorLight, bool[] goal, int min, Button[] buttonsToExclude)
        {
            foreach (var button in buttons.Except(buttonsToExclude))
            {
                var clonedButtonsToExclude = ((Button[])buttonsToExclude.Clone()).ToList();
                clonedButtonsToExclude.Add(button);
                var clonedIndicatorLight = (bool[])indicatorLight.Clone();
                foreach (var buttonToExclude in clonedButtonsToExclude)
                {
                    foreach (var toggle in buttonToExclude.Toggles)
                    {
                        clonedIndicatorLight[toggle] = !clonedIndicatorLight[toggle];
                    }
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
                    min = Math.Min(Blah(buttons, indicatorLight, goal, min, [.. clonedButtonsToExclude]), min);
                }

            }

            return min;
        }

        public class Button
        {
            public List<int> Toggles = [];

            public override bool Equals(object? obj)
            {
                return obj is Button button && button.Toggles.SequenceEqual(Toggles);
            }
        }
    }
}
