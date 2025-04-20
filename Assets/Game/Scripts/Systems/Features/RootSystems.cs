namespace Systems.Features
{
public sealed class RootSystems : Feature
{
	public RootSystems(Contexts contexts)
	{
		Add(new InputSystem(contexts));
		Add(new NearestTargetSystem(contexts));
		Add(new MoveSystem(contexts));
		Add(new AttackSystem(contexts));
		Add(new AttackProcessSystem(contexts));
		Add(new DamageApplySystem(contexts));
		Add(new RotateTowardsTargetSystem(contexts));
		Add(new GameEventSystems(contexts));
		Add(new BaseHealthSystem(contexts));
		Add(new UnitDeathSystem(contexts));
		Add(new CleanInvalidTargetsSystem(contexts));

		Add(new CleanupSystem(contexts));
	}
}
}