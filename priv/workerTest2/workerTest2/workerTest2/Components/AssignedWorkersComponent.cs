using System;
using Entitas;
using Entitas.CodeGenerator;

[MetaGameAttribute]
[SingleEntity]
public class AssignedWorkersComponent : IComponent
{
	public int count;
}

