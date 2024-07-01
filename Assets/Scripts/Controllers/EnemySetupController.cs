using Common;
using Enemy;
using UnityEngine;

namespace Controllers
{
public class EnemySetupController : MonoBehaviour, IGameResumeListener, IGamePauseListener
{
	[SerializeField]
	private EnemySpawner _enemySpawner;
	[SerializeField]
	private EnemySetupSystem _enemySetupSystem;
	

	public void OnResume()
	{
		_enemySpawner.EnemySpawned += _enemySetupSystem.OnEnemySpawned;
		_enemySpawner.EnemyDied    += _enemySetupSystem.OnEnemyDied;
	}

	public void OnPause()
	{
		_enemySpawner.EnemySpawned -= _enemySetupSystem.OnEnemySpawned;
		_enemySpawner.EnemyDied    -= _enemySetupSystem.OnEnemyDied;
	}
}
}