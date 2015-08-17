using Entitas;

[MetaGameAttribute]
public class QuestComponent : IComponent
{
    public string id;
}

public static class QuestComponentExtension
{
	public static Entity GetQuestWithId(this Pool pool, string id)
	{
		Entity[] entities = pool.GetGroup(MetaGameMatcher.Quest).GetEntities();
		
		foreach(Entity e in entities){
			if(e.quest.id == id){
				return e;
			}
		}
		return null;
	}
}