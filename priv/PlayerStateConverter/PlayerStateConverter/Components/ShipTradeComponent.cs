using Entitas;
using System.Collections.Generic;

[CoreGameAttribute]
public class ShipTradeComponent : IComponent
{
	public Dictionary<string,int> soldItems, boughtItems;
	public int debit, credit;
}

public static class ShipTradeComponentExtension
{
	public static int GetShipDebitCreditOutcome(this Entity e)
	{
		return e.shipTrade.credit - e.shipTrade.debit;
	}

	public static int GetShipTradeSoldItemsAmount(this Entity e)
	{
		return e.shipTrade.soldItems.TotalCount();
	}

	public static int GetShipTradeBoughtItemsAmount(this Entity e)
	{
		return e.shipTrade.boughtItems.TotalCount();
	}

	public static bool ShipHasItemsForTrade(this Entity e)
	{
		return e.GetShipTradeBoughtItemsAmount () > 0 || e.GetShipTradeSoldItemsAmount () > 0;
	}

	public static void AddShipTradeBoughtItem(this Entity e, string resource, int amount, int debit)
	{
		Dictionary<string,int> items = e.shipTrade.boughtItems.Copy();

		if(items.ContainsKey(resource)){
			items[resource] += amount;
		}else{
			items.Add(resource, amount);
		}

		e.ReplaceShipTrade(e.shipTrade.soldItems, items, e.shipTrade.debit + debit, e.shipTrade.credit);
	}
	
	public static void RemoveShipTradeBoughtItem(this Entity e, string resource, int amount, int debit)
	{
		Dictionary<string,int> items = e.shipTrade.boughtItems.Copy();
		
		items[resource] -= amount;
		if(items[resource] == 0){
			items.Remove(resource);
		}
		
		e.ReplaceShipTrade(e.shipTrade.soldItems, items, e.shipTrade.debit - debit, e.shipTrade.credit);
	}
	
	public static void AddShipTradeSoldItem(this Entity e, string resource, int amount, int credit)
	{
		Dictionary<string,int> items = e.shipTrade.soldItems.Copy();
		
		if(items.ContainsKey(resource)){
			items[resource] += amount;
		}else{
			items.Add(resource, amount);
		}
		
		e.ReplaceShipTrade(items, e.shipTrade.boughtItems, e.shipTrade.debit, e.shipTrade.credit + credit);
	}
	
	public static void RemoveShipTradeSoldItem(this Entity e, string resource, int amount, int credit)
	{
		Dictionary<string,int> items = e.shipTrade.soldItems.Copy();
		
		items[resource] -= amount;
		if(items[resource] == 0){
			items.Remove(resource);
		}
		
		e.ReplaceShipTrade(items, e.shipTrade.boughtItems, e.shipTrade.debit, e.shipTrade.credit - credit);
	}
}