namespace AdventOfCode._2023.Day6
{
    public class Day6_Part2
    {
        private readonly Day6 _day6 = new();

        public int Run(string input)
        {
            var race = GetRace(input);

            var exceededRecordCount = _day6.CalculateWinningRace(race);

            return exceededRecordCount;
        }

        private Race GetRace(string input)
        {
            var lines = input.Split("\r\n");
            var time = lines[0].Replace("Time:", string.Empty).Replace(" ", string.Empty);
            var distance = lines[1].Replace("Distance:", string.Empty).Replace(" ", string.Empty);

            return new Race
            {
                Time = double.Parse(time),
                RecordDistance = double.Parse(distance)
            };
        }
    }
}
