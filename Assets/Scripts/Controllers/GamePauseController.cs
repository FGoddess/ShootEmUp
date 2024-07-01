using Common;
using Game;
using UnityEngine;

namespace Controllers
{
public class GamePauseController : MonoBehaviour, IGameStartListener, IGameFinishListener
{
	[SerializeField]
	private UiPauseScreen _pauseScreen;
	[SerializeField]
	private GameManager _gameManager;

	
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