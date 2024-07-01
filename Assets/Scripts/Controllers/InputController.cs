using Character;
using Common;
using Input;
using UnityEngine;

namespace Controllers
{
public class InputController : MonoBehaviour, IGameResumeListener, IGamePauseListener
{
	[SerializeField]
	private InputManager _inputManager;
	[SerializeField]
	private CharacterAgent _characterAgent;
	

	public void OnResume()
	{
		_inputManager.FireRequired += _characterAgent.SetFireRequired;
	}

	public void OnPause()
	{
		_inputManager.FireRequired -= _characterAgent.SetFireRequired;
	}
}
}