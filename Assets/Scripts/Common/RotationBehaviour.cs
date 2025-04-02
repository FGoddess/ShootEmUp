using Atomic.Entities;
using UnityEngine;

namespace Common
{
public class RotationBehaviour : IEntityInit, IEntityUpdate
{
	private Transform _root;

	private float _rotationSpeed;

	public void Init(IEntity entity)
	{
		_root          = entity.GetRootView();
		_rotationSpeed = entity.GetRotationSpeed();
	}

	public void OnUpdate(IEntity entity, float deltaTime)
	{
		var lookTarget  = entity.GetLookTarget();
		var direction = (lookTarget - _root.position);
    
		if (direction.sqrMagnitude > 0.01f)
		{
			direction = direction.normalized;
			var   rotation = Quaternion.LookRotation(direction, Vector3.up);
			float yRot     = Quaternion.Lerp(_root.rotation, rotation, _rotationSpeed * Time.deltaTime).eulerAngles.y;
        
			_root.eulerAngles = new Vector3(0f, yRot, 0f);
		}
	}
}
}