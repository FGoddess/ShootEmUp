using System;
using Common;
using UnityEngine;

namespace Input
{
public sealed class InputManager : MonoBehaviour, IGameFixedUpdateListener, IGameUpdateListener
{
	private Vector2 _moveDir;
	private bool    _isFireRequired;

	public event Action<Vector2> MoveDirChanged;
	public event Action          FireRequired;


	public void OnUpdate()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
			_isFireRequired = true;

		_moveDir = new Vector2(UnityEngine.Input.GetAxis("Horizontal"), 0);
	}

	public void OnFixedUpdate()
	{
		MoveDirChanged?.Invoke(_moveDir);

		if (_isFireRequired)
		{
			FireRequired?.Invoke();
			_isFireRequired = false;
		}
	}
}
}