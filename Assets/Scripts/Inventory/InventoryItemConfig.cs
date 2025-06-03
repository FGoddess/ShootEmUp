using UnityEngine;

namespace Inventory
{
[CreateAssetMenu(menuName = "InventoryItemConfig", fileName = "InventoryItemConfig")]
public class InventoryItemConfig : ScriptableObject
{
	public InventoryItem Item;
}
}