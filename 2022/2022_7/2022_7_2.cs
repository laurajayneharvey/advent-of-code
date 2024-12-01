using System.Text.RegularExpressions;

var input = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";

var fileSystemItems = new List<FileSystemItem> { new() { Name = "/", Parent = null, IsDirectory = true } };
var currentDirectory = fileSystemItems.First();

var regex = new Regex("\r\n");
var commands = regex.Split(input).ToList();
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
var totalDiskSpace = 70000000;
var remainingDiskSpace = totalDiskSpace - fileSystemItems.First().Size;
var requiredForUpdate = 30000000;
var needToFreeUp = requiredForUpdate - remainingDiskSpace;
var directoryToDelete = fileSystemItems.Where(x => x.IsDirectory && x.Size >= needToFreeUp).OrderBy(y => y.Size).First();
Console.WriteLine($"Part 2 answer: {directoryToDelete.Size}");
Console.ReadLine();

int StepsToTop(List<FileSystemItem> fileSystemItems, FileSystemItem fileSystemItem)
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

bool IsUncalculatedButChildrenCalculated(List<FileSystemItem> fileSystemItems, FileSystemItem x)
{
    return x.IsDirectory && x.Size == null && fileSystemItems.Where(y => y.Parent == x).All(z => z.Size != null);
}

void CalculateTotalSizes(List<FileSystemItem> fileSystemItems)
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

public class FileSystemItem
{
    public string Name { get; set; }
    public FileSystemItem? Parent { get; set; }
    public bool IsDirectory { get; set; }
    public int? Size { get; set; }
}