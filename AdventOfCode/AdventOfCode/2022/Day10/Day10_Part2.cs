namespace AdventOfCode._2022.Day10
{
    public class Day10_Part2
    {
        private readonly Day10 _day10;

        public Day10_Part2()
        {
            _day10 = new Day10();
        }

        public string Run(string input)
        {
            var xValues = _day10.GetXValues(input);

            var spriteMiddle = 1;
            var output = string.Empty;
            var overallOutput = string.Empty;
            for (var cycleIndex = 0; cycleIndex < xValues.Count; cycleIndex++)
            {
                if (Math.Abs(spriteMiddle - (cycleIndex % 40)) <= 1)
                {
                    output += '#';
                }
                else
                {
                    output += '.';
                }

                var x = xValues[cycleIndex];
                spriteMiddle += x;

                if ((cycleIndex + 1) % 40 == 0)
                {
                    overallOutput += output;

                    if (cycleIndex != xValues.Count - 1)
                    {
                        overallOutput += "\r\n";
                    }

                    output = string.Empty;
                }
            }

            return overallOutput;
        }
    }
}
