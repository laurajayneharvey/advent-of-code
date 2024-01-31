namespace AdventOfCode._2023.Day8
{
    public class Day8
    {
        public (char[] instructions, List<Node> nodes) GetNodes(string input)
        {
            var parts = input.Split("\r\n\r\n");

            var instructions = parts[0].ToCharArray();

            var network = parts[1].Split("\r\n");
            var nodes = new List<Node>();
            foreach (var nodeLine in network)
            {
                var origin = nodeLine[..3];
                var left = nodeLine.Substring(7, 3);
                var right = nodeLine.Substring(12, 3);
                nodes.Add(new Node { Origin = origin, Left = left, Right = right });
            }

            return (instructions, nodes);
        }
    }

    public class Node
    {
        public required string Origin;
        public required string Left;
        public required string Right;
    }
}
