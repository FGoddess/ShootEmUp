using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
public class ArmorSystem : ReactiveSystem<GameEntity>
{
	public ArmorSystem(Contexts contexts) : base(contexts.game) { }

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Armor);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasArmor;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var entity in entities)
		{
			
		}
	}
}
}