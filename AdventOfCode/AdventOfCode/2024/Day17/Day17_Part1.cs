namespace AdventOfCode._2024.Day17
{
    public class Day17_Part1
    {
        private int _registerA;
        private int _registerB;
        private int _registerC;

        public (string output, int a, int b, int c) Run(string input)
        {
            var lines = input.Split("\r\n");

            _registerA = int.Parse(lines[0].Split(": ")[1]);
            _registerB = int.Parse(lines[1].Split(": ")[1]);
            _registerC = int.Parse(lines[2].Split(": ")[1]);

            var programme = lines[4].Split(": ")[1];
            var programmeParts = programme.Split(",");

            var i = 0;
            var pairs = new List<Pairs>();
            while (i < programmeParts.Length)
            {
                pairs.Add(new Pairs
                {
                    Instruction = int.Parse(programmeParts[i]),
                    Operand = int.Parse(programmeParts[i + 1])
                });

                i += 2;
            }

            var instructionPointer = 0;
            var output = new List<int>();
            while (instructionPointer < pairs.Count)
            {
                var pair = pairs[instructionPointer];
                var skipInstructionPointerIncrement = false;

                var comboOperand = 0;
                switch (pair.Operand)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        comboOperand = pair.Operand;
                        break;
                    case 4:
                        comboOperand = _registerA;
                        break;
                    case 5:
                        comboOperand = _registerB;
                        break;
                    case 6:
                        comboOperand = _registerC;
                        break;
                    default:
                        // invalid operand
                        break;
                }

                switch (pair.Instruction)
                {
                    case 0:
                        Dv(comboOperand, 'a');
                        break;
                    case 1:
                        Bxl(pair.Operand); // use literal operand
                        break;
                    case 2:
                        Bst(comboOperand);
                        break;
                    case 3:
                        Jnz(pair.Operand, ref instructionPointer); // use literal operand
                        skipInstructionPointerIncrement = true;
                        break;
                    case 4:
                        Bxt();
                        break;
                    case 5:
                        output.Add(Out(comboOperand));
                        break;
                    case 6:
                        Dv(comboOperand, 'b');
                        break;
                    case 7:
                        Dv(comboOperand, 'c');
                        break;
                    default:
                        // invalid operation
                        break;
                }

                if (!skipInstructionPointerIncrement)
                {
                    instructionPointer++;
                }
            }

            return (string.Join(',', output), _registerA, _registerB, _registerC);
        }

        private void Dv(int comboOperand, char register)
        {
            var numerator = _registerA;
            var denominator = Math.Pow(2, comboOperand);
            var division = numerator / denominator;
            var asInt = (int)division;
            if (register == 'a')
            {
                _registerA = asInt;
            }
            else if (register == 'b')
            {
                _registerB = asInt;
            }
            else
            {
                _registerC = asInt;
            }
        }

        private void Bxl(int literalOperand)
        {
            _registerB = _registerB ^ literalOperand;
        }

        private void Bst(int comboOperand)
        {
            _registerB = comboOperand % 8;
        }

        private void Jnz(int literalOperand, ref int instructionPointer)
        {
            if (_registerA == 0)
            {
                instructionPointer++;
            }
            else
            {
                instructionPointer = literalOperand / 2;
            }
        }

        private void Bxt()
        {
            _registerB = _registerB ^ _registerC;
        }

        private int Out(int comboOperand)
        {
            return comboOperand % 8;
        }
    }

    public class Pairs
    {
        public int Instruction;
        public int Operand;
    }
}