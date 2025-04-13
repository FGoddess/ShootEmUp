using Types;
using Views;

namespace Factory
{
public interface IUnitViewFactory
{
	UnitView CreateView(GameEntity entity, EUnitType unitType, ETeamColor teamColor);
}
}