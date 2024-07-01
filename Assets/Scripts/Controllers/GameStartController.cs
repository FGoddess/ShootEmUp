using System;
using Common;
using Game;
using UnityEngine;

namespace Controllers
{
public class GameStartController : MonoBehaviour, IGameStartListener, IGameFinishListener
{
	[SerializeField]
	private GameStartup _gameStartup;
	[SerializeField]
	private UiStartScreen _startScreen;
	[SerializeField]
	private GameManager _gameManager;


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