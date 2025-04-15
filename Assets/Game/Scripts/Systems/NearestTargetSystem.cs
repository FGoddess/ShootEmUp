using Entitas;

namespace Systems
{
public class NearestTargetSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _attackers;
	private readonly IGroup<GameEntity> _targets;

	public NearestTargetSystem(Contexts contexts)
	{
		_attackers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.TeamTag, GameMatcher.Damage));
		_targets = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position,
		                                                    GameMatcher.TeamTag,
		                                                    GameMatcher.Health,
		                                                    GameMatcher.SizeRadius));
	}

	public void Execute()
	{
		foreach (var attacker in _attackers)
		{
			GameEntity closestTarget = null;
			var        minDistSqr    = float.MaxValue;
			var        attackerPos   = attacker.position.Value;
			var        attackerTeam  = attacker.teamTag.TeamColor;

			foreach (var target in _targets)
			{
				if (target.teamTag.TeamColor == attackerTeam)
					continue;

				float distSqr = (target.position.Value - attackerPos).sqrMagnitude;
				if (distSqr < minDistSqr)
				{
					minDistSqr    = distSqr;
					closestTarget = target;
				}
			}

			if (closestTarget != null)
				attacker.ReplaceNearestTarget(closestTarget);
			else if (attacker.hasNearestTarget)
				attacker.RemoveNearestTarget();
		}
	}
}
}