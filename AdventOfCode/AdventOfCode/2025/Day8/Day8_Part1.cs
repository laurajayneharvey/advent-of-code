namespace AdventOfCode._2025.Day8
{
    public class Day8_Part1
    {
        public int Run(string input, int connectionCount)
        {
            var coordinateRows = input.Split("\r\n");
            var coordinates = new List<Coordinate>();
            for (var i = 0; i < coordinateRows.Length; i++)
            {
                var coordinateRow = coordinateRows[i];
                var parts = coordinateRow.Split(',');
                coordinates.Add(new Coordinate
                {
                    Id = i,
                    X = int.Parse(parts[0]),
                    Y = int.Parse(parts[1]),
                    Z = int.Parse(parts[2])
                });
            }

            var distances = new List<DistancePair>();
            foreach (var a in coordinates)
            {
                foreach (var b in coordinates.Where(c => c.Id > a.Id))
                {
                    var distance = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.Z - b.Z, 2));
                    distances.Add(new DistancePair
                    {
                        A = a,
                        B = b,
                        Distance = distance
                    });
                }
            }

            var orderedDistances = distances.OrderBy(d => d.Distance).ToList();

            var circuitCount = 0;
            var circuits = new List<List<int>>();
            while (circuitCount < connectionCount)
            {
                var shortest = orderedDistances.First();
                orderedDistances = [.. orderedDistances.Skip(1)];
                circuitCount++;

                var circuitWithA = circuits.FirstOrDefault(circuit => circuit.Contains(shortest.A.Id));
                var circuitWithB = circuits.FirstOrDefault(circuit => circuit.Contains(shortest.B.Id));

                if (circuitWithA != null && circuitWithA.Contains(shortest.B.Id) || circuitWithB != null && circuitWithB.Contains(shortest.A.Id))
                {
                    // pair already in same circuit
                    continue;
                }

                if (circuitWithA != null && circuitWithB != null)
                {
                    // each item in a circuit but not the pair together
                    // add all items from B circuit to A
                    // remove B circuit
                    circuits = [.. circuits.Where(c => !c.Contains(shortest.B.Id))];
                    circuits.First(circuit => circuit.Contains(shortest.A.Id)).AddRange(circuitWithB);
                    continue;
                }

                if (circuitWithA != null)
                {
                    circuitWithA.Add(shortest.B.Id);
                }
                else if (circuitWithB != null)
                {
                    circuitWithB.Add(shortest.A.Id);
                }
                else
                {
                    circuits.Add([shortest.A.Id, shortest.B.Id]);
                }
            }

            var orderedCircuits = circuits.OrderByDescending(c => c.Count).ToList();
            var one = orderedCircuits.Count > 0 ? orderedCircuits[0].Count : 1;
            var two = orderedCircuits.Count > 1 ? orderedCircuits[1].Count : 1;
            var three = orderedCircuits.Count > 2 ? orderedCircuits[2].Count : 1;

            return one * two * three;
        }

        private class Coordinate
        {
            public int Id;
            public int X;
            public int Y;
            public int Z;
        }

        private class DistancePair
        {
            public Coordinate A;
            public Coordinate B;
            public double Distance;
        }
    }
}
