using Items;

namespace Inventory.Interfaces
{
public interface IInventoryObserver
{
	public void OnItemAdded(InventoryItem   item);
	public void OnItemRemoved(InventoryItem item);
}
}