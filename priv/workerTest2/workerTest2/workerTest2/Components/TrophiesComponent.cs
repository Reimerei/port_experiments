using Entitas;
using Entitas.CodeGenerator;

[MetaGameAttribute]
[SingleEntity]
public class TrophiesComponent : IComponent 
{
	public int value;
}

public static class TrophiesComponentExtension
{
	public static int GetTrophies(this Pool pool)
	{
		return pool.trophies.value;
	}
	
	public static void AddTrophies(this Pool pool, int amount)
	{
		int current = pool.GetTrophies();
	
		int newAmount = System.Math.Max(0, current + amount);

		pool.ReplaceTrophies(newAmount);
	}
}