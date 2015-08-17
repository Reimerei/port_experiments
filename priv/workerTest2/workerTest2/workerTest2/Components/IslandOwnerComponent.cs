using Entitas;

[CoreGameAttribute]
public class IslandOwnerComponent : IComponent 
{
	public string value;
}

public static class IslandOwnerComponentExtension
{
	public static bool IsIslandOwnedByPlayer(this Entity e)
	{
		return e.islandOwner.value == "player";
	}

	public static bool IsIslandNeutral(this Entity e)
	{
		return e.islandOwner.value == "neutral";
	}
	
	public static bool IsIslandHostile(this Entity e)
	{
		return e.islandOwner.value == "hostile";
	}
}