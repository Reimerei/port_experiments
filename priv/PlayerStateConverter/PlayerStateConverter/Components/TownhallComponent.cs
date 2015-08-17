using Entitas;
using Entitas.CodeGenerator;

[CoreGameAttribute]
[SingleEntity]
public class TownhallComponent : IComponent 
{
}

public static class TownhallComponentExtension
{
	public static int GetTownhallLevel(this Pool repo)
	{
		Entity e = repo.townhallEntity;
		if(e != null && e.hasLevel){
			return e.level.value;
		}
		return 0;
	}
}