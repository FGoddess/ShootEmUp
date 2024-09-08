using Character;
using Common;
using Input;
using UnityEngine;

namespace Controllers
{
public class InputController : IGameResumeListener, IGamePauseListener
{
	private readonly InputManager   _inputManager;
	private readonly CharacterAgent _characterAgent;
	
	public InputController(InputManager inputManager, CharacterAgent characterAgent)
	{
		_inputManager        = inputManager;
		_characterAgent = characterAgent;
	}


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