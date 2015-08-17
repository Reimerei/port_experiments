using Entitas;
using Entitas.CodeGenerator;
using System.Collections.Generic;

[MetaGameAttribute]
[SingleEntity]
public class UnitLevelsComponent : IComponent
{	
	public Dictionary<string, int> values;
}

public static class UnitLevelsComponentExtension
{
	public static int GetUnitLevel(this Pool pool, string unitType)
	{
		if(HasUnitLevelForType(pool, unitType)){
			return pool.unitLevels.values[unitType];
		}
		return 1;
	}

	public static void SetUnitLevel(this Pool pool, string unitType, int level)
	{

		Dictionary<string,int> newLevels = pool.unitLevels.values.Copy();

		newLevels[unitType] = level;

		pool.ReplaceUnitLevels(newLevels);
	}
	
	public static void IncreaseUnitLevel(this Pool pool, string unitType)
	{
		pool.SetUnitLevel(unitType, pool.GetUnitLevel(unitType) + 1);
	}

	public static bool HasUnitLevelForType(this Pool pool, string unitType)
	{
		if(pool.hasUnitLevels){
			return pool.unitLevels.values.ContainsKey(unitType);
		}
		return false;
	}
}