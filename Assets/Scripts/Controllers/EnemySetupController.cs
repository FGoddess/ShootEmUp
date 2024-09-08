using Common;
using Enemy;
using UnityEngine;
using Zenject;

namespace Controllers
{
public class EnemySetupController : IGameResumeListener, IGamePauseListener
{
	private readonly EnemySpawner     _enemySpawner;
	private readonly EnemySetupSystem _enemySetupSystem;
	

	public EnemySetupController(EnemySpawner enemySpawner, EnemySetupSystem enemySetupSystem)
	{
		_enemySpawner     = enemySpawner;
		_enemySetupSystem = enemySetupSystem;
	}


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