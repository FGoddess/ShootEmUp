using System;
using Hero;
using Inventory.Comps;

namespace Inventory.Controllers
{
public class HeroItemEffectsController : IDisposable
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

	private void OnItemAdded(InventoryItem item)
	{
		if (item.Flags.HasFlag(InventoryItemFlags.Effectable))
			return;
		if (!item.TryGetComponent(out DamageEffectComp damageComp))
			return;

		_heroData.Damage += damageComp.Damage;
	}

	private void OnItemRemoved(InventoryItem item)
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