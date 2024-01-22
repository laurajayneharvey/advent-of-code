using System.Text.RegularExpressions;

var input = @"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi";

var map = CreateMap();
var possibleSources = map.Where(x => x.Elevation == 'a').ToList();
var minDistance = int.MaxValue;
Console.WriteLine($"{possibleSources.Count} possible sources");
for (var i = 0; i < possibleSources.Count; i++)
{
    var possibleSource = possibleSources[i];
    map = map.Select(x =>
    {
        x.Distance = int.MaxValue;
        x.Visited = false;
        x.IsSource = x.X == possibleSource.X && x.Y == possibleSource.Y;
        return x;
    }).ToList();
    var distance = UseDijkstraBackwards();
    minDistance = Math.Min(minDistance, distance);
    Console.WriteLine($"{i}: min distance = {minDistance}");

    // get rid of the char used as possible source since won't want it as a subpath for another
    map.First(x => x.IsSource).Value = '~';
    map.First(x => x.IsSource).Elevation = '~';
}
Console.WriteLine(minDistance);
Console.ReadLine();

int UseDijkstraBackwards()
{
    map.First(x => x.IsDestination).Distance = 0;
    var current = map.First(x => x.IsDestination);
    while (true)
    {
        var neighbours = GetNeighbours(current);
        foreach (var neighbour in neighbours)
        {
            var distance = current.Distance + 1;
            map.First(x => x.X == neighbour.X && x.Y == neighbour.Y).Distance = Math.Min(distance, neighbour.Distance);
        }
        map.First(x => x.X == current.X && x.Y == current.Y).Visited = true;
        if (map.First(x => x.IsSource).Visited)
        {
            return map.First(x => x.IsSource).Distance;
        }
        var unvisited = map.Where(x => !x.Visited).OrderBy(x => x.Distance);
        current = unvisited.First();
        if (current.Distance != int.MaxValue && current.IsSource)
        {
            return current.Distance;
        }
        if (current.Distance >= minDistance)
        {
            // bail early if this distance is not going to be less than one already recorded
            return current.Distance;
        }
    }
}

List<MapItem> GetNeighbours(MapItem currentItem)
{
    var neighbours = new List<MapItem>();
    var width = map.Max(item => item.X);
    var height = map.Max(item => item.Y);

    var up = new MapItem { X = currentItem.X, Y = currentItem.Y - 1 };
    var canGoUp = up.X >= 0 && up.X <= width && up.Y >= 0 && up.Y <= height;
    if (canGoUp)
    {
        var upItem = map.First(item => item.X == up.X && item.Y == up.Y);
        if (upItem.Elevation >= currentItem.Elevation - 1)
        {
            neighbours.Add(upItem);
        }
    }

    var down = new MapItem { X = currentItem.X, Y = currentItem.Y + 1 };
    var canGoDown = down.X >= 0 && down.X <= width && down.Y >= 0 && down.Y <= height;
    if (canGoDown)
    {
        var downItem = map.First(item => item.X == down.X && item.Y == down.Y);
        if (downItem.Elevation >= currentItem.Elevation - 1)
        {
            neighbours.Add(downItem);
        }
    }

    var left = new MapItem { X = currentItem.X - 1, Y = currentItem.Y };
    var canGoLeft = left.X >= 0 && left.X <= width && left.Y >= 0 && left.Y <= height;
    if (canGoLeft)
    {
        var leftItem = map.First(item => item.X == left.X && item.Y == left.Y);
        if (leftItem.Elevation >= currentItem.Elevation - 1)
        {
            neighbours.Add(leftItem);
        }
    }

    var right = new MapItem { X = currentItem.X + 1, Y = currentItem.Y };
    var canGoRight = right.X >= 0 && right.X <= width && right.Y >= 0 && right.Y <= height;
    if (canGoRight)
    {
        var rightItem = map.First(item => item.X == right.X && item.Y == right.Y);
        if (rightItem.Elevation >= currentItem.Elevation - 1)
        {
            neighbours.Add(rightItem);
        }
    }

    return neighbours;
}

List<MapItem> CreateMap()
{
    var regex = new Regex("\r\n");
    var rows = regex.Split(input);
    var map = new List<MapItem>();
    for (var i = 0; i < rows.Length; i++)
    {
        var row = rows[i];
        var columns = row.ToCharArray();
        for (var j = 0; j < columns.Length; j++)
        {
            var mapItem = new MapItem
            {
                X = j,
                Y = i,
                Elevation = columns[j] == 'E' ? 'z' : columns[j] == 'S' ? 'a' : columns[j],
                Value = columns[j],
            };

            map.Add(mapItem);
        }
    }

    return map;
}

public class MapItem
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Elevation { get; set; }
    public int Value { get; set; }
    public int Distance { get; set; } = int.MaxValue;
    public bool Visited { get; set; }
    public bool IsDestination => Value == 'E';
    public bool IsSource { get; set; }
}