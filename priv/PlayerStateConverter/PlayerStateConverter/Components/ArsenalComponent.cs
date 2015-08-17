using Entitas;
using Entitas.CodeGenerator;

[CoreGameAttribute]
[SingleEntity]
public class ArsenalComponent : IComponent 
{
}

public static class ArsenalComponentExtension
{
	public static int GetArsenalLevel(this Pool pool)
	{
		Entity e = pool.arsenalEntity;
		if(e != null && e.hasLevel){
			return e.level.value;
		}
		return 0;
	}
}