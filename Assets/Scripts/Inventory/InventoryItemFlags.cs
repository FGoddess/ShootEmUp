using System;

namespace Inventory
{
[Flags]
public enum InventoryItemFlags
{
	None       = 0,
	Stackable  = 1,
	Consumable = 2,
	Equippable = 4,
	Effectable = 8
}
}