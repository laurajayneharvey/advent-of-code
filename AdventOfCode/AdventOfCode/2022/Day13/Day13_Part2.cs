namespace AdventOfCode._2022.Day13
{
    public class Day13_Part2
    {
        private static readonly string _divider1 = "[[2]]";
        private static readonly string _divider2 = "[[6]]";

        private readonly List<(int pairIndex, string line)> _pairs = [];
        private readonly Day13 _day13;
        private Dictionary<(int pairIndex, string id), string> _leftArrays = [];
        private Dictionary<(int pairIndex, string id), string> _rightArrays = [];

        public Day13_Part2()
        {
            _day13 = new Day13();
        }

        public int Run(string input)
        {
            var packetPairs = input.Split("\r\n\r\n");
            var pairIndex = 0;
            for (var i = 0; i < packetPairs.Length; i++)
            {
                var packetsInPair = packetPairs[i].Split("\r\n");

                _pairs.Add((pairIndex, packetsInPair[0]));
                pairIndex++;
                _pairs.Add((pairIndex, packetsInPair[1]));
                pairIndex++;
            }

            _pairs.Add((2 * packetPairs.Length, _divider1));
            _pairs.Add(((2 * packetPairs.Length) + 1, _divider2));

            return GetResult(packetPairs.Length);
        }

        private int GetResult(int packetPairCount)
        {
            _pairs.Sort((a, b) =>
            {
                _leftArrays = [];
                _rightArrays = [];
                var left = _day13.CreateArrays(a.pairIndex, a.line, _leftArrays);
                var right = _day13.CreateArrays(b.pairIndex, b.line, _rightArrays);
                var result = _day13.ProcessArray(a.pairIndex, b.pairIndex, left, right, _leftArrays, _rightArrays);
                if (result == null)
                {
                    return 1;
                }

                return result.Value ? -1 : 1;
            });

            var divider1Position = _pairs.FindIndex(x => x.pairIndex == 2 * packetPairCount) + 1;
            var divider2Position = _pairs.FindIndex(x => x.pairIndex == (2 * packetPairCount) + 1) + 1;

            return divider1Position * divider2Position;
        }
    }
}
