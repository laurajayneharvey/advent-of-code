using System.Text.RegularExpressions;

var input = @"[1,1,3,1,1]
[1,1,5,1,1]

[[1],[2,3,4]]
[[1],4]

[9]
[[8,7,6]]

[[4,4],4,4]
[[4,4],4,4,4]

[7,7,7,7]
[7,7,7]

[]
[3]

[[[]]]
[[]]

[1,[2,[3,[4,[5,6,7]]]],8,9]
[1,[2,[3,[4,[5,6,0]]]],8,9]";

var bracketsRegex = new Regex(@"(\[[\dA-Za-z,]+\])|(\[\])");
var singleArrayPlaceholder = new Regex(@"\[[A-Za-z]\]");

List<(string left, string right)> pairs = new List<(string, string)>();
Dictionary<(int pairIndex, string id), string> leftArrayLookup = new Dictionary<(int, string), string>();
Dictionary<(int pairIndex, string id), string> rightArrayLookup = new Dictionary<(int, string), string>();

var packets = input.Split("\r\n\r\n");
for (var i = 0; i < packets.Count(); i++)
{
    var packetPair = packets[i].Split("\r\n");

    var left = packetPair[0];
    var right = packetPair[1];

    left = CreateArrays(i, left, leftArrayLookup);
    right = CreateArrays(i, right, rightArrayLookup);

    pairs.Add((left, right));
}

Part1();
Console.ReadLine();

void Part1()
{
    var good = new List<int>();
    for (var i = 0; i < pairs.Count; i++)
    {
        var result = ProcessArray(i, pairs[i].left, pairs[i].right);
        if (result != null && result == true)
        {
            good.Add(i + 1);
        }
    }

    Console.WriteLine(good.Aggregate(0, (a, b) => a + b));
}

bool? ProcessArray(int pairIndex, string left, string right)
{
    var leftItems = GetItems(pairIndex, left, true);
    var rightItems = GetItems(pairIndex, right);

    for (var i = 0; i < Math.Min(leftItems.Count, rightItems.Count); i++)
    {
        // both numbers
        if (int.TryParse(leftItems[i], out var leftInt) && int.TryParse(rightItems[i], out var rightInt))
        {
            if (leftInt != rightInt)
            {
                return leftInt < rightInt;
            }

            continue;
        }

        // left is a number, convert it to an array
        if (int.TryParse(leftItems[i], out var _))
        {
            leftItems[i] = $"[{leftItems[i]}]";
        }

        // right is a number, convert it to an array
        if (int.TryParse(rightItems[i], out var _))
        {
            rightItems[i] = $"[{rightItems[i]}]";
        }

        // both arrays
        var arrayResult = ProcessArray(pairIndex, leftItems[i], rightItems[i]);
        if (arrayResult != null)
        {
            return arrayResult;
        }

        continue;
    }

    // individual items in arrays assessed, now check size of array
    if (leftItems.Count != rightItems.Count)
    {
        return leftItems.Count < rightItems.Count;
    }

    return null;
}

List<string> GetItems(int pairIndex, string item, bool getLeft = false)
{
    if (string.IsNullOrEmpty(item))
    {
        return new List<string>();
    }

    var arrays = getLeft ? leftArrayLookup : rightArrayLookup;
    var array = arrays.TryGetValue((pairIndex, item), out var _) ? arrays[(pairIndex, item)] : item;

    var items = array.Substring(1, array.Count() - 2).Split(',').ToList();

    if (items.Count == 1 && items.First() == string.Empty)
    {
        return new List<string>();
    }

    return items;
}

string CreateArrays(int pairIndex, string line, Dictionary<(int pairIndex, string id), string> arrayLookup)
{
    var currentKey = 65;
    while (bracketsRegex.Match(line) != null && bracketsRegex.Match(line).ToString() != string.Empty)
    {
        var match = bracketsRegex.Match(line).ToString();
        var key = ((char)currentKey).ToString();
        arrayLookup[(pairIndex, key)] = match;
        line = line.Replace(match, key);
        currentKey++;
        if (currentKey == 91)
        {
            currentKey = 97;
        }
    }

    return line;
}