using System;
using System.Collections.Generic;
using Entitas;
using Factory;
using UnityEngine;

namespace Systems
{
public class CreateUnitSystem : ReactiveSystem<GameEntity>
{
	private readonly Contexts _contexts;

	private readonly IUnitViewFactory _factory;

	public CreateUnitSystem(Contexts contexts, IUnitViewFactory factory) : base(contexts.game)
	{
		_contexts = contexts;
		_factory  = factory;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.CreateUnitRequest);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasCreateUnitRequest;
	}

	protected override void Execute(List<GameEntity> requests)
	{
		foreach (var req in requests)
		{
			var unitType = req.createUnitRequest.UnitType;
			var team     = req.createUnitRequest.TeamColor;

			var unit = Contexts.sharedInstance.game.CreateEntity();
			unit.AddHealth(10);
			unit.AddArmor(5);
			unit.AddPosition(Vector3.zero);
			
			_factory.CreateView(unit, unitType, team);
			
			req.Destroy();
		}
	}
}
}