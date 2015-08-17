using Entitas;
using Entitas.CodeGenerator;

[MetaGameAttribute]
[SingleEntity]
public class LastPvpAttackTimeComponent : IComponent
{
	public long time;
}