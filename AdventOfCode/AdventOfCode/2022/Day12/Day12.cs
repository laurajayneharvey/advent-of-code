namespace AdventOfCode._2022.Day12
{
    public class Day12
    {
        public List<MapItem> CreateMap(string input)
        {
            var rows = input.Split("\r\n");
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
        public bool IsSource => Value == 'S';
    }
}
