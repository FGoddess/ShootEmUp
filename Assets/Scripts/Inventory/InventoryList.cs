using System;
using System.Collections.Generic;

namespace Inventory
{
[Serializable]
public class InventoryList
{
	public List<InventoryItem> Items;

	public event Action<InventoryItem> OnItemAdded;
	public event Action<InventoryItem> OnItemRemoved;

	public void AddItem(InventoryItemConfig    config) => InventoryUseCases.AddItem(this, config);
	public void RemoveItem(InventoryItemConfig config) => InventoryUseCases.RemoveItem(this, config);
	
	public void NotifyItemAdded(InventoryItem   item) => OnItemAdded?.Invoke(item);
	public void NotifyItemRemoved(InventoryItem item) => OnItemRemoved?.Invoke(item);
}
}