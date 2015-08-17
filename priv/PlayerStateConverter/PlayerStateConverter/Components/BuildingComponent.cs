using Entitas;

[CoreGameAttribute]
public class BuildingComponent : IComponent
{
}

public static class BuildingComponentExtension
{
	public static bool isSpecialBuilding(this Entity e)
	{
		return !e.isRefinery;
		//return e.isTownhall || e.isShipyard || e.isArsenal || e.isAcademy || e.isFortress || e.isDocks;
	}
	public static bool HasBuildingOfTypeAndLevel(this Pool pool, string type, int level)
	{
		Entity[] buildings = pool.GetGroup(Matcher.AllOf(CoreGameMatcher.Building, CoreGameMatcher.Type, CoreGameMatcher.Level)).GetEntities();
		
		foreach(Entity building in buildings){
			if(building.type.value == type && building.level.value >= level){
				return true;
			}
		}
		return false;
	}
}