using Atomic.Entities;
using UnityEngine;

namespace Player
{
public class MoveToPlayerInputBehaviour : IEntityInit, IEntityUpdate
{
	private float     _moveSpeed;
	private Transform _root;
	private Animator  _animator;

	private readonly int _state = Animator.StringToHash("State");

	public void Init(IEntity entity)
	{
		_moveSpeed = entity.GetMoveSpeed();
		_root      = entity.GetRoot();
		_animator  = entity.GetAnimator();
	}

	public void OnUpdate(IEntity entity, float deltaTime)
	{
		var input = entity.GetInputDir();
		var dir   = new Vector3(input.x, 0, input.y);

		bool hasDir = dir != Vector3.zero;

		if (!entity.GetIsShooting())
			_animator.SetFloat(_state, hasDir ? 1f : 0f);

		if (!hasDir)
			return;

		_root.position += dir * (_moveSpeed * deltaTime);
	}
}
}