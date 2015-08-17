using System;
using Entitas;
using Entitas.CodeGenerator;

[MetaGameAttribute]
[SingleEntity]
public class WorkersProductionComponent : IComponent
{
	public DateTime startTime;
}

public static class WorkersProductionComponentExtension
{
	public static int GetWorkersProductionTimePassedSinceStart(this Entity e)
	{
		return (int)(TimeService.Now - e.workersProduction.startTime).TotalSeconds;
	}
}