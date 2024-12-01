namespace AdventOfCode._2023.Day8
{
    public class Day8_Part2
    {
        private readonly Day8 _day8 = new();

        public double Run(string input)
        {
            var (instructions, nodes) = _day8.GetNodes(input);

            var activeNodes = nodes.Where(x => x.Origin.EndsWith("A"));

            double lowestCommonMultiple = 1;
            foreach (var activeNode in activeNodes)
            {
                var current = activeNode.Origin;

                var index = 0;
                while (!current.EndsWith("Z"))
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

                lowestCommonMultiple = LowestCommonMultiple(lowestCommonMultiple, Convert.ToDouble(index));
            }

            return lowestCommonMultiple;
        }

        private double GreatestCommonFactor(double a, double b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        private double LowestCommonMultiple(double a, double b)
        {
            var greatestCommonFactor = GreatestCommonFactor(a, b);
            return (a / greatestCommonFactor) * b;
        }
    }
}