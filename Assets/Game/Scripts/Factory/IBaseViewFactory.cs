using Types;
using Views;

namespace Factory
{
public interface IBaseViewFactory
{
	BaseView CreateView(GameEntity entity, ETeamColor teamColor);
}
}