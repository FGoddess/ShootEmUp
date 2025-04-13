using Entitas;
using Entitas.CodeGeneration.Attributes;
using Types;

namespace Components
{
[Game] [Event(EventTarget.Self)]
public class CreateUnitRequest : IComponent
{
	public ETeamColor TeamColor;
	public EUnitType  UnitType;
}
}