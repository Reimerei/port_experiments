using Entitas;

[CoreGameAttribute]
public class OrderComponent : IComponent
{
	public int value;
}

public static class OrderComponentExtension
{
	public static Entity GetEntityWithOrder(this Pool pool, int order, IMatcher matcher)
	{
		Entity[] entities = pool.GetGroup(Matcher.AllOf(CoreGameMatcher.Order, matcher)).GetEntities();
		
		foreach(Entity e in entities){
			if(e.order.value == order){
				return e;
			}
		}
		return null;
	}

	public static Entity GetShipWithOrder(this Pool repo, int order)
	{
		return repo.GetEntityWithOrder(order, CoreGameMatcher.Ship);
	}

	public static Entity GetMerchantShipWithOrder(this Pool repo, int order)
	{
		return repo.GetEntityWithOrder(order, CoreGameMatcher.MerchantShip);
	}

	public static Entity GetDefenceWithOrder(this Pool repo, int order)
	{
		return repo.GetEntityWithOrder(order, CoreGameMatcher.Defence);
	}
}