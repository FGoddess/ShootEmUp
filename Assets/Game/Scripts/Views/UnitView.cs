using Core;
using UnityEngine;
using Entitas.Unity;

namespace Views
{
public class UnitView : UnityView, IPositionListener, IHealthListener
{
	public override void Link(Contexts contexts, GameEntity entity)
	{
		base.Link(contexts, entity);
		entity.AddPositionListener(this);
		entity.AddHealthListener(this);
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
		if (value > 0)
			return;

		Unlink();
		SetViewActive(false);
	}
}
}