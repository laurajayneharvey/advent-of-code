using System.Text.RegularExpressions;

var input = @"Monkey 0:
  Starting items: 56, 52, 58, 96, 70, 75, 72
  Operation: new = old * 17
  Test: divisible by 11
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 75, 58, 86, 80, 55, 81
  Operation: new = old + 7
  Test: divisible by 3
    If true: throw to monkey 6
    If false: throw to monkey 5

Monkey 2:
  Starting items: 73, 68, 73, 90
  Operation: new = old * old
  Test: divisible by 5
    If true: throw to monkey 1
    If false: throw to monkey 7

Monkey 3:
  Starting items: 72, 89, 55, 51, 59
  Operation: new = old + 1
  Test: divisible by 7
    If true: throw to monkey 2
    If false: throw to monkey 7

Monkey 4:
  Starting items: 76, 76, 91
  Operation: new = old * 3
  Test: divisible by 19
    If true: throw to monkey 0
    If false: throw to monkey 3

Monkey 5:
  Starting items: 88
  Operation: new = old + 4
  Test: divisible by 2
    If true: throw to monkey 6
    If false: throw to monkey 4

Monkey 6:
  Starting items: 64, 63, 56, 50, 77, 55, 55, 86
  Operation: new = old + 8
  Test: divisible by 13
    If true: throw to monkey 4
    If false: throw to monkey 0

Monkey 7:
  Starting items: 79, 58
  Operation: new = old + 6
  Test: divisible by 17
    If true: throw to monkey 1
    If false: throw to monkey 5"
;

var monkies = CreateMonkies();
// we'll keep the numbers smaller by using Chinese remainder theorem
ulong overallModulo = monkies.Aggregate((ulong)1, (aggregate, x) => aggregate * x.Test);
var counter = 0;
while (counter < 10000)
{
    counter++;
    PerformInspection();
}

var orderedMonkies = monkies.OrderByDescending(x => x.Inspected).ToList();
ulong monkeyBusiness = (ulong)orderedMonkies[0].Inspected * (ulong)orderedMonkies[1].Inspected;
Console.WriteLine($"Monkey business = {monkeyBusiness}");

Console.ReadLine();

void PerformInspection()
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

            worryLevel %= overallModulo;

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

List<Monkey> CreateMonkies()
{
    var lineRegex = new Regex("\r\n");
    var doubleLineRegex = new Regex("\r\n\r\n");

    var monkeySections = doubleLineRegex.Split(input);

    var monkies = new List<Monkey>();
    foreach (var monkeySection in monkeySections)
    {
        var monkeyLines = lineRegex.Split(monkeySection);
        var startingItems = monkeyLines[1].Split(":")[1].Split(",").Select(x => ulong.Parse(x.Trim())).ToList();
        var operatorItems = monkeyLines[2].Split("=")[1].Trim().Split(" ");
        var test = ulong.Parse(monkeyLines[3].Split(":")[1].Replace(" divisible by ", string.Empty));
        var trueResult = int.Parse(monkeyLines[4].Split(":")[1].Replace(" throw to monkey ", string.Empty));
        var falseResult = int.Parse(monkeyLines[5].Split(":")[1].Replace(" throw to monkey ", string.Empty));

        var monkey = new Monkey
        {
            StartingItems = startingItems,
            Operator = operatorItems[1],
            Operand = operatorItems[2],// old, number
            Test = test,
            True = trueResult,
            False = falseResult
        };

        monkies.Add(monkey);
    }

    return monkies;
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