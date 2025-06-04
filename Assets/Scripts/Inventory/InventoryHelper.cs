using Hero;
using Items;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Inventory
{
public class InventoryHelper : MonoBehaviour
{
	[SerializeField]
	private InventoryList _inventory;
	[SerializeField]
	private HeroData _heroData;


	[Inject]
	public void Construct(InventoryList inventory, HeroData heroData)
	{
		_inventory = inventory;
		_heroData  = heroData;
	}

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

	[Button]
	public void ConsumeItem(InventoryItemConfig config)
	{
		_inventory.ConsumeItem(config);
	}

	[Button]
	public void EquipItem(InventoryItemConfig config)
	{
		_inventory.EquipItem(config);
	}

	[Button]
	public void UnEquipItem(InventoryItemConfig config)
	{
		_inventory.UnEquipItem(config);
	}
}
}