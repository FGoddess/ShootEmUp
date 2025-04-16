using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
public class DamageSystem : ReactiveSystem<GameEntity>
{
	private readonly GameContext _context;

	public DamageSystem(Contexts contexts) : base(contexts.game)
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
			var target = request.damageRequest.Target;
  
			// Наносим урон
			ApplyDamage(attacker, target);
			
			// Удаление происходит автоматически через CleanupSystem
			// благодаря атрибуту [Cleanup(CleanupMode.RemoveComponent)]
		}
	}
	
	private void ApplyDamage(GameEntity attacker, GameEntity target)
	{
		// Проверяем, существует ли ещё цель
		if (target != null && target.hasHealth && attacker.hasDamage)
		{
			// Наносим урон цели
			target.ReplaceHealth(target.health.Value - attacker.damage.Value);
		}
	}
}
}