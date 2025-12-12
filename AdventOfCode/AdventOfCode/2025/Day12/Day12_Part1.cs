namespace AdventOfCode._2025.Day12
{
    public class Day12_Part1
    {
        public int Run(string input)
        {
            var parts = input.Split("\r\n\r\n");

            var presents = parts.Select(s => s.ToCharArray().Count(c => c == '#')).Where(c => c != 0).ToList();
            var regions = parts.Last().Split("\r\n");

            var canFitCount = 0;
            foreach (var region in regions)
            {
                var dimensionParts = region.Split(':')[0].Split('x');
                var dimension = int.Parse(dimensionParts[0]) * int.Parse(dimensionParts[1]);

                var presentsRequired = region.Split(':')[1].Split(' ').Where(c => c != string.Empty).Select(int.Parse).ToList();
                var spaceRequired = 0;
                for (var i = 0; i < presentsRequired.Count; i++)
                {
                    spaceRequired += presents[i] * presentsRequired[i];
                }

                if (spaceRequired <= dimension)
                {
                    canFitCount++;
                }
            }

            return canFitCount;
        }
    }
}
