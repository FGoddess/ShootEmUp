using System.Collections.Generic;
using Entitas;
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
		return context.CreateCollector(GameMatcher.AttackRequest);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasAttackRequest;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var request in entities)
		{
			var attacker = request.attackRequest.Attacker;
			var target   = request.attackRequest.Target;

			if (Time.time > attacker.attackCooldown.LastAttackTime + attacker.attackCooldown.CooldownDuration)
			{
				attacker.AddAttackProcess(target, Time.time, Time.time + HIT_DELAY);
				attacker.ReplaceAttackCooldown(attacker.attackCooldown.CooldownDuration, Time.time);
			}
		}
	}
}
}