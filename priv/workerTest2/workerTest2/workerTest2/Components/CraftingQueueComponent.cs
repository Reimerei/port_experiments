using Entitas;
using Nito;

[CoreGameAttribute]
public class CraftingQueueComponent : IComponent
{
	public Deque<Tuple<string,int>> deque;
}

public static class CraftingQueueComponentExtension
{
	public static void CreateCraftingQueue(this Entity e)
	{
		e.AddCraftingQueue(new Deque<Tuple<string,int>>());
	}

	public static int GetCraftingQueueTuples(this Entity e)
	{
		return e.craftingQueue.deque.Count;
	}

	public static bool HasCraftingQueueItems(this Entity e)
	{
		return e.GetCraftingQueueTuples() > 0;
	}

	public static int GetCraftingQueueItemsAmount(this Entity e)
	{
		int queueItems = 0;
		for(int i=e.GetCraftingQueueTuples()-1; i>=0; i--){
			queueItems += e.craftingQueue.deque[i].second;
		}
		return queueItems;
	}

	public static string DequeCraftingQueueFirstItem(this Entity e)
	{
		Deque<Tuple<string,int>> newDeque = e.craftingQueue.deque.Copy();
		
		Tuple<string,int> firstItem = newDeque[0];
		if(firstItem.second - 1 == 0){
			newDeque.RemoveFromFront();
		}else{
			newDeque[0] = new Tuple<string, int>(firstItem.first, firstItem.second - 1);
		}

		e.ReplaceCraftingQueue(newDeque);

		return firstItem.first;
	}

	public static Tuple<string,int> PeekCraftingQueueFirstItem(this Entity e)
	{
		return e.GetCraftingQueueItem(0);
	}
	
	public static Tuple<string,int> PeekCraftingQueueLastItem(this Entity e)
	{
		return e.GetCraftingQueueItem(e.GetCraftingQueueTuples() - 1);
	}

	public static Tuple<string,int> GetCraftingQueueItem(this Entity e, int order)
	{
		return e.craftingQueue.deque[order];
	}

	public static void AddCraftingQueueItem(this Entity e, string item, int amount = 1)
	{
		Deque<Tuple<string,int>> newDeque = e.craftingQueue.deque.Copy();

		if(newDeque.Count > 0){
			Tuple<string,int> lastTuple = newDeque[newDeque.Count - 1];

			if(lastTuple.first == item){
				newDeque[newDeque.Count - 1] = new Tuple<string, int>(item, lastTuple.second + amount);
			}else{
				newDeque.AddToBack(new Tuple<string, int>(item, amount));
			}
		}else{
			newDeque.AddToBack(new Tuple<string, int>(item, amount));
		}
		e.ReplaceCraftingQueue(newDeque);
	}

	public static string RemoveCraftingQueueItem(this Entity e, int index, int amount = 1)
	{
		Deque<Tuple<string,int>> newDeque = e.craftingQueue.deque.Copy();

		Tuple<string,int> tuple = newDeque[index];
		if(tuple.second - amount == 0){
			newDeque.RemoveAt(index);
		}else{
			newDeque[index] = new Tuple<string, int>(tuple.first, tuple.second - amount);
		}

		e.ReplaceCraftingQueue(newDeque);

		return tuple.first;
	}
}