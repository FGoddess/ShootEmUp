using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
public class DamageApplySystem : ReactiveSystem<GameEntity>
{
	private readonly GameContext _context;

	public DamageApplySystem(Contexts contexts) : base(contexts.game)
	{
		_context = contexts.game;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.DamageRequest);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasDamageRequest;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var request in entities)
		{
			var attacker = request.damageRequest.Attacker;
			ApplyDamage(attacker, request.damageRequest.Target);
		}
	}

	private void ApplyDamage(GameEntity attacker, GameEntity target)
	{
		target.ReplaceHealth(target.health.Value - attacker.damage.Value);
	}
}
}