using Entitas;
using Entitas.CodeGenerator;

[CoreGameAttribute]
[SingleEntity]
public class ShipyardComponent : IComponent 
{
}

public static class ShipyardComponentExtension
{
	public static int GetShipyardLevel(this Pool repo)
	{
		Entity e = repo.shipyardEntity;
		if(e != null && e.hasLevel){
			return e.level.value;
		}
		return 0;
	}
}