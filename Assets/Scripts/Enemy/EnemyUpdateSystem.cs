using System.Collections.Generic;
using Common;
using Enemy.Agents;
using UnityEngine;

namespace Enemy
{
public class EnemyUpdateSystem : MonoBehaviour, IGameResumeListener, IGamePauseListener, IGameFixedUpdateListener
{
	[SerializeField]
	private EnemySpawner _enemySpawner;

	private readonly List<EnemyAgent> _activeEnemies = new();


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