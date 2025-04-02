using Atomic.Entities;
using UnityEngine;

namespace CameraMover
{
public class CameraMoveBehaviour : IEntityInit, IEntityUpdate
{
	private Transform _target;
	private Transform _root;

	private const float ZOffset = 3f;

	void IEntityInit.Init(IEntity entity)
	{
		_target = entity.GetTarget();
		_root   = entity.GetRoot();
	}

	void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
	{
		var pos = _target.position;
		_root.position = new Vector3(pos.x, _root.position.y, pos.z - ZOffset);
	}
}
}