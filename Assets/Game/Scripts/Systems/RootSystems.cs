using Factory;

namespace Systems
{
public sealed class RootSystems : Feature
{
	public RootSystems(Contexts contexts, IUnitViewFactory unitViewFactory)
	{
		Add(new CreateUnitSystem(contexts, unitViewFactory));
		Add(new HealthSystem(contexts));
		Add(new ArmorSystem(contexts));
		Add(new PositionSystem(contexts));
		Add(new GameEventSystems(contexts));
		Add(new InputSystem(contexts));
	}
}
}