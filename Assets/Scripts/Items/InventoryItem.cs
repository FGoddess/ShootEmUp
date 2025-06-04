using System;
using Inventory;
using Inventory.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Items
{
[Serializable]
public class InventoryItem : ICloneable<InventoryItem>
{
	public int                   Id;
	public InventoryItemFlags    Flags;
	public InventoryItemMetadata Metadata;

	[SerializeReference]
	public IInventoryItemComp[] Components;

	[ReadOnly]
	public int Amount = 1;

	public InventoryItem Clone()
	{
		var clone = new InventoryItem
		{
			Id         = Id,
			Metadata   = Metadata.Clone(),
			Flags      = Flags,
			Amount     = Amount,
			Components = new IInventoryItemComp[Components.Length]
		};

		for (var i = 0; i < Components.Length; i++)
			clone.Components[i] = Components[i].Clone();

		return clone;
	}

	public bool TryGetComponent<T>(out T component) where T : class, IInventoryItemComp
	{
		foreach (var comp in Components)
			if (comp is T targetComp)
			{
				component = targetComp;
				return true;
			}

		component = null;
		return false;
	}
}
}