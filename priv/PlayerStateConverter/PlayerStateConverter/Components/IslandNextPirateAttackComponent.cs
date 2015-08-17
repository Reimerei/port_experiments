using Entitas;
using Entitas.CodeGenerator;
using System;

[MetaGameAttribute]
[SingleEntity]
public class IslandNextPirateAttackComponent : IComponent 
{
	public DateTime time;
}