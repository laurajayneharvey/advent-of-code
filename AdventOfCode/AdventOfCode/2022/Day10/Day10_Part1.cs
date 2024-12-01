namespace AdventOfCode._2022.Day10
{
    public class Day10_Part1
    {
        private readonly Day10 _day10 = new();

        public int Run(string input)
        {
            var xValues = _day10.GetXValues(input);
            xValues.Insert(0, 1);

            var signalStrengthSum = 0;
            var x = 0;
            var skip = 0;
            var take = 20;
            while (xValues.Count >= (skip + take))
            {
                x += xValues.Skip(skip).Take(take).Sum();
                var signalStrength = x * (skip + take);
                signalStrengthSum += signalStrength;
                skip += take;
                take = 40;
            }

            return signalStrengthSum;
        }
    }
}
