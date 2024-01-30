namespace AdventOfCode._2022.Day2
{
    public class Day2_Part1
    {
        public int Run(string input)
        {
            var rounds = input.Split("\r\n");

            var totalScore = 0;
            foreach (var round in rounds)
            {
                var played = round.Split(" ");
                var them = played[0];
                var us = played[1];

                var score = 0;
                if (us == "X")
                {
                    // Rock
                    score += 1;

                    if (them == "A")
                    {
                        // Rock
                        score += 3;

                    }
                    else if (them == "B")
                    {
                        // Paper
                        score += 0;

                    }
                    else
                    {
                        // Scissors
                        score += 6;

                    }
                }
                else if (us == "Y")
                {
                    // Paper
                    score += 2;

                    if (them == "A")
                    {
                        // Rock
                        score += 6;

                    }
                    else if (them == "B")
                    {
                        // Paper
                        score += 3;

                    }
                    else
                    {
                        // Scissors
                        score += 0;

                    }
                }
                else
                {
                    // Scissors
                    score += 3;

                    if (them == "A")
                    {
                        // Rock
                        score += 0;

                    }
                    else if (them == "B")
                    {
                        // Paper
                        score += 6;

                    }
                    else
                    {
                        // Scissors
                        score += 3;

                    }
                }

                totalScore += score;
            }

            return totalScore;
        }
    }
}
