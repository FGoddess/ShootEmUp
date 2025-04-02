using Atomic.Entities;
using UnityEngine;

namespace Common
{
public class AttackTargetBehaviour : IEntityInit, IEntityUpdate
{
	private Animator  _animator;
	private Transform _target;
	private Transform _root;

	private const int Damage = 1;

	private readonly int _state = Animator.StringToHash("State");


	public void Init(IEntity entity)
	{
		_animator = entity.GetAnimator();
		_target   = entity.GetTarget();
		_root     = entity.GetRoot();
		
		var dispatcher = entity.GetAnimatorDispatcher();

		dispatcher.SubscribeOnEvent("Attack", () => _target.GetComponent<SceneEntity>().Entity.GetDamageRequest()?.Invoke(Damage));
	}

	public void OnUpdate(IEntity entity, float deltaTime)
	{
		_animator.SetFloat(_state, (_target.position - _root.position).sqrMagnitude < 1f ? 2f : 1f);
	}
}
}