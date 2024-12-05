namespace AdventOfCode._2024.Day5
{
    public class Day5_Part1
    {
        public int Run(string input)
        {
            var parts = input.Split("\r\n\r\n");

            var pageOrderingRules = parts[0].Split("\r\n");
            var rules = new List<Rule>();
            foreach ( var rule in pageOrderingRules )
            {
                var ruleParts = rule.Split("|");
                rules.Add(new Rule {
                    Before = int.Parse(ruleParts[0]),
                    After = int.Parse(ruleParts[1])
                });
            }
            var rulesGrouped = rules.GroupBy(x => x.Before).ToDictionary(x => x.Key, x => x.Select(y => y.After));

            var updates = parts[1].Split("\r\n");
            var result = 0;
            foreach (var update in updates)
            {
                var good = true;
                var items = update.Split(",").Select(int.Parse).ToList();
                for (var i = 1; i < items.Count; i++)
                {
                    if (!rulesGrouped.TryGetValue(items[i], out var afters))
                    {
                        continue;
                    }

                    var befores = items.GetRange(0, i);
                    var intersection = afters.Intersect(befores);
                    if (intersection.Any())
                    {
                        good = false; 
                        break;
                    }
                }
                if (good)
                {
                    var middleIndex = ((items.Count + 1) / 2) - 1;
                    result += items[middleIndex];
                }
            }
            

            return result;
        }
    }
}
