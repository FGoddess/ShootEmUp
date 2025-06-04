using System;
using Inventory;
using Inventory.Interfaces;
using UnityEngine;

namespace Items
{
[Serializable]
public class InventoryItemMetadata : ICloneable<InventoryItemMetadata>
{
	public string Title;
	public string Description;
	public Sprite Icon;

	public InventoryItemMetadata Clone()
	{
		return (InventoryItemMetadata)MemberwiseClone();
	}
}
}