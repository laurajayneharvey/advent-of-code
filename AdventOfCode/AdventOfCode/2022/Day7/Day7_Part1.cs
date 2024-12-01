namespace AdventOfCode._2022.Day7
{
    public class Day7_Part1
    {
        private readonly Day7 _day7 = new();

        public int? Run(string input)
        {
            var fileSystemItems = _day7.GetFileSystems(input);

            var sumDirectoriesSizeUpTo100000 = fileSystemItems.Where(x => x.IsDirectory && x.Size <= 100000).Sum(y => y.Size);

            return sumDirectoriesSizeUpTo100000;
        }
    }
}
