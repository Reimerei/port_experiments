using Entitas;
using System.Collections.Generic;

[CoreGameAttribute]
public class ShipCargoComponent : IComponent
{
	public Dictionary<string,int> items;
}

public static class ShipCargoComponentExtension
{
	public static int GetShipCargoItemsAmount(this Entity e)
	{
		return e.shipCargo.items.TotalCount();
	}

	public static void RemoveShipCargoItems(this Entity e, Dictionary<string,int> items)
	{
		Dictionary<string,int> newCargo = e.shipCargo.items.Copy();

		foreach(string item in new List<string>(items.Keys)){
			newCargo[item] -= items[item];
			if(newCargo[item] == 0){
				newCargo.Remove(item);
			}
		}
		e.ReplaceShipCargo(newCargo);
	}
	
	public static void AddShipCargoItems(this Entity e, Dictionary<string,int> items)
	{
		Dictionary<string,int> newCargo = e.shipCargo.items.Copy();
		
		foreach(string item in new List<string>(items.Keys)){
			if(newCargo.ContainsKey(item)){
				newCargo[item] += items[item];
			}else{
				newCargo.Add(item, items[item]);
			}
		}
		e.ReplaceShipCargo(newCargo);
	}
}