using Entitas;
using System;

[CoreGameAttribute]
public class ProductionComponent : IComponent
{
	public DateTime startTime, endTime;
}

public static class ProductionComponentExtension
{
	public static int GetProductionTimeTotalSeconds(this Entity e)
	{
		return(int)(e.production.endTime - e.production.startTime).TotalSeconds;
	}

	public static int GetProductionTimePassedSinceStart(this Entity e)
	{
		return(int)(TimeService.Now - e.production.startTime).TotalSeconds;
	}

	public static int GetProductionTimeSecondsLeft(this Entity e)
	{
		return(int)(e.production.endTime - TimeService.Now).TotalSeconds;
	}
	
	public static void AddProduction(this Entity e, int time)
	{
		DateTime start = TimeService.Now;
		DateTime end = start.AddSeconds(time);
		
		e.AddProduction(start, end);
	}
	
	public static void ReplaceProduction(this Entity e, DateTime start, int time)
	{
		DateTime end = start.AddSeconds(time);
		
		e.ReplaceProduction(start, end);
	}
}