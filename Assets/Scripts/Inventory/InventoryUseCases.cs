using System;
using Inventory.Comps;
using UnityEngine;

namespace Inventory
{
public static class InventoryUseCases
{
	public static void AddItem(InventoryList inventoryList, InventoryItemConfig config)
	{
		if (config.Item.Flags.HasFlag(InventoryItemFlags.Stackable))
		{
			if (!config.Item.TryGetComponent(out StackableComp comp))
				throw new Exception("There's no Stackable component, but Flag is set to Stackable");

			AddStackable(inventoryList, config, comp);
			return;
		}

		AddItemAmount(inventoryList, config, 1);
	}

	public static void RemoveItem(InventoryList inventoryList, InventoryItemConfig config)
	{
		if (config.Item.Flags.HasFlag(InventoryItemFlags.Stackable))
		{
			if (!config.Item.TryGetComponent(out StackableComp comp))
				throw new Exception("There's no Stackable component, but Flag is set to Stackable");

			RemoveStackable(inventoryList, config, comp);
			return;
		}

		RemoveFirstItem(inventoryList, config);
	}

	private static void AddStackable(InventoryList inventoryList, InventoryItemConfig config, StackableComp comp)
	{
		int itemAmountLeft = comp.Amount;

		foreach (var item in inventoryList.Items)
			if (item.Id == config.Item.Id && item.Amount < comp.MaxAmount)
			{
				int amount = Math.Min(comp.MaxAmount - item.Amount, itemAmountLeft);
				itemAmountLeft -= amount;
				item.Amount    += amount;
			}

		while (itemAmountLeft > 0)
		{
			int amount = Math.Min(itemAmountLeft, comp.MaxAmount);
			itemAmountLeft -= amount;
			AddItemAmount(inventoryList, config, amount);
		}
	}

	private static void RemoveStackable(InventoryList inventoryList, InventoryItemConfig config, StackableComp comp)
	{
		int itemAmountLeft      = comp.Amount;
		var itemsToRemoveAmount = 0;

		for (var i = 0; i < inventoryList.Items.Count && itemAmountLeft > 0; i++)
		{
			var item = inventoryList.Items[i];
			if (item.Id != config.Item.Id)
				continue;

			int amount = Math.Min(item.Amount, itemAmountLeft);
			itemAmountLeft -= amount;
			item.Amount    -= amount;

			if (item.Amount == 0)
				itemsToRemoveAmount++;
		}

		for (var i = 0; i < itemsToRemoveAmount; i++)
			RemoveFirstItem(inventoryList, config);
	}

	private static void AddItemAmount(InventoryList inventoryList, InventoryItemConfig config, int amount)
	{
		var item = config.Item.Clone();
		item.Amount = amount;
		inventoryList.Items.Add(item);
		inventoryList.NotifyItemAdded(item);
	}

	private static void RemoveFirstItem(InventoryList inventoryList, InventoryItemConfig config)
	{
		for (var i = 0; i < inventoryList.Items.Count; i++)
		{
			var item = inventoryList.Items[i];
			if (item.Id != config.Item.Id)
				continue;

			inventoryList.Items.Remove(item);
			inventoryList.NotifyItemRemoved(item);
			return;
		}

		Debug.LogWarning($"Can't remove item {config.Item.Id}");
	}
}
}