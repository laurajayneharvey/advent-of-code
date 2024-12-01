namespace AdventOfCode._2022.Day3
{
    public class Day3
    {
        public int GetScore(IEnumerable<char> common)
        {
            var charCode = common.First();

            int score;
            if (charCode <= 90)
            {
                // A 65 -> 27 (-38)
                // Z 90 -> 52 (-38)
                score = charCode - 38;
            }
            else
            {
                // a 97 -> 1 (-96)
                // z 122 -> 26 (-96)
                score = charCode - 96;
            }

            return score;
        }
    }
}
