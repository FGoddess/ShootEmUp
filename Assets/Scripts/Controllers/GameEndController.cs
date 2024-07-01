using Common;
using Components;
using Game;
using UnityEngine;

namespace Controllers
{
public class GameEndController : MonoBehaviour, IGameResumeListener, IGamePauseListener
{
	[SerializeField]
	private GameManager _gameManager;
	[SerializeField]
	private HitPointsComponent _characterHitPoints;
	
	
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