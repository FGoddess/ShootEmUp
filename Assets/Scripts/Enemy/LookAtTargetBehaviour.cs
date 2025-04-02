using Atomic.Entities;
using UnityEngine;

namespace Enemy
{
public class LookAtTargetBehaviour : IEntityInit, IEntityUpdate
{
	private Transform _target;

	public void Init(IEntity entity)
	{
		_target = entity.GetTarget();
	}

	public void OnUpdate(IEntity entity, float deltaTime)
	{
		entity.SetLookTarget(_target.position);
	}
}
}