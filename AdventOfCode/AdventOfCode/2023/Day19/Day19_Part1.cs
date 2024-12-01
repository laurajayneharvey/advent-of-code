namespace AdventOfCode._2023.Day19
{
    public class Condition
    {
        public char Category;
        public char Comparison;
        public long SecondValue;
        public string GoTo;
        public bool Accept => GoTo == "A";
        public bool Reject => GoTo == "R";
    }

    public class Workflow
    {
        public string Name;
        public List<Condition> Conditions = [];
        public string GoTo;
        public bool Accept => GoTo == "A";
        public bool Reject => GoTo == "R";
    }

    public class MachinePart
    {
        public long X;
        public long M;
        public long A;
        public long S;
    }

    public class Day19_Part1
    {
        public long Run(string input)
        {
            var sections = input.Split("\r\n\r\n");

            var workflows = GetWorkflows(sections[0].Split("\r\n"));
            var machineParts = GetMachineParts(sections[1].Split("\r\n"));

            long total = 0;
            foreach (var machinePart in machineParts)
            {
                var result = ProcessWorkflow(machinePart, workflows, workflows.First(x => x.Name == "in"));
                if (result)
                {
                    var sum = machinePart.X + machinePart.M + machinePart.A + machinePart.S;
                    total += sum;
                }
            }

            return total;
        }

        private static bool ProcessWorkflow(MachinePart machinePart, List<Workflow> workflows, Workflow workflow)
        {
            var result = ProcessConditions(machinePart, workflows, workflow);

            if (result != null)
            {
                return result.Value;
            }

            if (workflow.Accept)
            {
                return true;
            }

            if (workflow.Reject)
            {
                return false;
            }

            workflow = workflows.First(x => x.Name == workflow.GoTo);
            return ProcessWorkflow(machinePart, workflows, workflow);
        }

        private static bool? ProcessConditions(MachinePart machinePart, List<Workflow> workflows, Workflow workflow)
        {
            foreach (var condition in workflow.Conditions)
            {
                var result = ProcessCondition(machinePart, condition, workflows);

                if (result != null)
                {
                    return result.Value;
                }
            }

            return null;
        }

        private static bool? ProcessCondition(MachinePart machinePart, Condition condition, List<Workflow> workflows)
        {
            long firstValue = GetFirstValue(machinePart, condition);

            if ((condition.Comparison == '<' && firstValue < condition.SecondValue)
                || (condition.Comparison == '>' && firstValue > condition.SecondValue))
            {
                if (condition.Accept)
                {
                    return true;
                }

                if (condition.Reject)
                {
                    return false;
                }

                var workflow = workflows.First(x => x.Name == condition.GoTo);
                return ProcessWorkflow(machinePart, workflows, workflow);
            }

            return null;
        }

        private static long GetFirstValue(MachinePart machinePart, Condition condition)
        {
            long firstValue = 0;
            switch (condition.Category)
            {
                case 'x':
                    firstValue = machinePart.X;
                    break;
                case 'm':
                    firstValue = machinePart.M;
                    break;
                case 'a':
                    firstValue = machinePart.A;
                    break;
                case 's':
                    firstValue = machinePart.S;
                    break;
            }

            return firstValue;
        }

        private static List<MachinePart> GetMachineParts(string[] inputMachineParts)
        {
            var machineParts = new List<MachinePart>();
            foreach (var inputMachinePart in inputMachineParts)
            {
                var ratings = inputMachinePart.Replace("{", string.Empty).Replace("}", string.Empty).Split(",");
                machineParts.Add(new MachinePart
                {
                    X = long.Parse(ratings[0].Split("=")[1]),
                    M = long.Parse(ratings[1].Split("=")[1]),
                    A = long.Parse(ratings[2].Split("=")[1]),
                    S = long.Parse(ratings[3].Split("=")[1])
                });
            }

            return machineParts;
        }

        private static List<Workflow> GetWorkflows(string[] inputWorkflows)
        {
            var workflows = new List<Workflow>();
            foreach (var inputWorkflow in inputWorkflows)
            {
                var workflow = new Workflow
                {
                    Name = inputWorkflow.Split("{")[0]
                };

                var inputConditions = inputWorkflow.Split("{")[1].Split("}")[0].Split(",");
                var conditions = new List<Condition>();

                for (var i = 0; i < inputConditions.Length; i++)
                {
                    var inputCondition = inputConditions[i];

                    if (i == inputConditions.Length - 1)
                    {
                        workflow.GoTo = inputCondition;
                    }
                    else
                    {
                        var conditionParts = inputCondition.Split(":");
                        var evaluation = conditionParts[0];

                        conditions.Add(new Condition
                        {
                            Category = evaluation[0],
                            Comparison = evaluation[1],
                            GoTo = conditionParts[1],
                            SecondValue = long.Parse(evaluation[2..])
                        });
                    }
                }

                workflow.Conditions = conditions;
                workflows.Add(workflow);
            }

            return workflows;
        }
    }
}
