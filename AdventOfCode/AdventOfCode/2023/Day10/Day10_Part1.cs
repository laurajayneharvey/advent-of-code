namespace AdventOfCode._2023.Day10
{
    public class Day10_Part1
    {
        private readonly Day10 _day10;

        public Day10_Part1()
        {
            _day10 = new Day10();
        }

        public int? Run(string input)
        {
            var (tiles, width, height) = _day10.GetTiles(input);
            var (_, stepCount) = _day10.GetMainLoop(tiles, width, height);

            return stepCount / 2;
        }
    }
}
