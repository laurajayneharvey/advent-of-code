namespace AdventOfCode._2022.Day9
{
    public class Day9_Part1
    {
        public int Run(string input)
        {
            var lines = input.Trim().Split("\r\n");

            var H = new List<(int x, int y)> { (0, 0) };
            var T = new List<(int x, int y)> { (0, 0) };

            foreach (var line in lines)
            {
                var parts = line.Split(" ");
                var direction = parts[0];
                var step = int.Parse(parts[1]);

                for (var i = 0; i < step; i++)
                {
                    var Hx = H[H.Count - 1].x;
                    var Hy = H[H.Count - 1].y;
                    if (direction == "R")
                    {
                        Hx++;
                    }
                    else if (direction == "L")
                    {
                        Hx--;
                    }
                    else if (direction == "U")
                    {
                        Hy++;
                    }
                    else if (direction == "D")
                    {
                        Hy--;
                    }

                    H.Add((Hx, Hy));

                    Hx = H[H.Count - 1].x;
                    Hy = H[H.Count - 1].y;
                    var Tx = T[T.Count - 1].x;
                    var Ty = T[T.Count - 1].y;

                    if (Math.Abs(Tx - Hx) <= 1 && Math.Abs(Ty - Hy) <= 1)
                    {
                        T.Add((Tx, Ty));
                        continue;
                    }

                    if (Tx == Hx)
                    {
                        // do nothing
                    }
                    else if (Tx > Hx)
                    {
                        Tx--;
                    }
                    else
                    {
                        Tx++;
                    }
                    if (Ty == Hy)
                    {
                        // do nothing
                    }
                    else if (Ty > Hy)
                    {
                        Ty--;
                    }
                    else
                    {
                        Ty++;
                    }
                    T.Add((Tx, Ty));
                }
            }

            return T.Select(item => $"x{item.x}y={item.y}").Distinct().Count();
        }
    }
}
