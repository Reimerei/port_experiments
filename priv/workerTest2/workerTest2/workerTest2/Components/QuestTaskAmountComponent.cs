using Entitas;

[MetaGameAttribute]
public class QuestTaskAmountComponent : IComponent
{
	public int toComplete, done;
}

public static class QuestTaskAmountComponentExtension
{
	public static void AddQuestTaskAmount(this Entity e, int amountToComplete)
	{
		e.AddQuestTaskAmount(amountToComplete, 0);
	}

    public static void ReplaceQuestTaskAmountDone(this Entity e, int newAmountDone)
    {
		int amountToComplete = e.questTaskAmount.toComplete;

		newAmountDone = System.Math.Min(amountToComplete, newAmountDone);

		e.ReplaceQuestTaskAmount(amountToComplete, newAmountDone);
    }
	
	public static int GetQuestTaskAmountLeft(this Entity e)
	{
		return e.questTaskAmount.toComplete - e.questTaskAmount.done;
	}

	public static bool IsQuestTaskComplete(this Entity e)
	{
		return e.GetQuestTaskAmountLeft() == 0;
	}
}