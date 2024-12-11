using System;
using System.Drawing;

namespace AdventOfCode._2024.Day9
{
    public class Day9_Part2
    {
        public long Run(string input)
        {
            var diskMap = input.ToCharArray().Select((item, index) => (int.Parse(item.ToString()), index));

            var fileSizes = diskMap.Where(x => x.index % 2 == 0).Select(x => new File { OriginalIndex = x.index, Size = x.Item1 });
            var freeSpaces = diskMap.Where(x => x.index % 2 == 1).Select(x => new Space { OriginalIndex = x.index, Size = x.Item1 }).ToList();

            var reversedFileSizes = fileSizes.Reverse().ToList();
            while (reversedFileSizes.FirstOrDefault(x => !x.Checked) != null)
            {
                var file = reversedFileSizes.First(x => !x.Checked);
                file.Checked = true;
                reversedFileSizes[reversedFileSizes.IndexOf(file)] = file;

                var freeSpace = freeSpaces.FirstOrDefault(x => x.MovedFile == -1 && x.Size >= file.Size && x.OriginalIndex < file.OriginalIndex);
                if (freeSpace == null)
                {
                    continue;
                }

                if (freeSpace.Size > file.Size) // split
                {
                    var index = freeSpaces.IndexOf(freeSpace);
                    freeSpaces[index] = new Space
                    {
                        MovedFile = file.OriginalIndex,
                        Size = file.Size,
                        OriginalIndex = freeSpace.OriginalIndex
                    };
                    freeSpaces.Insert(index + 1, new Space
                    {
                        MovedFile = -1,
                        Size = freeSpace.Size - file.Size,
                        OriginalIndex = freeSpace.OriginalIndex
                    });
                }
                else
                {
                    freeSpace.MovedFile = file.OriginalIndex;
                    freeSpaces[freeSpaces.IndexOf(freeSpace)] = freeSpace;
                }
            }

            var isFile = true;
            var ordered = new List<int>();
            long checksum = 0;
            //var print = string.Empty;
            foreach (var index in diskMap.Select(x => x.index))
            {
                if (isFile)
                {
                    var file = fileSizes.FirstOrDefault(x => x.OriginalIndex == index);
                    if (file == null)
                    {
                        continue;
                    }
                    var currentIndex = ordered.Count;
                    var fileMoved = freeSpaces.FirstOrDefault(x => x.MovedFile == file.OriginalIndex) != null;
                    var fileIndex = file.OriginalIndex / 2;
                    for (var i = 0; i < file.Size; i++)
                    {
                        if (!fileMoved)
                        {
                            checksum += (currentIndex + i) * fileIndex;
                        }
                    }
                    ordered.AddRange(Enumerable.Range(0, file.Size));
                }
                else
                {
                    var spaces = freeSpaces.Where(x => x.OriginalIndex == index);
                    foreach (var space in spaces)
                    {
                        var currentIndex = ordered.Count;
                        var fileMoved = space.MovedFile != -1;
                        for (var i = 0; i < space.Size; i++)
                        {
                            if (fileMoved)
                            {
                                checksum += (currentIndex + i) * space.MovedFile / 2;
                            }
                        }
                        ordered.AddRange(Enumerable.Range(0, space.Size));
                    }
                }
                isFile = !isFile;
            }

            return checksum;
        }
    }

    public class File
    {
        public int OriginalIndex;
        public int Size;
        public bool Checked = false;
    }

    public class Space
    {
        public int OriginalIndex;
        public int Size;
        public int MovedFile = -1;
    }
}
