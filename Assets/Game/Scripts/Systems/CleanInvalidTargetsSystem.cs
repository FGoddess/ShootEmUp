using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
public class CleanInvalidTargetsSystem : ReactiveSystem<GameEntity>
{
	private readonly IGroup<GameEntity> _targets;

	public CleanInvalidTargetsSystem(Contexts contexts) : base(contexts.game)
	{
		var context = contexts.game;

		_targets = context.GetGroup(GameMatcher.NearestTarget);
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.UnitDiedEvent);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasUnitDiedEvent;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var request in entities)
		{
			var deadEntity = request.unitDiedEvent.Entity;

			foreach (var entity in _targets.GetEntities())
				if (entity.nearestTarget.Target == deadEntity)
				{
					if (entity.isArrowTag)
						entity.isArrowTag = false;

					entity.RemoveNearestTarget();

					if (entity.hasAttackProcess)
						entity.RemoveAttackProcess();

					if (entity.isTargetReached)
						entity.isTargetReached = false;
				}
		}
	}
}
}