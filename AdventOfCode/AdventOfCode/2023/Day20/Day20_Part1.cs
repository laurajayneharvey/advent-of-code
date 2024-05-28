namespace AdventOfCode._2023.Day20
{
    public class Module
    {
        public bool IsOn;
        public string Name;
        public List<string> Destinations;
        public ModuleType ModuleType;
    }

    public class ConjunctionModule : Module
    {
        public Dictionary<string, bool> LastInputPulses = [];
    }

    public class Pulse
    {
        public bool IsHigh;
        public string TargetName;
        public string InputName;
    }

    public enum ModuleType
    {
        FlipFlop,
        Conjunction,
        Broadcaster
    }

    public class Day20_Part1
    {
        private readonly List<Module> modules = [];

        public long Run(string input)
        {
            Dictionary<ModuleType, Func<Pulse, List<Pulse>>> moduleFunctions = [];

            moduleFunctions.Add(ModuleType.FlipFlop, (input) =>
            {
                if (input.IsHigh)
                {
                    // do nothing
                    return [];
                }

                var module = modules.First(x => x.Name == input.TargetName);
                module.IsOn = !module.IsOn;

                return module.Destinations.Select(x => new Pulse
                {
                    IsHigh = module.IsOn,
                    TargetName = x,
                    InputName = input.TargetName
                }).ToList();
            });

            moduleFunctions.Add(ModuleType.Conjunction, (input) =>
            {
                var module = modules.First(x => x.Name == input.TargetName) as ConjunctionModule;

                // When a pulse is received, the conjunction module first updates its memory for that input. 
                module.LastInputPulses[input.InputName] = input.IsHigh;

                var isHigh = false; // Then, if it remembers high pulses for all inputs, it sends a low pulse; 
                if (module.LastInputPulses.Values.Any(x => x == false)) // otherwise, it sends a high pulse.
                {
                    isHigh = true;
                }

                return module.Destinations.Select(x => new Pulse
                {
                    IsHigh = isHigh,
                    TargetName = x,
                    InputName = input.TargetName
                }).ToList();
            });

            moduleFunctions.Add(ModuleType.Broadcaster, (input) =>
            {
                var module = modules.First(x => x.Name == input.TargetName);

                return module.Destinations.Select(x => new Pulse
                {
                    IsHigh = input.IsHigh,
                    TargetName = x,
                    InputName = input.TargetName
                }).ToList();
            });

            foreach (var module in input.Split("\r\n"))
            {
                var parts = module.Split(" -> ");
                var namePart = parts[0];

                var moduleType = ModuleType.Broadcaster;
                var name = nameof(ModuleType.Broadcaster).ToLower();

                if (module.StartsWith('%'))
                {
                    moduleType = ModuleType.FlipFlop;
                    name = namePart[1..];
                }
                else if (module.StartsWith('&'))
                {
                    moduleType = ModuleType.Conjunction;
                    name = namePart[1..];
                }

                var destinations = parts[1].Split(", ").ToList();

                if (moduleType == ModuleType.Conjunction)
                {
                    modules.Add(new ConjunctionModule
                    {
                        Destinations = destinations,
                        IsOn = false,
                        ModuleType = moduleType,
                        Name = name
                    });
                }
                else
                {
                    modules.Add(new Module
                    {
                        Destinations = destinations,
                        IsOn = false,
                        ModuleType = moduleType,
                        Name = name
                    });
                }
            }

            foreach (var conjunctionModule in modules.Where(m => m.ModuleType == ModuleType.Conjunction))
            {
                // Conjunction modules (prefix &) remember the type of the most recent pulse received from each of their connected input modules;
                var inputNames = modules.Where(m => m.Destinations.Contains(conjunctionModule.Name)).Select(m => m.Name);
                foreach (var inputName in inputNames)
                {
                    // they initially default to remembering a low pulse for each input.
                    (conjunctionModule as ConjunctionModule).LastInputPulses.Add(inputName, false);
                }
            }

            var buttonPushes = 1000;
            var lowPulses = buttonPushes;
            var highPulses = 0;
            for (var i = 0; i < buttonPushes; i++)
            {
                var pulses = new List<Pulse> { new() {
                    IsHigh = false,
                    TargetName = nameof(ModuleType.Broadcaster).ToLower(),
                    InputName = "button"
                }};

                while (pulses.Count > 0)
                {
                    var pulse = pulses.First();
                    pulses.RemoveAt(0);

                    var module = modules.FirstOrDefault(m => m.Name == pulse.TargetName);

                    if (module != null)
                    {
                        var newPulsesFunction = moduleFunctions[module.ModuleType];
                        var newPulses = newPulsesFunction(pulse);
                        pulses.AddRange(newPulses);

                        highPulses += newPulses.Count(p => p.IsHigh);
                        lowPulses += newPulses.Count(p => !p.IsHigh);
                    }
                }
            }

            return highPulses * lowPulses;
        }
    }
}
