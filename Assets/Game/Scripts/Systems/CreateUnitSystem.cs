using System.Collections.Generic;
using Configs;
using Entitas;
using Factory;

namespace Systems
{
public class CreateUnitSystem : ReactiveSystem<GameEntity>
{
	private readonly Contexts _contexts;

	private readonly IUnitViewFactory _factory;

	private readonly UnitsConfig _config;

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
			var unitType  = req.createUnitRequest.UnitType;
			var teamColor = req.createUnitRequest.TeamColor;
			var data      = _config.UnitsDataMap[(unitType, teamColor)];

			var unit = Contexts.sharedInstance.game.CreateEntity();
			unit.AddHealth(data.Health);
			unit.AddAttackRange(data.AttackRange);
			unit.AddTeamTag(teamColor);
			unit.AddSizeRadius(data.SizeRadius);
			unit.AddMove(data.MoveSpeed);
			unit.AddAttackCooldown(data.AttackCooldown, 0f);
			unit.isCanAttack = true;

			var view = _factory.CreateView(unit, unitType, teamColor);

			unit.AddPosition(view.transform.position);

			req.Destroy();
		}
	}
}
}