using System.Collections.Generic;
using Common;
using Enemy.Agents;
using UnityEngine;
using Zenject;

namespace Enemy
{
public class EnemyUpdateSystem : IGameResumeListener, IGamePauseListener, IGameFixedUpdateListener
{
	private readonly EnemySpawner _enemySpawner;

	private readonly List<EnemyAgent> _activeEnemies = new();
	
	public EnemyUpdateSystem(EnemySpawner enemySpawner)
	{
		_enemySpawner = enemySpawner;
	}


	public void OnResume()
	{
		_enemySpawner.EnemySpawned += OnEnemySpawned;
		_enemySpawner.EnemyDied    += OnEnemyDied;

		foreach (var enemy in _activeEnemies)
			enemy.OnResume();
	}

	public void OnPause()
	{
		_enemySpawner.EnemySpawned -= OnEnemySpawned;
		_enemySpawner.EnemyDied    -= OnEnemyDied;

		foreach (var enemy in _activeEnemies)
			enemy.OnPause();
	}

	private void OnEnemySpawned(EnemyAgent enemy)
	{
		_activeEnemies.Add(enemy);
		enemy.OnResume();
	}

	private void OnEnemyDied(EnemyAgent enemy)
	{
		_activeEnemies.Remove(enemy);
	}

	public void OnFixedUpdate()
	{
		for (var i = 0; i < _activeEnemies.Count; i++)
			_activeEnemies[i].OnFixedUpdate();
	}
}
}