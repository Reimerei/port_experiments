using Entitas;
using System.Collections.Generic;
using Entitas.CodeGenerator;

[MetaGameAttribute]
[SingleEntity]
public class LeftOverResourcesComponent : IComponent
{
	public Dictionary<string, int> resources;
}