using System;
using Components;
using Input;
using UnityEngine;

namespace Controllers
{
public class MoveController : MonoBehaviour
{
	[SerializeField]
	private MoveComponent _moveComponent;
	[SerializeField]
	private InputManager _inputManager;


	public void OnEnable()
	{
		_inputManager.MoveDirChanged += _moveComponent.MoveByRigidbodyVelocity;
	}
	
	public void OnDisable()
	{
		_inputManager.MoveDirChanged += _moveComponent.MoveByRigidbodyVelocity;
	}
}
}