namespace AdventOfCode._2022.Day12
{
    public class Day12_Part2
    {
        private readonly Day12 _day12;

        public Day12_Part2()
        {
            _day12 = new Day12();
        }

        public int Run(string input)
        {
            var map = _day12.CreateMap(input);
            return UseDijkstraBackwards(map);
        }

        private int UseDijkstraBackwards(List<MapItem> map)
        {
            map.First(x => x.IsDestination).Distance = 0;
            var current = map.First(x => x.IsDestination);
            while (true)
            {
                Console.WriteLine($"current, distance = {current.Distance}, elevation = {(char)current.Elevation}");

                var neighbours = GetNeighbours(current, map);
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

        private List<MapItem> GetNeighbours(MapItem currentItem, List<MapItem> map)
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
    }
}
