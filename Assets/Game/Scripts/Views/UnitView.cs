using Core;
using UnityEngine;
using Entitas.Unity;

namespace Views
{
public class UnitView : UnityView, IPositionListener, IHealthListener
{
	[SerializeField]
	private ParticleSystem _bloodParticle;

	private int _previousHealth;

	public override void Link(Contexts contexts, GameEntity entity)
	{
		base.Link(contexts, entity);
		entity.AddPositionListener(this);
		entity.AddHealthListener(this);
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
}
}