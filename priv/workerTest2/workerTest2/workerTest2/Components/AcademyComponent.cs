using Entitas;
using Entitas.CodeGenerator;

[CoreGameAttribute]
[SingleEntity]
public class AcademyComponent : IComponent 
{
}

public static class AcademyComponentExtension
{
	public static int GetAcademyLevel(this Pool pool)
	{
		Entity e = pool.academyEntity;
		if(e != null && e.hasLevel){
			return e.level.value;
		}
		return 0;
	}
}