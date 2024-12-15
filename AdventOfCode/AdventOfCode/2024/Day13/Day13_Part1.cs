namespace AdventOfCode._2024.Day13
{
    public class Day13_Part1
    {
        public int Run(string input)
        {
            var machines = input.Split("\r\n\r\n");

            var cost = 0;
            foreach (var machine in machines)
            {
                var lines = machine.Split("\r\n");
                var ax = int.Parse(lines[0].Split("X+")[1].Split(",")[0]);
                var ay = int.Parse(lines[0].Split("Y+")[1]);
                var bx = int.Parse(lines[1].Split("X+")[1].Split(",")[0]);
                var by = int.Parse(lines[1].Split("Y+")[1]);
                var prizex = int.Parse(lines[2].Split("X=")[1].Split(",")[0]);
                var prizey = int.Parse(lines[2].Split("Y=")[1]);

                //solve intersecting linear equations by substitution
                //e.g.
                //Button A: X + 94, Y + 34
                //Button B: X + 22, Y + 67
                //Prize: X = 8400, Y = 5400
                //ax = 94, ay = 34, bx = 22, by = 67, prizex = 8400, prizey = 5400
                //94a + 22b = 8400 => x 67 => 6298a + 1474b = 562,800
                //34a + 67b = 5400 => x 22 => 748a + 1474b = 118,800
                //5550a = 444,000 => a = 80
                //94(80) + 22b = 8400 =>n7520 + 22b = 8400 => 22b = 880 => b = 40

                int a = ((prizex * by) - (prizey * bx)) / ((ax * by) - (ay * bx));
                int b = (prizex - (ax * a)) / bx;

                if (
                    ((a * ax) + (b * bx) == prizex) &&
                    ((a * ay) + (b * by) == prizey)
                    )
                {
                    cost += (3 * a) + b;
                }
            }

            return cost;
        }

        private static bool IsInteger(float f)
        {
            return Math.Abs(Math.Round(f) - f) < float.Epsilon;
        }
    }
}
