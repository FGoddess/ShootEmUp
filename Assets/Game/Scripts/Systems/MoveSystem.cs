using Components;
using Entitas;
using UnityEngine;

namespace Systems
{
public class MoveSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _positionEntities;

	public MoveSystem(Contexts contexts)
	{
		_positionEntities =
			contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position,
			                                         GameMatcher.Move,
			                                         GameMatcher.CanAttack,
			                                         GameMatcher.Health,
			                                         GameMatcher.NearestTarget,
			                                         GameMatcher.AttackRange));
	}


	public void Execute()
	{
		foreach (var entity in _positionEntities)
		{
			var   target         = entity.nearestTarget.Target;
			var   dir            = target.position.Value - entity.position.Value;
			float distanceToEdge = dir.magnitude - target.sizeRadius.Radius;

			if (distanceToEdge > entity.attackRange.Value)
				entity.ReplacePosition(entity.position.Value + dir.normalized * Time.deltaTime * entity.move.Speed);
		}
	}
}
}