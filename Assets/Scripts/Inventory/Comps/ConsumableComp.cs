using System;
using Hero;
using Items;

namespace Inventory.Comps
{
[Serializable]
public class ConsumableComp : IInventoryItemComp
{
	public EHeroStats Stat;
	public int        Value;

	public IInventoryItemComp Clone()
	{
		return (IInventoryItemComp)MemberwiseClone();
	}
}
}