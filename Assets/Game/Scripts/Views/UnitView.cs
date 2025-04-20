using Core;
using UnityEngine;
using Entitas.Unity;

namespace Views
{
public class UnitView : UnityView, IHealthListener, IPositionListener, IAttackProcessListener, IFacingListener
{
	[SerializeField]
	private Animator _animator;
	[SerializeField]
	private ParticleSystem _damageTakeParticle;

	private int _previousHealth;

	private readonly int _attackTrigger = Animator.StringToHash("Attack");
	private readonly int _runTrigger    = Animator.StringToHash("Run");
	private readonly int _runStateHash  = Animator.StringToHash("Base Layer.Run");

	
	public override void Link(Contexts contexts, GameEntity entity)
	{
		base.Link(contexts, entity);
		entity.AddPositionListener(this);
		entity.AddAttackProcessListener(this);
		entity.AddFacingListener(this);
		entity.AddHealthListener(this);
		_previousHealth = entity.health.Value;
	}

	public override void Unlink()
	{
		LinkedEntity.RemovePositionListener(this);
		LinkedEntity.RemoveAttackProcessListener(this);
		LinkedEntity.RemoveFacingListener(this);
		base.Unlink();
	}
	
	public void OnHealth(GameEntity entity, int value)
	{
		if (value < _previousHealth)
			_damageTakeParticle.Play();

		_previousHealth = value;

		if (value > 0)
			return;

		Unlink();
		SetViewActive(false);
	}

	public void OnPosition(GameEntity entity, Vector3 value)
	{
		transform.position = value;

		if (_animator.GetCurrentAnimatorStateInfo(0).fullPathHash != _runStateHash)
			_animator.SetTrigger(_runTrigger);
	}

	public void OnAttackProcess(GameEntity entity, float startTime, float hitTime)
	{
		_animator.SetTrigger(_attackTrigger);
	}

	public void OnFacing(GameEntity entity, Vector3 direction)
	{
		var rotation = Quaternion.LookRotation(direction);
		transform.rotation = rotation;
	}
}
}