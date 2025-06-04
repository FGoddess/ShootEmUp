using System;
using Hero;
using Items;

namespace Inventory.Comps
{
[Serializable]
public class EquipmentComp : IInventoryItemComp
{
	public EEquipSlot Slot;

	public IInventoryItemComp Clone()
	{
		return (EquipmentComp)MemberwiseClone();
	}
}
}