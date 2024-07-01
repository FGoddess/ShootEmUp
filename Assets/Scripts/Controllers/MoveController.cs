using System;
using Common;
using Components;
using Input;
using UnityEngine;

namespace Controllers
{
public class MoveController : MonoBehaviour, IGameResumeListener, IGamePauseListener
{
	[SerializeField]
	private MoveComponent _moveComponent;
	[SerializeField]
	private InputManager _inputManager;

	
	public void OnResume()
	{
		_inputManager.MoveDirChanged += _moveComponent.MoveByRigidbodyVelocity;
	}

	public void OnPause()
	{
		_inputManager.MoveDirChanged -= _moveComponent.MoveByRigidbodyVelocity;
	}
}
}