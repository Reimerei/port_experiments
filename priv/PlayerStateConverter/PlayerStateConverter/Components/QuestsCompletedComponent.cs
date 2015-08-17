using System.Collections.Generic;
using Entitas;
using Entitas.CodeGenerator;

[MetaGameAttribute]
[SingleEntity]
public class QuestsCompletedComponent : IComponent
{
    public HashSet<string> ids;
}

public static class QuestsCompletedComponentExtension
{
	public static void AddQuestCompleted(this Pool pool, string id)
	{
		HashSet<string> newIds = pool.questsCompleted.ids.Copy();

		newIds.Add(id);

		pool.ReplaceQuestsCompleted(newIds);
	}

	public static bool IsQuestCompleted(this Pool pool, string id)
	{
		return pool.questsCompleted.ids.Contains(id);
	}
}