using System.Collections.Generic;
using Entitas;
using Types;
using UnityEngine;

namespace Systems
{
public class AttackSystem : ReactiveSystem<GameEntity>
{
	private readonly GameContext _context;

	private const float HIT_DELAY = 0.5f;

	public AttackSystem(Contexts contexts) : base(contexts.game)
	{
		_context = contexts.game;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TargetReached, GameMatcher.NearestTarget));
	}

	protected override bool Filter(GameEntity entity)
	{
		if (!entity.hasAttackCooldown)
			return true;

		var cooldown = entity.attackCooldown;
		return Time.time > cooldown.LastAttackTime + cooldown.CooldownDuration;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var entity in entities)
		{
			var target = entity.nearestTarget.Target;

			if (entity.hasUnitType)
			{
				if (entity.unitType.Type is EUnitType.Archer)
					_context.CreateEntity().AddArrowCreateRequest(entity, target);

				entity.AddAttackProcess(Time.time, Time.time + HIT_DELAY);
				entity.ReplaceAttackCooldown(entity.attackCooldown.CooldownDuration, Time.time);
				continue;
			}

			entity.AddAttackProcess(0f, Time.time);
		}
	}
}
}