namespace AdventOfCode._2022.Day9
{
    public class Day9_Part2
    {
        public int Run(string input)
        {
            var lines = input.Trim().Split("\r\n");

            var H = new List<(int x, int y)> { (0, 0) };

            var one = new List<(int x, int y)> { (0, 0) };
            var two = new List<(int x, int y)> { (0, 0) };
            var three = new List<(int x, int y)> { (0, 0) };
            var four = new List<(int x, int y)> { (0, 0) };
            var five = new List<(int x, int y)> { (0, 0) };
            var six = new List<(int x, int y)> { (0, 0) };
            var seven = new List<(int x, int y)> { (0, 0) };
            var eight = new List<(int x, int y)> { (0, 0) };
            var nine = new List<(int x, int y)> { (0, 0) };
            var ten = new List<(int x, int y)> { (0, 0) };

            foreach (var line in lines)
            {
                var parts = line.Split(" ");
                var direction = parts[0];
                var step = int.Parse(parts[1]);

                for (var i = 0; i < step; i++)
                {
                    var Hx = H[H.Count() - 1].x;
                    var Hy = H[H.Count() - 1].y;
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

                    one = DoSomething(H, one);
                    two = DoSomething(one, two);
                    three = DoSomething(two, three);
                    four = DoSomething(three, four);
                    five = DoSomething(four, five);
                    six = DoSomething(five, six);
                    seven = DoSomething(six, seven);
                    eight = DoSomething(seven, eight);
                    nine = DoSomething(eight, nine);
                }
            }

            return nine.Select(item => $"x{item.x}y={item.y}").Distinct().Count();
        }

        private List<(int x, int y)> DoSomething(List<(int x, int y)> H, List<(int x, int y)> T)
        {
            var Hx = H[H.Count() - 1].x;
            var Hy = H[H.Count() - 1].y;
            var Tx = T[T.Count() - 1].x;
            var Ty = T[T.Count() - 1].y;

            if (Math.Abs(Tx - Hx) <= 1 && Math.Abs(Ty - Hy) <= 1)
            {
                T.Add((Tx, Ty));
                return T;
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

            return T;
        }
    }
}
