using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public class Node
	{
		public string Origin;
		public string Left;
		public string Right;
	}
	public class HauntedWasteland
	{
		public char[] GetInstructions(string input)
		{
			return input.ToCharArray();
		}
		
		public List<Node> GetNodes(string input)
		{		
			var network = input.Split("\n");
			var nodes = new List<Node>();
			foreach (var nodeLine in network)
			{
				var origin = nodeLine.Substring(0, 3);
				var left = nodeLine.Substring(7, 3);
				var right = nodeLine.Substring(12, 3);
				nodes.Add(new Node {Origin = origin, Left = left, Right = right});
			}
			
			return nodes;
		}
		
		public double GreatestCommonFactor(double a, double b)
		{
			while (b != 0)
			{
				var temp = b;
				b = a % b;
				a = temp;
			}
			
			return a;
		}

		public double LowestCommonMultiple(double a, double b)
		{
			var greatestCommonFactor = GreatestCommonFactor(a, b);
			return (a / greatestCommonFactor) * b;
		}

		public void Run()
		{
			var input = @"LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)";
		
			var regex = new Regex("\n\n");
			var parts = regex.Split(input);
			
			var instructions = GetInstructions(parts[0]);
			var nodes = GetNodes(parts[1]);
			
			var activeNodes = nodes.Where(x => x.Origin.EndsWith("A"));
			
			double lowestCommonMultiple = 1;
			foreach (var activeNode in activeNodes)
			{
				var current = activeNode.Origin;
				var index = 0;
				while (!current.EndsWith("Z"))
				{
					var node = nodes.First(x => x.Origin == current);

					var directionIndex = index % instructions.Count();
					var direction = instructions[directionIndex];
					if (direction == 'L')
					{
						current = node.Left;
					}
					else
					{
						current = node.Right;
					}

					index++;
				}
				
				lowestCommonMultiple = LowestCommonMultiple(lowestCommonMultiple, Convert.ToDouble(index));
			}
			Console.WriteLine(lowestCommonMultiple);
		}
	}
	
	public static void Main()
	{
		var hauntedWasteland = new HauntedWasteland();
		hauntedWasteland.Run();
	}
}