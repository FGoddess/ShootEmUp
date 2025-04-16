using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
public class AttackProcessSystem : IExecuteSystem
{
	private readonly GameContext        _context;
	private readonly IGroup<GameEntity> _attackProcessGroup;

	public AttackProcessSystem(Contexts contexts)
	{
		_context            = contexts.game;
		_attackProcessGroup = _context.GetGroup(GameMatcher.AttackProcess);
	}

	public void Execute()
	{
		foreach (var entity in _attackProcessGroup.GetEntities())
			if (Time.time >= entity.attackProcess.HitTime)
			{
				var target = entity.attackProcess.Target;

				var damageRequest = _context.CreateEntity();
				damageRequest.AddDamageRequest(entity, target);
				
				entity.RemoveAttackProcess();
			}
	}
}
}