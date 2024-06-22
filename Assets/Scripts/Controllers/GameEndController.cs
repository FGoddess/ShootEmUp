using Components;
using GameManager;
using UnityEngine;

namespace Controllers
{
public class GameEndController : MonoBehaviour
{
	[SerializeField]
	private GameEndSystem _gameEndSystem;
	[SerializeField]
	private HitPointsComponent _characterHitPoints;
	
	
	public void OnEnable()
	{
		_characterHitPoints.HpEmpty += _gameEndSystem.FinishGame;
	}

	public void OnDisable()
	{
		_characterHitPoints.HpEmpty -= _gameEndSystem.FinishGame;
	}
}
}