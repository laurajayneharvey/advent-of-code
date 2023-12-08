using System;

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
	public double Time;
	public double RecordDistance;
}

public class WaitForIt
{
	public void Run()
	{
		var input = @"Time:      7  15   30
Distance:  9  40  200";
		
		var race = GetRace(input);
		
		var exceededRecordCount = CalculateWinningRace(race);
		
		Console.WriteLine(exceededRecordCount);
	}
	
	public Race GetRace(string input)
	{
		var lines = input.Split("\n");
		var time = lines[0].Replace("Time:", string.Empty).Replace(" ", string.Empty);
		var distance = lines[1].Replace("Distance:", string.Empty).Replace(" ", string.Empty);
		
		return new Race {
			Time = double.Parse(time),
			RecordDistance = double.Parse(distance)
		};
	}
	
	public int CalculateWinningRace(Race race)
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