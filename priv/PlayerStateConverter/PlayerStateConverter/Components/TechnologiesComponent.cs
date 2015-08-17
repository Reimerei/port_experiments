using Entitas;
using Entitas.CodeGenerator;
using System.Collections.Generic;

[MetaGameAttribute]
[SingleEntity]
public class TechnologiesComponent : IComponent
{	
	public HashSet<string> values;
}

public static class TechnologiesComponentComponentExtension
{
	public static bool HasTechnology(this Pool pool, string type)
	{
		return pool.hasTechnologies && pool.technologies.values.Contains(type);
	}

	public static void AddTechnology(this Pool pool, string type)
	{
		HashSet<string> technologies = pool.technologies.values;
		technologies.Add(type);
		pool.ReplaceTechnologies(technologies);
	}
}