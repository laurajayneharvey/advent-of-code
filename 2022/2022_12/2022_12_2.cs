using System.Text.RegularExpressions;

var input = @"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi";

var map = CreateMap();
var distance = UseDijkstraBackwards();
Console.WriteLine(distance);
Console.ReadLine();

int UseDijkstraBackwards()
{
    map.First(x => x.IsDestination).Distance = 0;
    var current = map.First(x => x.IsDestination);
    while (true)
    {
        Console.WriteLine($"current, distance = {current.Distance}, elevation = {(char)current.Elevation}");

        var neighbours = GetNeighbours(current);
        foreach (var neighbour in neighbours)
        {
            var distance = current.Distance + 1;
            map.First(x => x.X == neighbour.X && x.Y == neighbour.Y).Distance = Math.Min(distance, neighbour.Distance);
        }
        map.First(x => x.X == current.X && x.Y == current.Y).Visited = true;

        if (map.FirstOrDefault(x => x.Elevation == 'a' && x.Visited) != null)
        {
            return map.First(x => x.Elevation == 'a' && x.Visited).Distance;
        }

        var unvisited = map.Where(x => !x.Visited).OrderBy(x => x.Distance);
        current = unvisited.First();
        if (current.Distance != int.MaxValue && current.Elevation == 'a')
        {
            return current.Distance;
        }
    }
}

List<MapItem> GetNeighbours(MapItem currentItem)
{
    var possibleNeighbours = new List<MapItem?>
    {
        map.FirstOrDefault(x => x.X == currentItem.X + 1 && x.Y == currentItem.Y),
        map.FirstOrDefault(x => x.X == currentItem.X - 1 && x.Y == currentItem.Y),
        map.FirstOrDefault(x => x.X == currentItem.X && x.Y == currentItem.Y + 1),
        map.FirstOrDefault(x => x.X == currentItem.X && x.Y == currentItem.Y - 1)
    };

    var neighbours = new List<MapItem>();
    foreach (var neighbour in possibleNeighbours)
    {
        if (neighbour != null && neighbour.Elevation >= currentItem.Elevation - 1)
        {
            neighbours.Add(neighbour);
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
}