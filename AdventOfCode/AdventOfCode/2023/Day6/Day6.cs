namespace AdventOfCode._2023.Day6
{
    public class Day6
    {
        public int CalculateWinningRace(Race race)
        {
            var exceededRecordCount = 0;
            for (var buttonHold = 0; buttonHold <= race.Time; buttonHold++)
            {
                var time = race.Time - buttonHold;
                var speed = buttonHold;
                var distance = time * speed;

                if (distance > race.RecordDistance)
                {
                    exceededRecordCount++;
                }
            }

            return exceededRecordCount;
        }
    }

    public class Race
    {
        public double Time;
        public double RecordDistance;
    }
}
