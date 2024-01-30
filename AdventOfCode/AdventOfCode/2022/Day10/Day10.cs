namespace AdventOfCode._2022.Day10
{
    public class Day10
    {
        public List<int> GetXValues(string input)
        {
            var lines = input.Split("\r\n");

            var xValues = new List<int>();
            foreach (var line in lines)
            {
                if (line == "noop")
                {
                    xValues.Add(0);
                }
                else if (line.StartsWith("addx "))
                {
                    xValues.Add(0);
                    xValues.Add(int.Parse(line.Split(" ")[1]));
                }
            }

            return xValues;
        }
    }
}
