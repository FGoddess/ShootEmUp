using System;
using Hero;
using Inventory.Comps;
using Inventory.Interfaces;
using Items;

namespace Inventory.Controllers
{
public class HeroItemEffectsController : IInventoryObserver, IDisposable
{
	private readonly InventoryList _inventory;
	private readonly HeroData      _heroData;

	public HeroItemEffectsController(InventoryList inventory, HeroData heroData)
	{
		_inventory = inventory;
		_heroData  = heroData;

		_inventory.OnItemAdded   += OnItemAdded;
		_inventory.OnItemRemoved += OnItemRemoved;
	}

	public void OnItemAdded(InventoryItem item)
	{
		if (item.Flags.HasFlag(InventoryItemFlags.Effectable))
			return;
		if (!item.TryGetComponent(out DamageEffectComp damageComp))
			return;

		_heroData.Damage += damageComp.Damage;
	}

	public void OnItemRemoved(InventoryItem item)
	{
		if (item.Flags.HasFlag(InventoryItemFlags.Effectable))
			return;
		if (!item.TryGetComponent(out DamageEffectComp damageComp))
			return;

		_heroData.Damage -= damageComp.Damage;
	}

	public void Dispose()
	{
		_inventory.OnItemAdded   -= OnItemAdded;
		_inventory.OnItemRemoved -= OnItemRemoved;
	}
}
}