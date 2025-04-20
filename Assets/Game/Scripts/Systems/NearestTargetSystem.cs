using Entitas;

namespace Systems
{
public class NearestTargetSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _attackers;
	private readonly IGroup<GameEntity> _targets;

	public NearestTargetSystem(Contexts contexts)
	{
		_attackers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.TeamColor, GameMatcher.Damage));
		_targets = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position,
		                                                    GameMatcher.TeamColor,
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
			var        attackerTeam  = attacker.teamColor.TeamColor;

			foreach (var target in _targets)
			{
				if (target.teamColor.TeamColor == attackerTeam)
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