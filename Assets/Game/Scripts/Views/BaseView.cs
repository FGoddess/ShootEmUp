using Core;
using UnityEngine;

namespace Views
{
public class BaseView : UnityView, IHealthListener
{
	[SerializeField]
	private ParticleSystem _damageTakeParticle;
	
	private int _previousHealth;

	public override void Link(Contexts contexts, GameEntity entity)
	{
		base.Link(contexts, entity);
		entity.AddHealthListener(this);
		_previousHealth = entity.health.Value;
	}

	public override void Unlink()
	{
		LinkedEntity.RemoveHealthListener(this);
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
}
}