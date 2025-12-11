namespace AdventOfCode._2025.Day1
{
    public class Day1_Part2
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
                    while (distance >= 100)
                    {
                        distance -= 100;
                        count++;
                    }

                    if (distance == current)
                    {
                        if (current != 0)
                        {
                            count++;
                        }
                        current = 0;
                    }
                    else if (distance > current)
                    {
                        if (current != 0)
                        {
                            count++;
                        }
                        current += (100 - distance);
                    }
                    else if (current > distance)
                    {
                        current -= distance;
                    }
                }
                else if (direction == 'R')
                {
                    current += distance;
                    while (current >= 100)
                    {
                        current -= 100;
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
