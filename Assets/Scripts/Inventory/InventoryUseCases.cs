using System;
using Inventory.Comps;
using Items;
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

		AddItemAmount(inventoryList, config, config.Item.Amount);
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

			RemoveItem(inventoryList, item);
			return;
		}

		Debug.LogWarning($"Can't remove item with id: {config.Item.Id}");
	}

	private static void RemoveItem(InventoryList inventoryList, InventoryItem item)
	{
		inventoryList.Items.Remove(item);
		inventoryList.NotifyItemRemoved(item);
	}

	public static void ConsumeItem(InventoryList inventoryList, InventoryItemConfig config)
	{
		for (var i = 0; i < inventoryList.Items.Count; i++)
		{
			var item = inventoryList.Items[i];
			if (item.Id != config.Item.Id)
				continue;

			inventoryList.NotifyItemConsumed(item);
			RemoveItem(inventoryList, item);
			return;
		}

		Debug.LogWarning($"Can't consume item with id: {config.Item.Id}");
	}

	public static void EquipItem(InventoryList inventoryList, InventoryItemConfig config)
	{
		if (!ValidateEquipmentItem(config, out var comp))
			return;

		if (inventoryList.EquipmentMap.ContainsKey(comp.Slot))
		{
			Debug.LogWarning($"Can't equip item with id: {config.Item.Id}. Another item is already equipped");
			return;
		}

		for (var i = 0; i < inventoryList.Items.Count; i++)
		{
			var item = inventoryList.Items[i];
			if (item.Id != config.Item.Id)
				continue;

			inventoryList.EquipmentMap.Add(comp.Slot, item);
			inventoryList.Items.Remove(item);
			inventoryList.NotifyItemEquipped(item);
			return;
		}

		Debug.LogWarning($"Can't equip item with id: {config.Item.Id}");
	}

	public static void UnEquipItem(InventoryList inventoryList, InventoryItemConfig config)
	{
		if (!ValidateEquipmentItem(config, out var comp))
			return;

		if (!inventoryList.EquipmentMap.TryGetValue(comp.Slot, out var item))
		{
			Debug.LogWarning($"Can't unequip item with id: {config.Item.Id}. Item is not equipped");
			return;
		}

		inventoryList.Items.Add(item);
		inventoryList.EquipmentMap.Remove(comp.Slot);

		inventoryList.NotifyItemUnequipped(item);
	}

	private static bool ValidateEquipmentItem(InventoryItemConfig config, out EquipmentComp comp)
	{
		comp = null;

		if (!config.Item.Flags.HasFlag(InventoryItemFlags.Equippable))
		{
			Debug.LogWarning($"Can't process item with id: {config.Item.Id}. Isn't equippable");
			return false;
		}

		if (!config.Item.TryGetComponent(out comp))
		{
			Debug.LogWarning($"Can't process item with id: {config.Item.Id}. Don't have an equipment component");
			return false;
		}

		return true;
	}

	public static bool HasItem(InventoryList inventoryList, int itemId)
	{
		foreach (var item in inventoryList.Items)
			if (item.Id == itemId)
				return true;

		return false;
	}
}
}