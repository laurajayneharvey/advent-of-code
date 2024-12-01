namespace AdventOfCode._2023.Day2
{
    public class Day2_Part1
    {
        public int Run(string input)
        {
            var possibleIdSum = 0;
            var games = input.Split("\r\n");

            foreach (var game in games)
            {
                var gameParts = game.Split(": ");
                var id = gameParts[0].Replace("Game ", "");
                var rounds = gameParts[1].Split("; ");

                var impossibleRound = rounds.Any(round =>
                {
                    var cubes = round.Split(", ");

                    var impossibleCube = cubes.Any(cube =>
                    {
                        var cubeParts = cube.Split(" ");
                        var count = int.Parse(cubeParts[0]);
                        var colour = cubeParts[1];
                        if (colour == "blue" && count > 14)
                        {
                            return true;
                        }
                        if (colour == "red" && count > 12)
                        {
                            return true;
                        }
                        if (colour == "green" && count > 13)
                        {
                            return true;
                        }

                        return false;
                    });

                    return impossibleCube;
                });

                if (!impossibleRound)
                {
                    possibleIdSum += int.Parse(id);
                }
            }

            return possibleIdSum;
        }
    }
}
