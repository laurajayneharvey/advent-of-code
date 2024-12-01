namespace AdventOfCode._2022.Day7
{
    public class Day7_Part2
    {
        private readonly Day7 _day7;

        public Day7_Part2()
        {
            _day7 = new Day7();
        }

        public int? Run(string input)
        {
            var fileSystemItems = _day7.GetFileSystems(input);

            var totalDiskSpace = 70000000;
            var remainingDiskSpace = totalDiskSpace - fileSystemItems.First().Size;
            var requiredForUpdate = 30000000;
            var needToFreeUp = requiredForUpdate - remainingDiskSpace;
            var directoryToDelete = fileSystemItems.Where(x => x.IsDirectory && x.Size >= needToFreeUp).OrderBy(y => y.Size).First();

            return directoryToDelete.Size;
        }
    }
}
