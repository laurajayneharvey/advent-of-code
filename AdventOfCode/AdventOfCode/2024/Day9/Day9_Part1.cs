using System.Numerics;

namespace AdventOfCode._2024.Day9
{
    public class Day9_Part1
    {
        public long Run(string input)
        {
            var diskMap = input.ToCharArray().Select((item, index) => (int.Parse(item.ToString()), index));

            var fileSizes = diskMap.Where(x => x.index % 2 == 0).Select(x => x.Item1);
            var freeSpace = diskMap.Where(x => x.index % 2 == 1).Select(x => x.Item1).Sum();
            var fileCount = fileSizes.Count();

            var reversed = diskMap.Reverse();
            var toMove = new List<int>();
            var backward = fileCount - 1;
            var isFile = true;
            while (true)
            {
                var size = reversed.First().Item1;
                for (var i = 0; i < size; i++)
                {
                    if (toMove.Count == freeSpace)
                    {
                        break;
                    }
                    if (isFile)
                    {
                        toMove.Add(backward);
                    }
                    else
                    {
                        toMove.Add(-1);
                    }
                }

                if (isFile)
                {
                    backward--;
                }

                if (reversed.Count() == 1)
                {
                    break;
                }
                reversed = reversed.Skip(1).ToList();
                isFile = !isFile;
            }
            toMove = toMove.Where(x => x != -1).ToList();

            var stayInPlaceSpace = fileSizes.Sum() - toMove.Count;

            var stayInPlace = new List<int>();
            var forward = 0;
            while (true)
            {
                var size = fileSizes.First();
                for (var i = 0; i < size; i++)
                {
                    if (stayInPlace.Count == stayInPlaceSpace)
                    {
                        break;
                    }
                    stayInPlace.Add(forward);
                }

                forward++;

                if (fileSizes.Count() == 1)
                {
                    break;
                }
                fileSizes = fileSizes.Skip(1).ToList();
            }

            var useStayInPlace = true;
            var ordered = new List<int>();
            long checksum = 0;
            foreach (var size in diskMap.Select(x => x.Item1))
            {
                if (useStayInPlace)
                {
                    var currentIndex = ordered.Count;
                    for (var i = 0; i < Math.Min(size, stayInPlace.Count); i++)
                    {
                        checksum += (currentIndex + i) * stayInPlace[i];
                    }
                    ordered.AddRange(stayInPlace.GetRange(0, Math.Min(size, stayInPlace.Count)));
                    stayInPlace = stayInPlace.Skip(size).ToList();
                }
                else
                {
                    var currentIndex = ordered.Count;
                    for (var i = 0; i < Math.Min(size, toMove.Count); i++)
                    {
                        checksum += (currentIndex + i) * toMove[i];
                    }
                    ordered.AddRange(toMove.GetRange(0, Math.Min(size, toMove.Count)));
                    toMove = toMove.Skip(size).ToList();
                }
                useStayInPlace = !useStayInPlace;
            }

            return checksum;
        }
    }
}
