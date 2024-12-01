using System.Text.RegularExpressions;

var input = @"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1"
;

var monkies = CreateMonkies();
var counter = 0;
while (counter < 20)
{
    Console.WriteLine();
    PerformInspection();
    Console.WriteLine();
    PrintInspectionResult();
}

Console.WriteLine();
for (var i = 0; i < monkies.Count; i++)
{
    Console.WriteLine($"Monkey {i} inspected items {monkies[i].Inspected} times.");
}

Console.WriteLine();
var orderedMonkies = monkies.OrderByDescending(x => x.Inspected).ToList();
var monkeyBusiness = orderedMonkies[0].Inspected * orderedMonkies[1].Inspected;
Console.WriteLine($"Monkey business = {monkeyBusiness}");

Console.ReadLine();

void PrintInspectionResult()
{
    counter++;
    Console.WriteLine($"After round {counter}, the monkeys are holding items with these worry levels:");
    for (int i = 0; i < monkies.Count; i++)
    {
        var items = string.Join(", ", monkies[i].StartingItems);
        Console.WriteLine($"Monkey {i}: {items}");
    }
}

void PerformInspection()
{
    for (var i = 0; i < monkies.Count; i++)
    {
        Console.WriteLine($"Monkey {i}:");
        var monkey = monkies[i];
        foreach (var startingItem in monkey.StartingItems)
        {
            Console.WriteLine($"  Monkey inspects an item with a worry level of {startingItem}.");
            decimal worryLevel = startingItem;
            var operand = monkey.Operand == "old" ? worryLevel : int.Parse(monkey.Operand);
            var operandString = monkey.Operand == "old" ? "itself" : monkey.Operand;
            if (monkey.Operator == "*")
            {
                worryLevel *= operand;
                Console.WriteLine($"    Worry level is multiplied by {operandString} to {worryLevel}.");
            }
            else
            {
                worryLevel += operand;
                Console.WriteLine($"    Worry level increases by {operand} to {worryLevel}.");
            }

            worryLevel = Math.Floor(worryLevel / 3);
            Console.WriteLine($"    Monkey gets bored with item. Worry level is divided by 3 to {worryLevel}.");

            if (worryLevel % monkey.Test == 0)
            {
                Console.WriteLine($"    Current worry level is divisible by {monkey.Test}.");
                Console.WriteLine($"    Item with worry level {worryLevel} is thrown to monkey {monkey.True}.");
                monkies[monkey.True].StartingItems.Add(int.Parse(worryLevel.ToString()));
            }
            else
            {
                Console.WriteLine($"    Current worry level is not divisible by {monkey.Test}.");
                Console.WriteLine($"    Item with worry level {worryLevel} is thrown to monkey {monkey.False}.");
                monkies[monkey.False].StartingItems.Add(int.Parse(worryLevel.ToString()));
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
        var startingItems = monkeyLines[1].Split(":")[1].Split(",").Select(x => int.Parse(x.Trim())).ToList();
        var operatorItems = monkeyLines[2].Split("=")[1].Trim().Split(" ");
        var test = int.Parse(monkeyLines[3].Split(":")[1].Replace(" divisible by ", string.Empty));
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
    public List<int> StartingItems { get; set; }
    public string Operator { get; set; }
    public string Operand { get; set; }
    public int Test { get; set; }
    public int True { get; set; }
    public int False { get; set; }
    public int Inspected { get; set; } = 0;
}