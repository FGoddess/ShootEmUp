using System;
using Character;
using UnityEngine;

namespace Input
{
public sealed class InputManager : MonoBehaviour
{
	public event Action<Vector2> MoveDirChanged;
	public event Action          FireRequired;

	private Vector2 _moveDir;
	private bool    _isFireRequired;

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
			_isFireRequired = true;

		_moveDir = new Vector2(UnityEngine.Input.GetAxis("Horizontal"), 0);
	}

	private void FixedUpdate()
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