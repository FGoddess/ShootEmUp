using System;
using System.Collections.Generic;
using Components.Requests;
using Entitas;
using Factory;
using UnityEngine;

namespace Systems
{
public class CreateArrowSystem : ReactiveSystem<GameEntity>
{
	private readonly Contexts      _contexts;
	private readonly IArrowFactory _arrowFactory;

	public CreateArrowSystem(Contexts contexts, IArrowFactory arrowFactory) : base(contexts.game)
	{
		_contexts     = contexts;
		_arrowFactory = arrowFactory;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.ArrowCreateRequest);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasArrowCreateRequest;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var request in entities)
		{
			var attacker = request.arrowCreateRequest.Attacker;
			var target   = request.arrowCreateRequest.Target;

			_arrowFactory.CreateArrow(attacker, target);

			request.Destroy();
		}
	}
}
}