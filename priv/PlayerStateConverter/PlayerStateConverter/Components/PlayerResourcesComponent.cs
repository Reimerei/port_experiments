using Entitas;
using Entitas.CodeGenerator;
using System.Collections.Generic;

[MetaGameAttribute]
[SingleEntity]
public class PlayerResourcesComponent : IComponent
{
    public Dictionary<string, int> quantities;
    public Dictionary<string, int> capacities;
}

public static class PlayerResourcesComponentExtension
{
	public static int GetPlayerResourceAmount(this Pool pool, string resource)
	{
		Dictionary<string, int> resources = pool.playerResources.quantities;

		return System.Math.Max(0, resources[resource]);
    }

    public static bool HasPlayerResourceAmount(this Pool pool, string resource, int amount)
    {
		return pool.GetPlayerResourceAmount(resource) >= amount;
    }

    public static int GetPlayerResourcesCapacityAmount(this Pool pool, string resource)
    {
		return pool.playerResources.capacities[resource];
    }

    public static void AffectPlayerResourceByAmount(this Pool pool, string resource, int amount)
    {
		if(amount == 0){
			return;
		}
        pool.SetPlayerResourceToAmount(resource, pool.GetPlayerResourceAmount(resource) + amount);
    }

    static void SetPlayerResourceToAmount(this Pool pool, string resource, int amount)
	{
        Dictionary<string, int> resources = pool.playerResources.quantities.Copy();

        int capacity = pool.GetPlayerResourcesCapacityAmount(resource);

        if (capacity == -1)
        {
			resources[resource] = System.Math.Max(0, amount);
        }
        else
        {
			resources[resource] = System.Math.Max(0, (System.Math.Min(amount, capacity)));
        }

        pool.ReplacePlayerResources(resources, pool.playerResources.capacities);
    }
		
	public static void ReplacePlayerResourceQuantities(this Pool pool, Dictionary<string,int> newQuantities)
	{
		pool.ReplacePlayerResources(newQuantities, pool.playerResources.capacities);
	}

	public static void ReplacePlayerResourceCapacities(this Pool pool, Dictionary<string,int> newCapacities)
	{
		pool.ReplacePlayerResources(pool.playerResources.quantities, newCapacities);
	}
}