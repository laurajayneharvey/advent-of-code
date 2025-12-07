using System.Collections.Generic;
using System.Reflection;

namespace AdventOfCode._2024.Day24
{
    public class Day24_Part1
    {
        private List<GateConnection> _connections = new List<GateConnection>(); 

        public long Run(string input)
        {
            var lines = input.Split("\r\n");

            _connections.AddRange(lines.Where(line => line.Contains(':')).Select(initial => new GateConnection
            {
                Name = initial.Split(": ")[0],
                Value = initial.Split(": ")[1] == "1"
            }));

            _connections.AddRange(lines.Where(line => line.Contains('>')).Select(connection => {
                var parts = connection.Split(' ');

                var operation = Operation.None;
                if (parts[1] == "AND")
                {
                    operation = Operation.And;
                }
                else if (parts[1] == "OR")
                {
                    operation = Operation.Or;
                }
                else if (parts[1] == "XOR")
                {
                    operation = Operation.Xor;
                }

                return new GateConnection
                {
                    Name = parts[4],
                    Value = null,
                    Operation = operation,
                    Operand1Name = parts[0],
                    Operand2Name = parts[2]
                };
            }));

            while (_connections.Any(c => c.Name.StartsWith('z') && c.Value == null))
            {
                var toUse = _connections.Where(c => c.Value != null && !c.Used);
                foreach (var item in toUse)
                {
                    var op1s = _connections.Where(c => c.Operand1Name == item.Name);
                    foreach (var op1 in op1s)
                    {
                        op1.Operand1Value = item.Value;
                    }
                    var op2s = _connections.Where(c => c.Operand2Name == item.Name);
                    foreach (var op2 in op2s)
                    {
                        op2.Operand2Value = item.Value;
                    }
                    item.Used = true;
                }

                var canSetValue = _connections.Where(c => c.Operand1Value != null && c.Operand2Value != null && c.Value == null);
                foreach (var item in canSetValue)
                {
                    item.Value = GetValue(item.Operation, item.Operand1Value.Value, item.Operand2Value.Value);
                }
            }

            var z = new List<(int Name, string Value)>();
            foreach (var item in _connections.Where(c => c.Name.StartsWith('z')))
            {
                var name = item.Name == "z00" ? 0 : int.Parse(item.Name.Replace("z", "").TrimStart('0'));
                var value = item.Value == true ? "1" : "0";
                z.Add((name, value));
            }

            var zSorted = z.OrderByDescending(c => c.Name);
            var asDecimal = string.Join("", zSorted.Select(c => c.Value));
            var asBinary = Convert.ToInt64(asDecimal, 2);

            return asBinary;
        }

        private bool GetValue(Operation operation, bool operand1Value, bool operand2Value)
        {
            if (operation == Operation.And)
            {
                return operand1Value && operand2Value;
            }
            else if (operation == Operation.Or)
            {
                return operand1Value || operand2Value;
            }

            // Xor
            return operand1Value ^ operand2Value;
        }
    }

    public class GateConnection
    {
        public string Name;
        public Operation Operation = Operation.None;
        public bool? Value = null;
        public string? Operand1Name = null;
        public string? Operand2Name = null;
        public bool? Operand1Value = null;
        public bool? Operand2Value = null;
        //public bool Initial => Operation == Operation.None;
        public bool Used = false;
    }

    public enum Operation
    {
        None,
        And,
        Or,
        Xor
    }
}