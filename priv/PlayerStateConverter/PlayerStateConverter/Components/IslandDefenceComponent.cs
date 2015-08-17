using Entitas;
using System.Collections.Generic;

public struct IslandDefence
{
	public string type;
	public int level;
	public int hp;

	public IslandDefence(string type, int level, int hp)
	{
		this.type = type;
		this.level = level;
		this.hp = hp;
	}

	public override string ToString()
	{
		return "{\"type\":\"" + type + "\",\"level\":" + level + ",\"hp\":" + hp + "}";
	}
}

[CoreGameAttribute]
public class IslandDefenceComponent : IComponent 
{
	public List<IslandDefence> defences;
}

public static class IslandDefenceComponentExtension
{
	public static void AddIslandDefence(this Entity e, string type, int level, int hp)
	{
		IslandDefence defence = new IslandDefence(type, level, hp);

		List<IslandDefence> defencesCopy = e.islandDefence.defences.Copy();

		defencesCopy.Add(defence);

		e.ReplaceIslandDefence(defencesCopy);
	}

	public static void RemoveIslandDefence(this Entity e, IslandDefence defence)
	{
		List<IslandDefence> defencesCopy = e.islandDefence.defences.Copy();
		
		defencesCopy.Remove(defence);
		
		e.ReplaceIslandDefence(defencesCopy);
	}
}