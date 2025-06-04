using UnityEngine;

namespace Items
{
[CreateAssetMenu(menuName = "InventoryItemConfig", fileName = "InventoryItemConfig")]
public class InventoryItemConfig : ScriptableObject
{
	public InventoryItem Item;
}
}