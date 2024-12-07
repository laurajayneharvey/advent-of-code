namespace AdventOfCode._2024.Day7
{
    public class Day7_Part2
    {
        public long Run(string input)
        {
            var equations = input.Split("\r\n");
            long matchTotal = 0;
            foreach (var equation in equations)
            {
                var parts = equation.Split(": ");
                var result = long.Parse(parts[0]);
                var initialOperands = parts[1].Split(" ").Select(long.Parse).ToList();

                var options = new List<List<long>>
                {
                    initialOperands.ToList()
                };

                while (options.Count > 0)
                {
                    var operands = options.First();
                    options = options.Skip(1).ToList();

                    var adds = operands[0] + operands[1];
                    var multiplies = operands[0] * operands[1];
                    var ors = long.Parse(operands[0].ToString() + operands[1]);

                    var remaining = operands.Skip(2);
                    if (remaining.Count() > 0)
                    {
                        if (adds <= result)
                        {
                            var option = new List<long>
                            {
                                adds
                            };
                            option.AddRange(remaining);
                            options.Add(option);
                        }
                        if (multiplies <= result)
                        {
                            var option = new List<long>
                            {
                                multiplies
                            };
                            option.AddRange(remaining);
                            options.Add(option);
                        }
                        if (ors <= result)
                        {
                            var option = new List<long>
                            {
                                ors
                            };
                            option.AddRange(remaining);
                            options.Add(option);
                        }
                    }
                    else
                    {
                        if (adds == result || multiplies == result || ors == result)
                        {
                            matchTotal += result;
                            break;
                        }
                    }
                }
            }

            return matchTotal;
        }
    }
}
