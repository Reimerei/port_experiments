using Entitas;
using System.Collections.Generic;

[CoreGameAttribute]
public class BuildingStorageComponent : IComponent
{
	public Dictionary<string,int> items;
}

public static class BuildingStorageComponentExtension
{
	public static void CreateBuildingStorage(this Entity e)
	{
		e.AddBuildingStorage(new Dictionary<string,int>());
	}

	public static void AddBuildingStorageItem(this Entity e, string item, int amount = 1)
	{
		Dictionary<string,int> itemsCopy = e.buildingStorage.items.Copy();

		if(!itemsCopy.ContainsKey(item)){
			itemsCopy.Add(item, amount);
		}else{
			itemsCopy[item] += amount;
		}
		e.ReplaceBuildingStorage(itemsCopy);
	}

	public static int GetBuildingStorageItemAmount(this Entity e, string item)
	{
		if(e.buildingStorage.items.ContainsKey(item)){
			return e.buildingStorage.items[item];
		}
		return 0;
	}

	public static int GetBuildingStorageItemsAmount(this Entity e)
	{
		int count = 0;

		foreach(string item in e.buildingStorage.items.Keys)
		{
			count += e.buildingStorage.items[item];
		}
		return count;
	}
}