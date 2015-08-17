using Entitas;
using System.Collections.Generic;

[CoreGameAttribute]
public class RefineryPropertiesComponent : IComponent
{
	public int priority;
	public int capacity;
	public int productionTime;
	public Dictionary<string, int> supplyAmounts;
	public Dictionary<string, int> productionAmounts;
}

public static class RefineryPropertiesComponentExtension
{
	public static int GetRefineryTotalProductionAmount(this Entity e)
	{
		int productionAmount = 0;
		foreach(string resourceProduced in e.refineryProperties.productionAmounts.Keys){
			productionAmount += e.refineryProperties.productionAmounts[resourceProduced];
		}
		return productionAmount;
	}
}
