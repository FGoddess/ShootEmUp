using System;

namespace Inventory.Comps
{
[Serializable]
public class DamageEffectComp : IInventoryItemComp
{
	public int Damage;

	public IInventoryItemComp Clone()
	{
		return (DamageEffectComp)MemberwiseClone();
	}
}
}