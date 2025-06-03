using System;
using UnityEngine;

namespace Inventory
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