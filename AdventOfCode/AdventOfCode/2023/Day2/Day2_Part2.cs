namespace AdventOfCode._2023.Day2
{
    public class Day2_Part2
    {
        public int Run(string input)
        {
            var sumPower = 0;
            var games = input.Split("\r\n");

            foreach (var game in games)
            {
                var gameParts = game.Split(": ");
                var id = gameParts[0].Replace("Game ", "");
                var rounds = gameParts[1].Split("; ");
                var maxBlue = 0;
                var maxRed = 0;
                var maxGreen = 0;

                foreach (var round in rounds)
                {
                    var cubes = round.Split(", ");

                    foreach (var cube in cubes)
                    {
                        var cubeParts = cube.Split(" ");
                        var count = int.Parse(cubeParts[0]);
                        var colour = cubeParts[1];

                        if (colour == "blue")
                        {
                            maxBlue = Math.Max(count, maxBlue);
                        }
                        if (colour == "red")
                        {
                            maxRed = Math.Max(count, maxRed);
                        }
                        if (colour == "green")
                        {
                            maxGreen = Math.Max(count, maxGreen);
                        }
                    }
                }

                sumPower += (maxBlue * maxRed * maxGreen);
            }

            return sumPower;
        }
    }
}
