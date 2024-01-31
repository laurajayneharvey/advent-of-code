namespace AdventOfCode._2022.Day11
{
    public class Day11
    {
        public List<Monkey> CreateMonkies(string input)
        {
            var monkeySections = input.Split("\r\n\r\n");

            var monkies = new List<Monkey>();
            foreach (var monkeySection in monkeySections)
            {
                var monkeyLines = monkeySection.Split("\r\n");
                var startingItems = monkeyLines[1].Split(":")[1].Split(",").Select(x => ulong.Parse(x.Trim())).ToList();
                var operatorItems = monkeyLines[2].Split("=")[1].Trim().Split(" ");
                var test = ulong.Parse(monkeyLines[3].Split(":")[1].Replace(" divisible by ", string.Empty));
                var trueResult = int.Parse(monkeyLines[4].Split(":")[1].Replace(" throw to monkey ", string.Empty));
                var falseResult = int.Parse(monkeyLines[5].Split(":")[1].Replace(" throw to monkey ", string.Empty));

                var monkey = new Monkey
                {
                    StartingItems = startingItems,
                    Operator = operatorItems[1],
                    Operand = operatorItems[2],
                    Test = test,
                    True = trueResult,
                    False = falseResult
                };

                monkies.Add(monkey);
            }

            return monkies;
        }

        public ulong GetResult(List<Monkey> monkies, Func<ulong, ulong> operation, int inspectionCount)
        {
            var counter = 0;
            while (counter < inspectionCount)
            {
                counter++;
                PerformInspection(monkies, operation);
            }

            var orderedMonkies = monkies.OrderByDescending(x => x.Inspected).ToList();
            ulong monkeyBusiness = (ulong)orderedMonkies[0].Inspected * (ulong)orderedMonkies[1].Inspected;

            return monkeyBusiness;
        }

        private static void PerformInspection(List<Monkey> monkies, Func<ulong, ulong> operation)
        {
            for (var i = 0; i < monkies.Count; i++)
            {
                var monkey = monkies[i];
                foreach (var startingItem in monkey.StartingItems)
                {
                    ulong worryLevel = startingItem;
                    var operand = monkey.Operand == "old" ? worryLevel : ulong.Parse(monkey.Operand);
                    if (monkey.Operator == "*")
                    {
                        worryLevel *= operand;
                    }
                    else
                    {
                        worryLevel += operand;
                    }

                    worryLevel = operation(worryLevel);

                    if (worryLevel % monkey.Test == 0)
                    {
                        monkies[monkey.True].StartingItems.Add(worryLevel);
                    }
                    else
                    {
                        monkies[monkey.False].StartingItems.Add(worryLevel);
                    }
                }

                monkies[i].Inspected = monkies[i].Inspected += monkies[i].StartingItems.Count;
                monkies[i].StartingItems.Clear();
            }
        }
    }

    public class Monkey
    {
        public List<ulong> StartingItems { get; set; }
        public string Operator { get; set; }
        public string Operand { get; set; }
        public ulong Test { get; set; }
        public int True { get; set; }
        public int False { get; set; }
        public int Inspected { get; set; } = 0;
    }
}
