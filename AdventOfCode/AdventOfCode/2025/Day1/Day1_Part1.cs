namespace AdventOfCode._2025.Day1
{
    public class Day1_Part1
    {
        public int Run(string input)
        {
            var rotations = input.Split("\r\n");

            var current = 50;
            var count = 0;

            foreach (var rotation in rotations)
            {
                var direction = rotation.First();
                var distance = int.Parse(rotation[1..]);

                if (direction == 'L')
                {
                    current -= distance;
                    while (current < 0)
                    {
                        current += 100;
                    }
                }
                else if (direction == 'R')
                {
                    current += distance;
                    current = current % 100;
                }

                if (current == 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
