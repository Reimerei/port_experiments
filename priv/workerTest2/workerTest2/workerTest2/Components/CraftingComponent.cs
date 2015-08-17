using Entitas;
using System;

[CoreGameAttribute]
public class CraftingComponent : IComponent
{
	public string item;
	public DateTime startTime;
}

public static class CraftingComponentExtension
{
	public static int GetCraftingTimePassedSinceStart(this Entity e)
	{
		return(int)(TimeService.Now - e.crafting.startTime).TotalSeconds;
	}
}