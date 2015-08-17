using Entitas;
using Entitas.CodeGenerator;

[CoreGameAttribute]
[SingleEntity]
public class FortressComponent : IComponent 
{
}


public static class FortressComponentExtension
{
	public static int GetFortressLevel(this Pool repo)
	{
		Entity e = repo.fortressEntity;
		if(e != null && e.hasLevel){
			return e.level.value;
		}
		return 0;
	}
}
