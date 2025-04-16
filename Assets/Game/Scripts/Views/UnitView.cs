using Core;
using UnityEngine;
using Entitas.Unity;

namespace Views
{
public class UnitView : UnityView, IPositionListener, IHealthListener, IAttackProcessListener
{
	[SerializeField]
	private ParticleSystem _bloodParticle;

	[SerializeField]
	private Animator _animator;

	private int _previousHealth;

	private readonly int _attackTrigger = Animator.StringToHash("Attack");

	public override void Link(Contexts contexts, GameEntity entity)
	{
		base.Link(contexts, entity);
		entity.AddPositionListener(this);
		entity.AddHealthListener(this);
		entity.AddAttackProcessListener(this);
		_previousHealth = entity.health.Value;
	}

	public override void Unlink()
	{
		LinkedEntity.RemovePositionListener(this);
		LinkedEntity.RemoveHealthListener(this);
		base.Unlink();
	}

	public void OnPosition(GameEntity entity, Vector3 value)
	{
		transform.position = value;
	}

	public void OnHealth(GameEntity entity, int value)
	{
		if (value < _previousHealth)
			_bloodParticle.Play();

		if (value > 0)
			return;

		Unlink();
		SetViewActive(false);
	}

	public void OnAttackProcess(GameEntity entity, GameEntity target, float startTime, float hitTime)
	{
		_animator.SetTrigger(_attackTrigger);
	}
}
}