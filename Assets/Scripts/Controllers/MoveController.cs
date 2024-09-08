using Common;
using Components;
using Input;

namespace Controllers
{
public class MoveController : IGameResumeListener, IGamePauseListener
{
	private readonly MoveComponent _moveComponent;
	private readonly InputManager  _inputManager;

	public MoveController(MoveComponent moveComponent, InputManager inputManager)
	{
		_moveComponent = moveComponent;
		_inputManager  = inputManager;
	}


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