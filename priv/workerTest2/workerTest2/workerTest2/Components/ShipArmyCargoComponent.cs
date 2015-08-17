using Entitas;
using System.Collections.Generic;

[CoreGameAttribute]
public class ShipArmyCargoComponent : IComponent
{
	public Dictionary<string,int> troops;
}

public static class ShipArmyCargoComponentExtension
{
	public static void ClearShipArmyCargo(this Entity e)
	{
		e.ReplaceShipArmyCargo(new Dictionary<string, int>());
	}

	public static int GetShipArmyCargoTroopsAmount(this Entity e)
	{
		return e.shipArmyCargo.troops.TotalCount();
	}

	public static int GetShipArmyCargoTroopAmount(this Entity e, string troop)
	{
		if(e.shipArmyCargo.troops.ContainsKey(troop)){
			return e.shipArmyCargo.troops[troop];
		}
		return 0;
	}

	public static void RemoveShipArmyCargoTroop(this Entity e, string troop, int amount = 1)
	{
		Dictionary<string,int> newCargo = e.shipArmyCargo.troops.Copy();
		
		newCargo[troop] -= amount;
		if(newCargo[troop] == 0){
			newCargo.Remove(troop);
		}
		e.ReplaceShipArmyCargo(newCargo);
	}

	public static void RemoveShipArmyCargoTroops(this Entity e, Dictionary<string,int> troops)
	{
		Dictionary<string,int> newCargo = e.shipArmyCargo.troops.Copy();

		foreach(string troop in new List<string>(troops.Keys)){
			newCargo[troop] -= troops[troop];
			if(newCargo[troop] == 0){
				newCargo.Remove(troop);
			}
		}
		e.ReplaceShipArmyCargo(newCargo);
	}
	
	public static void AddShipArmyCargoTroop(this Entity e, string troop, int amount = 1)
	{
		Dictionary<string,int> newCargo = e.shipArmyCargo.troops.Copy();

		if(newCargo.ContainsKey(troop)){
			newCargo[troop] += amount;
		}else{
			newCargo.Add(troop, amount);
		}
		e.ReplaceShipArmyCargo(newCargo);
	}
	
	public static void AddShipArmyCargoTroops(this Entity e, Dictionary<string,int> troops)
	{
		Dictionary<string,int> newCargo = e.shipArmyCargo.troops.Copy();
		
		foreach(string troop in new List<string>(troops.Keys)){
			if(newCargo.ContainsKey(troop)){
				newCargo[troop] += troops[troop];
			}else{
				newCargo.Add(troop, troops[troop]);
			}
		}
		e.ReplaceShipArmyCargo(newCargo);
	}
}