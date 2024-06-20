using Character;
using Input;
using UnityEngine;

namespace Controllers
{
public class InputController : MonoBehaviour
{
	[SerializeField]
	private InputManager _inputManager;
	[SerializeField]
	private CharacterAgent _characterAgent;


	private void OnEnable()
	{
		_inputManager.FireRequired += _characterAgent.SetFireRequired;
	}

	private void OnDisable()
	{
		_inputManager.FireRequired -= _characterAgent.SetFireRequired;
	}
}
}