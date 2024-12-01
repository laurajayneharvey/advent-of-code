using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public class MirageMaintenance
	{
		public void Run()
		{
			var input = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45";
			
			var histories = input.Split("\n").ToList();
			Console.WriteLine("Part 1: " + GetResult(histories));
			Console.WriteLine("Part 2: " + GetResult(histories, true));
		}
		
		public int GetResult(List<string> histories, bool part2 = false)
		{
			var overall = histories.Sum(history => {
				var historyLine = history.Split(" ").Select(x => int.Parse(x)).ToList();
				if (part2)
				{
					historyLine.Reverse();
				}
				return GetNextItem(historyLine);
			});
			
			return overall;
		}
		
		public int GetNextItem(List<int> history)
		{			
			var lines = new List<List<int>>() { history };
			while (!history.All(x => x == 0))
			{
				var newHistoryLine = new List<int>();
				for (var i = 0; i < history.Count() - 1; i++)
				{
					newHistoryLine.Add(history[i + 1] - history[i]);
				}
				lines.Add(newHistoryLine);
				history = newHistoryLine;
			}
			
			return lines.Sum(line => line[line.Count() - 1]);
		}
	}
	
	public static void Main()
	{
		var mirageMaintenance = new MirageMaintenance();
		mirageMaintenance.Run();
	}
}