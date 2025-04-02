using Atomic.Entities;
using UnityEngine;

namespace Enemy
{
public class MoveToTargetBehaviour : IEntityInit, IEntityUpdate
{
	private readonly int _state = Animator.StringToHash("State");

	private float     _speed;
	private Transform _root;
	private Animator  _animator;
	private Transform _target;

	public void Init(IEntity entity)
	{
		_speed    = entity.GetMoveSpeed();
		_root     = entity.GetRoot();
		_target   = entity.GetTarget();
		_animator = entity.GetAnimator();

		_animator.SetFloat(_state, 1f);
	}

	public void OnUpdate(IEntity entity, float deltaTime)
	{
		var position = _root.position;
		var dir      = (_target.position - position).normalized;
		
		position       += dir * (_speed * deltaTime);
		_root.position =  position;
	}
}
}