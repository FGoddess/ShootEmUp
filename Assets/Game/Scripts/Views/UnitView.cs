using Core;
using UnityEngine;

namespace Views
{
public class UnitView : UnityView, IPositionListener
{
	public override void Link(Contexts contexts, GameEntity entity)
	{
		base.Link(contexts, entity);
		entity.AddPositionListener(this);
	}

	public void OnPosition(GameEntity entity, Vector3 value)
	{
		transform.position = value;
	}
}
}