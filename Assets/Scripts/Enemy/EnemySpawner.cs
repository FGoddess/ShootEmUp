using System;
using System.Collections;
using Enemy.Agents;
using UnityEngine;

namespace Enemy
{
public sealed class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private EnemyPool _enemyPool;
	[SerializeField]
	private int _maxActiveEnemiesCount = 7;

	private int _activeEnemiesCount;

	private const float SPAWN_INTERVAL = 1f;

	public event Action<EnemyAgent> EnemySpawned;
	public event Action<EnemyAgent> EnemyDied;


	private IEnumerator Start()
	{
		while (true)
		{
			yield return new WaitForSeconds(SPAWN_INTERVAL);

			if (_activeEnemiesCount >= _maxActiveEnemiesCount)
				yield break;

			var enemy = _enemyPool.GetFromPool();
			enemy.Died += OnEnemyDied;
			EnemySpawned?.Invoke(enemy);

			_activeEnemiesCount++;
		}
	}

	private void OnEnemyDied(EnemyAgent enemy)
	{
		_enemyPool.ReturnToPool(enemy);
		enemy.Died -= OnEnemyDied;
		EnemyDied?.Invoke(enemy);

		_activeEnemiesCount--;
	}
}
}