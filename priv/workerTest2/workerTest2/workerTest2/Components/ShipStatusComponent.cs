using Entitas;

[CoreGameAttribute]
public class ShipStatusComponent : IComponent
{
	public float value;
}

public static class ShipStatusComponentExtension
{
	public static void AddShipStatusDamage(this Entity e, float statusDamage)
	{
		e.ReplaceShipStatus(System.Math.Max(0, e.shipStatus.value - statusDamage));
	}
		
	public static bool IsShipRepairable(this Entity e)
	{
		return e.shipStatus.value < 1;
	}
	
	public static bool IsShipFitForAction(this Entity e)
	{
		return e.shipStatus.value > 0;
	}
}