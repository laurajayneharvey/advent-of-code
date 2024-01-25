namespace AdventOfCode._2022.Day11
{
    public class Day11_Part1
    {
        private readonly Day11 _day11;

        public Day11_Part1()
        {
            _day11 = new Day11();
        }

        public ulong Run(string input)
        {
            var monkies = _day11.CreateMonkies(input);

            var operation = (ulong worryLevel) =>
            {
                var divided = worryLevel / 3;
                var result = divided.ToString().Split('.')[0];
                return ulong.Parse(result);
            };

            return _day11.GetResult(monkies, operation, 20);
        }
    }
}
