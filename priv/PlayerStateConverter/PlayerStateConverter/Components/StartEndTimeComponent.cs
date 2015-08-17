using Entitas;
using System;

[CoreGameAttribute]
public class StartEndTimeComponent : IComponent 
{	
	public DateTime start, end;
}

public static class StartEndTimeComponentExtension
{
	public static int GetTotalSeconds(this Entity e)
	{
		return(int)(e.startEndTime.end - e.startEndTime.start).TotalSeconds;
	}

	public static int GetTotalMilliseconds(this Entity e)
	{
		return(int)(e.startEndTime.end - e.startEndTime.start).TotalMilliseconds;
	}
		
	public static int GetSecondsLeft(this Entity e)
	{
		return(int)(e.startEndTime.end - TimeService.Now).TotalSeconds;
	}

	public static int GetMillisecondsLeft(this Entity e)
	{
		return(int)(e.startEndTime.end - TimeService.Now).TotalMilliseconds;
	}

	public static void AddStartEndTime(this Entity e, int time)
	{
		DateTime start = TimeService.Now;
		DateTime end = start.AddSeconds(time);
		
		e.AddStartEndTime(start, end);
	}

	public static void ReplaceStartEndTime(this Entity e, DateTime start, int time)
	{
		DateTime end = start.AddSeconds(time);
		
		e.ReplaceStartEndTime(start, end);
	}
}