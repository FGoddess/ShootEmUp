using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
public class BaseHealthSystem : ReactiveSystem<GameEntity>
{
	private readonly Contexts _contexts;

	public BaseHealthSystem(Contexts contexts) : base(contexts.game)
	{
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.AllOf(GameMatcher.BaseTag, GameMatcher.Health));
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isBaseTag && entity.hasHealth && entity.health.Value <= 0;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		if (entities.Count == 0)
			return;

		Debug.Log($"Game Over! База команды {entities[0].teamColor.TeamColor} уничтожена!");
		Time.timeScale = 0f;
	}
}
}