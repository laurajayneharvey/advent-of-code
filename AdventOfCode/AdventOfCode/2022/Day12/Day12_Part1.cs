namespace AdventOfCode._2022.Day12
{
    public class Day12_Part1
    {
        private readonly Day12 _day12 = new();

        public int Run(string input)
        {
            var map = _day12.CreateMap(input);
            return UseDijkstra(map);
        }

        private int UseDijkstra(List<MapItem> map)
        {
            map.First(x => x.IsSource).Distance = 0;
            var current = map.First(x => x.IsSource);
            while (true)
            {
                var neighbours = GetNeighbours(current, map);
                foreach (var neighbour in neighbours)
                {
                    var distance = current.Distance + 1;
                    map.First(x => x.X == neighbour.X && x.Y == neighbour.Y).Distance = Math.Min(distance, neighbour.Distance);
                }
                map.First(x => x.X == current.X && x.Y == current.Y).Visited = true;
                if (map.First(x => x.IsDestination).Visited)
                {
                    return map.First(x => x.IsDestination).Distance;
                }
                var unvisited = map.Where(x => !x.Visited).OrderBy(x => x.Distance);
                current = unvisited.First();
                if (current.Distance != int.MaxValue && current.IsDestination)
                {
                    return current.Distance;
                }
            }
        }

        private List<MapItem> GetNeighbours(MapItem currentItem, List<MapItem> map)
        {
            var neighbours = new List<MapItem>();
            var width = map.Max(item => item.X);
            var height = map.Max(item => item.Y);

            var up = new MapItem { X = currentItem.X, Y = currentItem.Y - 1 };
            var canGoUp = up.X >= 0 && up.X <= width && up.Y >= 0 && up.Y <= height;
            if (canGoUp)
            {
                var upItem = map.First(item => item.X == up.X && item.Y == up.Y);
                if (upItem.Elevation <= currentItem.Elevation + 1)
                {
                    neighbours.Add(upItem);
                }
            }

            var down = new MapItem { X = currentItem.X, Y = currentItem.Y + 1 };
            var canGoDown = down.X >= 0 && down.X <= width && down.Y >= 0 && down.Y <= height;
            if (canGoDown)
            {
                var downItem = map.First(item => item.X == down.X && item.Y == down.Y);
                if (downItem.Elevation <= currentItem.Elevation + 1)
                {
                    neighbours.Add(downItem);
                }
            }

            var left = new MapItem { X = currentItem.X - 1, Y = currentItem.Y };
            var canGoLeft = left.X >= 0 && left.X <= width && left.Y >= 0 && left.Y <= height;
            if (canGoLeft)
            {
                var leftItem = map.First(item => item.X == left.X && item.Y == left.Y);
                if (leftItem.Elevation <= currentItem.Elevation + 1)
                {
                    neighbours.Add(leftItem);
                }
            }

            var right = new MapItem { X = currentItem.X + 1, Y = currentItem.Y };
            var canGoRight = right.X >= 0 && right.X <= width && right.Y >= 0 && right.Y <= height;
            if (canGoRight)
            {
                var rightItem = map.First(item => item.X == right.X && item.Y == right.Y);
                if (rightItem.Elevation <= currentItem.Elevation + 1)
                {
                    neighbours.Add(rightItem);
                }
            }

            return neighbours;
        }
    }
}
