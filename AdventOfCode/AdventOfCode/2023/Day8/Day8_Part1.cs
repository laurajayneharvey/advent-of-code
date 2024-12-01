namespace AdventOfCode._2023.Day8
{
    public class Day8_Part1
    {
        private readonly Day8 _day8 = new();

        public double Run(string input)
        {
            var (instructions, nodes) = _day8.GetNodes(input);

            var current = "AAA";
            var index = 0;
            while (current != "ZZZ")

            {
                var node = nodes.First(x => x.Origin == current);

                var directionIndex = index % instructions.Count();
                var direction = instructions[directionIndex];
                if (direction == 'L')
                {
                    current = node.Left;
                }
                else
                {
                    current = node.Right;
                }

                index++;
            }

            return index;
        }
    }
}