namespace AdventOfCode._2022.Day7
{
    public class Day7
    {
        public List<FileSystemItem> GetFileSystems(string input)
        {
            var fileSystemItems = new List<FileSystemItem> { new() { Name = "/", Parent = null, IsDirectory = true } };
            var currentDirectory = fileSystemItems.First();

            var commands = input.Split("\r\n").ToList();
            commands = commands.Skip(2).ToList();

            foreach (var command in commands)
            {
                if (command.StartsWith("$ cd "))
                {
                    var name = command.Replace("$ cd ", string.Empty);
                    if (name == "..")
                    {
                        currentDirectory = currentDirectory.Parent;
                    }
                    else
                    {
                        currentDirectory = fileSystemItems.First(x => x.Parent == currentDirectory && x.Name == name);
                    }
                }
                else if (command.StartsWith("$ ls"))
                {
                    continue;
                }
                else if (command.StartsWith("dir "))
                {
                    var directory = command.Replace("dir ", string.Empty);
                    fileSystemItems.Add(new() { Name = directory, Parent = currentDirectory, IsDirectory = true });
                }
                else
                {
                    var fileParts = command.Split(" ");
                    fileSystemItems.Add(new() { Name = fileParts[1], Parent = currentDirectory, IsDirectory = false, Size = int.Parse(fileParts[0]) });
                }
            }

            CalculateTotalSizes(fileSystemItems);

            return fileSystemItems;
        }

        private void CalculateTotalSizes(List<FileSystemItem> fileSystemItems)
        {
            while (fileSystemItems.Any(x => IsUncalculatedButChildrenCalculated(fileSystemItems, x)))
            {
                fileSystemItems = fileSystemItems.Select(x =>
                {
                    var uncalculated = IsUncalculatedButChildrenCalculated(fileSystemItems, x);
                    if (uncalculated)
                    {
                        x.Size = fileSystemItems.Where(y => y.Parent == x).Sum(z => z.Size);
                    }
                    return x;
                }).ToList();
            }
        }

        private bool IsUncalculatedButChildrenCalculated(List<FileSystemItem> fileSystemItems, FileSystemItem x)
        {
            return x.IsDirectory && x.Size == null && fileSystemItems.Where(y => y.Parent == x).All(z => z.Size != null);
        }

        private int StepsToTop(List<FileSystemItem> fileSystemItems, FileSystemItem fileSystemItem)
        {
            var steps = 0;
            var current = fileSystemItem;
            while (current.Parent != null)
            {
                current = current.Parent;
                steps++;
            }

            return steps;
        }
    }

    public class FileSystemItem
    {
        public string Name { get; set; }
        public FileSystemItem? Parent { get; set; }
        public bool IsDirectory { get; set; }
        public int? Size { get; set; }
    }
}
