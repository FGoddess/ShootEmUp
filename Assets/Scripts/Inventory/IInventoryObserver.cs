namespace Inventory
{
public interface IInventoryObserver
{
	public void OnItemAdded(InventoryItem   item);
	public void OnItemRemoved(InventoryItem item);
}
}