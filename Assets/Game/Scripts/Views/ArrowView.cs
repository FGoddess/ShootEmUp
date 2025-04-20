using Core;
using UnityEngine;

namespace Views
{
public class ArrowView : UnityView, IPositionListener, IFacingListener, ITargetReachedListener, IArrowTagRemovedListener
{
	public override void Link(Contexts contexts, GameEntity entity)
	{
		base.Link(contexts, entity);
		entity.AddPositionListener(this);
		entity.AddFacingListener(this);
		entity.AddTargetReachedListener(this);
		entity.AddArrowTagRemovedListener(this);
	}

	public override void Unlink()
	{
		LinkedEntity.RemovePositionListener(this);
		LinkedEntity.RemoveFacingListener(this);
		LinkedEntity.RemoveTargetReachedListener(this);
		LinkedEntity.RemoveArrowTagRemovedListener(this);
		base.Unlink();
		gameObject.SetActive(false);
	}

	public void OnPosition(GameEntity entity, Vector3 value)
	{
		transform.position = value;
	}

	public void OnFacing(GameEntity entity, Vector3 direction)
	{
		transform.rotation = Quaternion.LookRotation(direction);
	}

	public void OnTargetReached(GameEntity entity)
	{
		Unlink();
		entity.Destroy();
	}

	public void OnArrowTagRemoved(GameEntity entity)
	{
		Unlink();
		entity.Destroy();
	}
}
}