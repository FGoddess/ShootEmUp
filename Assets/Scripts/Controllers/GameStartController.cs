using Common;
using Game;

namespace Controllers
{
public class GameStartController : IGameStartListener, IGameFinishListener
{
	private readonly GameStartup   _gameStartup;
	private readonly UiStartScreen _startScreen;
	private readonly GameManager   _gameManager;

	public GameStartController(GameStartup gameStartup, UiStartScreen startScreen, GameManager gameManager)
	{
		_gameStartup = gameStartup;
		_startScreen = startScreen;
		_gameManager = gameManager;
	}


	public void OnStart()
	{
		_startScreen.gameObject.SetActive(true);

		_startScreen.StartButtonPressed   += _gameStartup.Startup;
		_gameStartup.CountdownEnded       += _gameManager.ResumeGame;
		_gameStartup.CountdownEnded       += _startScreen.Deactivate;
		_gameStartup.CountdownTimeChanged += _startScreen.SetCountdownText;
	}

	public void OnFinish()
	{
		_startScreen.StartButtonPressed   -= _gameStartup.Startup;
		_gameStartup.CountdownEnded       -= _gameManager.ResumeGame;
		_gameStartup.CountdownEnded       -= _startScreen.Deactivate;
		_gameStartup.CountdownTimeChanged -= _startScreen.SetCountdownText;
	}
}
}