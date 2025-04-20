using Entitas;
using UnityEngine;

namespace Systems
{
public class RotateTowardsTargetSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public RotateTowardsTargetSystem(Contexts contexts)
	{
		_entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Facing, GameMatcher.NearestTarget));
	}

	public void Execute()
	{
		foreach (var entity in _entities)
		{
			var unitPosition   = entity.position.Value;
			var targetPosition = entity.nearestTarget.Target.position.Value;

			var direction = targetPosition - unitPosition;

			if (direction.sqrMagnitude < 0.05f)
				continue;

			direction = direction.normalized;
			entity.ReplaceFacing(direction);
		}
	}
}
}