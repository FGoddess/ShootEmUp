using System;
using Items;

namespace Inventory.Interfaces
{
public interface IInventoryConsumer
{
	public void OnItemConsumed(InventoryItem   item);
}
}