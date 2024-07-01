using System;
using Common;
using UnityEngine;

namespace Level
{
public sealed class LevelBackground : MonoBehaviour, IGameStartListener, IGameFixedUpdateListener
{
	[SerializeField]
	private Params _params;

	private Transform _transform;
	private Vector3   _startPosition;
	private Vector3   _endPosition;
	private Vector3   _movementVector;


	public void OnStart()
	{
		_transform = transform;
		var position = _transform.position;
		_startPosition  = new Vector3(position.x, _params.StartPositionY, position.z);
		_endPosition    = new Vector3(position.x, _params.EndPositionY, position.z);
		_movementVector = new Vector3(position.x, position.y, position.z);
	}

	public void OnFixedUpdate()
	{
		if (_transform.position.y <= _endPosition.y)
			_transform.position = _startPosition;

		_movementVector.y   =  _params.MovingSpeedY * Time.fixedDeltaTime;
		_transform.position -= _movementVector;
	}

	[Serializable]
	private sealed class Params
	{
		public float StartPositionY;
		public float EndPositionY;
		public float MovingSpeedY;
	}
}
}