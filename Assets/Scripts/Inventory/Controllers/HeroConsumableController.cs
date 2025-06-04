using System;
using Hero;
using Inventory.Comps;
using Inventory.Interfaces;
using Items;

namespace Inventory.Controllers
{
public class HeroConsumableController : IInventoryConsumer, IDisposable
{
	private readonly InventoryList _inventory;
	private readonly HeroData      _heroData;

		
	public HeroConsumableController(InventoryList inventory, HeroData heroData)
	{
		_inventory = inventory;
		_heroData  = heroData;

		_inventory.OnItemConsumed += OnItemConsumed;
	}

	public void OnItemConsumed(InventoryItem item)
	{
		if (!item.TryGetComponent(out ConsumableComp consumableComp))
			return;

		switch (consumableComp.Stat)
		{
			case EHeroStats.Damage:
				_heroData.Damage += consumableComp.Value;
				break;
			case EHeroStats.Health:
				_heroData.Health += consumableComp.Value;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	public void Dispose()
	{
		_inventory.OnItemConsumed -= OnItemConsumed;
	}
}
}