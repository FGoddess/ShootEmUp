using Factory;

namespace Systems
{
public sealed class RootSystems : Feature
{
	public RootSystems(Contexts contexts, IUnitViewFactory unitFactory, IBaseViewFactory baseFactory)
	{
		Add(new InputSystem(contexts));
		
		Add(new CreateBaseSystem(contexts, baseFactory));
		Add(new CreateUnitSystem(contexts, unitFactory));
		
		Add(new HealthSystem(contexts));
		Add(new MoveSystem(contexts));
		Add(new AttackSystem(contexts));
		Add(new NearestTargetSystem(contexts));
		Add(new GameEventSystems(contexts));
		Add(new UnitDeathSystem(contexts));
		Add(new CleanInvalidTargetsSystem(contexts));
	}
}
}