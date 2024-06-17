using System;
using Character;
using UnityEngine;

namespace Input
{
public sealed class InputManager : MonoBehaviour
{
	public event Action<Vector2> MoveDirChanged;
	public event Action          Fired;

	private Vector2 _moveDir;
	private Vector2 _previousMoveDir;
	private bool    _isFired;

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
			_isFired = true;

		_moveDir = new Vector2(UnityEngine.Input.GetAxis("Horizontal"), 0);
	}

	private void FixedUpdate()
	{
		//if (_moveDir != _previousMoveDir)
		//{
			MoveDirChanged?.Invoke(_moveDir);
			_previousMoveDir = _moveDir;
		//}
		
		if (_isFired)
		{
			Fired?.Invoke();
			_isFired = false;
		}
	}
}
}