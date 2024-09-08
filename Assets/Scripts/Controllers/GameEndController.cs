using Common;
using Components;
using Game;
using UnityEngine;

namespace Controllers
{
public class GameEndController : IGameResumeListener, IGamePauseListener
{
	private readonly GameManager        _gameManager;
	private readonly HitPointsComponent _characterHitPoints;

	public GameEndController(GameManager gameManager, HitPointsComponent characterHitPoints)
	{
		_gameManager             = gameManager;
		_characterHitPoints = characterHitPoints;
	}
	
	
	public void OnResume()
	{
		_characterHitPoints.HpEmpty += _gameManager.FinishGame;
	}

	public void OnPause()
	{
		_characterHitPoints.HpEmpty -= _gameManager.FinishGame;
	}
}
}