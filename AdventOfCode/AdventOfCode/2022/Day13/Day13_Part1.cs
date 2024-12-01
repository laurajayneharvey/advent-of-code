namespace AdventOfCode._2022.Day13
{
    public class Day13_Part1
    {
        private readonly List<(string left, string right)> _pairs = [];
        private readonly Day13 _day13 = new();
        private readonly Dictionary<(int pairIndex, string id), string> _leftArrays = [];
        private readonly Dictionary<(int pairIndex, string id), string> _rightArrays = [];

        public int Run(string input)
        {
            var packetPairs = input.Split("\r\n\r\n");
            for (var i = 0; i < packetPairs.Length; i++)
            {
                var packetsInPair = packetPairs[i].Split("\r\n");

                var left = _day13.CreateArrays(i, packetsInPair[0], _leftArrays);
                var right = _day13.CreateArrays(i, packetsInPair[1], _rightArrays);

                _pairs.Add((left, right));
            }

            return GetResult();
        }

        private int GetResult()
        {
            var good = new List<int>();
            for (var i = 0; i < _pairs.Count; i++)
            {
                var result = _day13.ProcessArray(i, i, _pairs[i].left, _pairs[i].right, _leftArrays, _rightArrays);
                if (result != null && result == true)
                {
                    good.Add(i + 1);
                }
            }

            return good.Aggregate(0, (a, b) => a + b);
        }
    }
}
