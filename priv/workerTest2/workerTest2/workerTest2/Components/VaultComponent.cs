using Entitas;
using Entitas.CodeGenerator;

[CoreGameAttribute]
[SingleEntity]
public class VaultComponent : IComponent 
{
}

public static class VaultComponentExtension
{
	public static int GetVaultLevel(this Pool repo)
	{
		Entity e = repo.vaultEntity;
		if(e != null && e.hasLevel){
			return e.level.value;
		}
		return 0;
	}
}