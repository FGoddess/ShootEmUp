using Common;
using Game;
using UnityEngine;

namespace Controllers
{
public class GamePauseController : IGameStartListener, IGameFinishListener
{
	private readonly UiPauseScreen _pauseScreen;
	private readonly GameManager   _gameManager;

	public GamePauseController(UiPauseScreen pauseScreen, GameManager gameManager)
	{
		_pauseScreen      = pauseScreen;
		_gameManager = gameManager;
	}
	
	public void OnStart()
	{
		_pauseScreen.PauseButtonPressed  += _gameManager.PauseGame;
		_pauseScreen.ResumeButtonPressed += _gameManager.ResumeGame;
	}

	public void OnFinish()
	{
		_pauseScreen.PauseButtonPressed  -= _gameManager.PauseGame;
		_pauseScreen.ResumeButtonPressed -= _gameManager.ResumeGame;
	}
}
}