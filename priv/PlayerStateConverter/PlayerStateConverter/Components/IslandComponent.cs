using Entitas;

[CoreGameAttribute]
public class IslandComponent : IComponent {
}

public static class IslandComponentExtension
{
	public static bool IsIslandCity(this Entity e)
	{
		return e.type.value == "city";
	}
}