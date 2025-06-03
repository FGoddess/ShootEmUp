using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Inventory
{
public class InventoryHelper : MonoBehaviour
{
	[SerializeField]
	[Inject]
	private InventoryList _inventory;

	[Button]
	public void AddItem(InventoryItemConfig config)
	{
		_inventory.AddItem(config);
	}

	[Button]
	public void RemoveItem(InventoryItemConfig config)
	{
		_inventory.RemoveItem(config);
	}
}
}