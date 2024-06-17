using System;
using Character;
using Components;
using ShootEmUp;
using UnityEngine;

namespace Input
{
public class FireController : MonoBehaviour
{
	[SerializeField]
	private InputManager _inputManager;
	[SerializeField]
	private CharacterTemp _characterTemp;


	private void OnEnable()
	{
		_inputManager.Fired += _characterTemp.SetFireRequired;
	}

	private void OnDisable()
	{
		_inputManager.Fired -= _characterTemp.SetFireRequired;
	}
}
}