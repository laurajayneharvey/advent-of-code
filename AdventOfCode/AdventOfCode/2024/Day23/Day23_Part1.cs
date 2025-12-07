namespace AdventOfCode._2024.Day23
{
    public class Day23_Part1
    {
        public long Run(string input)
        {
            var networkMap = input.Split("\r\n");

            var networkPairs = new Dictionary<string, List<string>>();
            foreach (var pair in networkMap)
            {
                var first = pair.Split('-')[0];
                var second = pair.Split('-')[1];

                if (!networkPairs.ContainsKey(first))
                {
                    networkPairs.Add(first, []);
                }
                networkPairs[first].Add(second);

                if (!networkPairs.ContainsKey(second))
                {
                    networkPairs.Add(second, []);
                }
                networkPairs[second].Add(first);
            }

            var lanParties = new List<string[]>();
            foreach(var one in networkPairs)
            {
                var twos = networkPairs.Where(x => x.Value.Contains(one.Key));
                foreach (var two in twos)
                {
                    var threes = networkPairs.Where(x => x.Value.Contains(two.Key));
                    foreach (var three in threes)
                    {
                        if (!one.Key.StartsWith('t') && !two.Key.StartsWith('t') && !three.Key.StartsWith('t'))
                        {
                            continue;
                        }

                        if (networkPairs[three.Key].Contains(one.Key))
                        {
                            var potentialLanParty = new[] { one.Key, two.Key, three.Key };
                            
                            if (lanParties.FirstOrDefault(lanParty => lanParty.All(computer => potentialLanParty.Contains(computer))) == null)
                            {
                                lanParties.Add(potentialLanParty);
                            }
                        }
                    }
                }
            }

            return lanParties.Count;
        }
    }
}