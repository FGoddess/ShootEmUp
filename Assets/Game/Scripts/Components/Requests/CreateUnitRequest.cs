using Entitas;
using Types;

namespace Components.Requests
{
[Game]
public class CreateUnitRequest : IComponent
{
	public ETeamColor TeamColor;
	public EUnitType  UnitType;
}
}