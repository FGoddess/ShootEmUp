using Factory;

namespace Systems
{
public sealed class RootSystems : Feature
{
	public RootSystems(Contexts contexts, IUnitViewFactory unitFactory, IBaseViewFactory baseFactory)
	{
		Add(new CreateBaseSystem(contexts, baseFactory));
		Add(new CreateUnitSystem(contexts, unitFactory));
		
		Add(new HealthSystem(contexts));
		Add(new MoveSystem(contexts));
		Add(new GameEventSystems(contexts));
		Add(new InputSystem(contexts));
		Add(new NearestTargetSystem(contexts));
	}
}
}