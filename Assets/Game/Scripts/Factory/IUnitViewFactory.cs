using Types;
using UnityEngine;
using Views;

namespace Factory
{
public interface IUnitViewFactory
{
	void CreateView(GameEntity entity, EUnitType unitType, ETeamColor teamColor);
}
}