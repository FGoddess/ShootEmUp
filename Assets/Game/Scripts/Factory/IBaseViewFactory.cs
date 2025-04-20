using Types;
using UnityEngine;
using Views;

namespace Factory
{
public interface IBaseViewFactory
{
	void CreateView(GameEntity entity, ETeamColor teamColor);
}
}