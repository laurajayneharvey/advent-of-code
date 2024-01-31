namespace AdventOfCode._2022.Day11
{
    public class Day11_Part2
    {
        private readonly Day11 _day11 = new();

        public ulong Run(string input)
        {
            var monkies = _day11.CreateMonkies(input);

            // we'll keep the numbers smaller by using Chinese remainder theorem
            ulong overallModulo = monkies.Aggregate((ulong)1, (aggregate, x) => aggregate * x.Test);
            var operation = (ulong worryLevel) => worryLevel % overallModulo;

            return _day11.GetResult(monkies, operation, 10000);
        }
    }
}
