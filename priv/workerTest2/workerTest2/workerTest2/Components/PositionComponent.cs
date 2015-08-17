using Entitas;

[CoreGameAttribute]
public class PositionComponent : IComponent 
{	
	public int x, y;
}

public static class PositionComponentExtension
{
	public static IntVector2 getIntVector2(this PositionComponent position)
	{
		return new IntVector2(position.x, position.y);
	}

//	public static Vector2 getVector2(this PositionComponent position)
//	{
//		return new Vector2(position.x, position.y);
//	}
}