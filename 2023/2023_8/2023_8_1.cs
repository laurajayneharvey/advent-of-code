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
		
		public void Run()
		{
			var input = @"LLR

AAA = (BBB, BBB)
BBB = (AAA, ZZZ)
ZZZ = (ZZZ, ZZZ)";
		
			var regex = new Regex("\n\n");
			var parts = regex.Split(input);
			
			var instructions = GetInstructions(parts[0]);
			var nodes = GetNodes(parts[1]);
			
			var current = "AAA";
			var index = 0;
			while (current != "ZZZ")
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
			
			Console.WriteLine(index);
		}
	}
	
	public static void Main()
	{
		var hauntedWasteland = new HauntedWasteland();
		hauntedWasteland.Run();
	}
}