using System.Collections.Generic;
using Entitas;
using Types;
using UnityEngine;

namespace Systems
{
public class AttackProcessSystem : IExecuteSystem
{
	private readonly GameContext _context;

	private readonly IGroup<GameEntity> _attackProcessGroup;

	public AttackProcessSystem(Contexts contexts)
	{
		_context            = contexts.game;
		_attackProcessGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.AttackProcess, GameMatcher.NearestTarget));
	}

	public void Execute()
	{
		foreach (var entity in _attackProcessGroup.GetEntities())
			if (Time.time >= entity.attackProcess.HitTime)
			{
				var target = entity.nearestTarget.Target;

				entity.RemoveAttackProcess();

				if (entity.hasUnitType && entity.unitType.Type is EUnitType.Archer)
					continue;

				var damageRequest = _context.CreateEntity();
				damageRequest.AddDamageRequest(entity, target);
			}
	}
}
}