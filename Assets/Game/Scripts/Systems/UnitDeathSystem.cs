using System.Collections.Generic;
using Entitas;

namespace Systems
{
public class UnitDeathSystem : ReactiveSystem<GameEntity>
{
	private readonly Contexts _contexts;

	public UnitDeathSystem(Contexts contexts) : base(contexts.game)
	{
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Health);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasHealth;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var entity in entities)
		{
			if (entity.health.Value > 0)
				continue;
			
			var cleanRequest = _contexts.game.CreateEntity();
			cleanRequest.AddUnitDiedEvent(entity);
			
			entity.Destroy();
		}
	}
}
}