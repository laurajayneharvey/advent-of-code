using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day6
{
    public class Day6_Part1
    {
        private readonly Day6 _day6;

        public Day6_Part1()
        {
            _day6 = new Day6();
        }

        public int Run(string input)
        {
            var races = GetRaces(input);

            var product = 1;
            foreach (var race in races)
            {
                var exceededRecordCount = _day6.CalculateWinningRace(race);
                if (exceededRecordCount != 0)
                {
                    product *= exceededRecordCount;
                }
            }

            return product;
        }

        private IList<Race> GetRaces(string input)
        {
            var lines = input.Split("\r\n");
            var time = lines[0].Replace("Time:", string.Empty).Trim();
            var distance = lines[1].Replace("Distance:", string.Empty).Trim();

            var regex = new Regex(@"(\S+)|(\s+(?=\S))");
            var timeMatches = regex.Matches(time);
            var times = timeMatches.Where(m => !string.IsNullOrWhiteSpace(m.Value)).Select(m => m.Value).ToList();
            var distanceMatches = regex.Matches(distance);
            var distances = distanceMatches.Where(m => !string.IsNullOrWhiteSpace(m.Value)).Select(m => m.Value).ToList();

            var races = new List<Race>();
            for (var i = 0; i < times.Count; i++)
            {
                races.Add(new Race
                {
                    Time = double.Parse(times[i]),
                    RecordDistance = double.Parse(distances[i])
                });
            }

            return races;
        }
    }
}
