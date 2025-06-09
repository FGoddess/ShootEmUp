using System;
using System.Collections.Generic;
using Hero;
using Items;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Inventory
{
[Serializable]
public class InventoryList
{
	public List<InventoryItem> Items;

	[ShowInInspector]
	public Dictionary<EEquipSlot, InventoryItem> EquipmentMap = new();

	public event Action<InventoryItem> OnItemAdded;
	public event Action<InventoryItem> OnItemRemoved;

	public event Action<InventoryItem> OnItemConsumed;

	public event Action<InventoryItem> OnItemEquipped;
	public event Action<InventoryItem> OnItemUnequipped;

	public void AddItem(InventoryItemConfig     config) => InventoryUseCases.AddItem(this, config);
	public void RemoveItem(InventoryItemConfig  config) => InventoryUseCases.RemoveItem(this, config);
	public void ConsumeItem(InventoryItemConfig config) => InventoryUseCases.ConsumeItem(this, config);
	public void EquipItem(InventoryItemConfig   config) => InventoryUseCases.EquipItem(this, config);
	public void UnEquipItem(InventoryItemConfig config) => InventoryUseCases.UnEquipItem(this, config);
	public bool HasItem(int                     itemId) => InventoryUseCases.HasItem(this, itemId);

	public void NotifyItemAdded(InventoryItem      item) => OnItemAdded?.Invoke(item);
	public void NotifyItemRemoved(InventoryItem    item) => OnItemRemoved?.Invoke(item);
	public void NotifyItemConsumed(InventoryItem   item) => OnItemConsumed?.Invoke(item);
	public void NotifyItemEquipped(InventoryItem   item) => OnItemEquipped?.Invoke(item);
	public void NotifyItemUnequipped(InventoryItem item) => OnItemUnequipped?.Invoke(item);
}
}