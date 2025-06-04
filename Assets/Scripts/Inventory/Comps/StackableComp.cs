using Items;

namespace Inventory.Comps
{
public class StackableComp : IInventoryItemComp
{
	public int Amount;
	public int MaxAmount;
	
	public IInventoryItemComp Clone()
	{
		return (IInventoryItemComp)MemberwiseClone();
	}
}
}