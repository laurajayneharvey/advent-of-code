namespace AdventOfCode._2025.Day11
{
    public class Day11_Part1
    {
        public int Run(string input)
        {
            var deviceRows = input.Split("\r\n");
            var devices = new List<Device>();
            foreach (var deviceRow in deviceRows)
            {
                devices.Add(new Device
                {
                    Name = deviceRow.Split(':')[0],
                    Outputs = [.. deviceRow.Split(":")[1].Split(' ').Where(x => x != string.Empty).Select(x => x.Trim())]
                });
            }

            var current = "you";
            var paths = new List<Path>
            {
                new() { Devices = [current] }
            };
            devices = [.. devices.Where(d => !d.Outputs.Contains(current))];

            while (paths.Any(p => !p.ReachedEnd))
            {
                var path = paths.First(p => !p.ReachedEnd);

                var device = devices.FirstOrDefault(d => d.Name == path.Devices.Last());
                if (device == null)
                {
                    paths.First(p => !p.ReachedEnd).ReachedEnd = true;
                    continue;
                }

                var outputs = device.Outputs;

                foreach (var output in outputs)
                {
                    var newPath = new Path();
                    newPath.Devices.AddRange(path.Devices);
                    newPath.Devices.Add(output);
                    paths.Add(newPath);
                }

                paths = [.. paths.Where(p => !p.Devices.SequenceEqual(path.Devices))];
            }

            return paths.Count(p => p.Devices.Last() == "out");
        }

        public class Path
        {
            public List<string> Devices { get; set; } = [];
            public bool ReachedEnd { get; set; }
        }

        public class Device
        {
            public string Name { get; set; }
            public List<string> Outputs { get; set; }
        }
    }
}
