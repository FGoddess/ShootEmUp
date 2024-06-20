using System;
using System.Collections;
using Bullets;
using Enemy.Agents;
using UnityEngine;

namespace Enemy
{
public sealed class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private EnemyPool _enemyPool;
	[SerializeField]
	private BulletSetupSystem _bulletSetupSystem;

	private const float SPAWN_INTERVAL = 1f;

	public event Action<EnemyAgent> EnemySpawned;
	public event Action<EnemyAgent> EnemyDied;

	
	private IEnumerator Start()
	{
		while (true)
		{
			yield return new WaitForSeconds(SPAWN_INTERVAL);
			var enemy = _enemyPool.SpawnEnemy();
			if (enemy == null)
				yield break;

			enemy.Died += OnEnemyDied;
			EnemySpawned?.Invoke(enemy);
		}
	}

	private void OnEnemyDied(EnemyAgent enemy)
	{
		_enemyPool.ReturnToPool(enemy);
		enemy.Died -= OnEnemyDied;
		EnemyDied?.Invoke(enemy);
	}
}
}