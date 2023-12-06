using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		var waitForIt = new WaitForIt();
		waitForIt.Run();
	}
}

public class Race
{
	public int Time;
	public int RecordDistance;
}

public class WaitForIt
{
	public void Run()
	{
		var input = @"Time:        63     78     94     68
Distance:   411   1274   2047   1035";
		
		var races = GetRaces(input);
		
		var product = 1;
		foreach (Race race in races)
		{
			var exceededRecordCount = CalculateWinningRaces(race);
			if (exceededRecordCount != 0)
			{
				product *= exceededRecordCount;
			}
		}
		
		Console.WriteLine(product);
	}
	
	public IList<Race> GetRaces(string input)
	{
		var lines = input.Split("\n");
		var timesLine = lines[0].Replace("Time:", string.Empty).Trim();
		var distanceLine = lines[1].Replace("Distance:", string.Empty).Trim();
		
		var regex = new Regex(@"(\S+)|(\s+(?=\S))");
		var timeMatches = regex.Matches(timesLine);
		var times = timeMatches.Where(m => !string.IsNullOrWhiteSpace(m.Value)).Select(m => m.Value).ToList();
		var distanceMatches = regex.Matches(distanceLine);
		var distances = distanceMatches.Where(m => !string.IsNullOrWhiteSpace(m.Value)).Select(m => m.Value).ToList();
		
		var races = new List<Race>();
		for (var i = 0; i < times.Count; i++)
		{
			races.Add(new Race {
				Time = int.Parse(times[i]),
				RecordDistance = int.Parse(distances[i])
			});
		}
		
		return races;
	}
	
	public int CalculateWinningRaces(Race race)
	{
		var exceededRecordCount = 0;
		for (var buttonHold = 0; buttonHold <= race.Time; buttonHold++)
		{
			var time = race.Time - buttonHold;
			var speed = buttonHold;
			var distance = time * speed;
			
			if (distance > race.RecordDistance)
			{
				exceededRecordCount++;
			}
		}
		
		return exceededRecordCount;
	}
}