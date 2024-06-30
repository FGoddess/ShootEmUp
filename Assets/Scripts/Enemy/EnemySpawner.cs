using System;
using System.Collections;
using Enemy.Agents;
using UnityEngine;

namespace Enemy
{
public sealed class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private Transform _container;
	[SerializeField]
	private Transform _worldTransform;
	[SerializeField]
	private EnemyAgent _enemyPrefab;
	[SerializeField]
	private int _initialCount = 10;
	[SerializeField]
	private int _maxActiveEnemiesCount = 7;
	
	private EnemyPool _enemyPool;

	private int _activeEnemiesCount;

	private const float SPAWN_INTERVAL = 1f;

	public event Action<EnemyAgent> EnemySpawned;
	public event Action<EnemyAgent> EnemyDied;


	private void Awake()
	{
		_enemyPool = new EnemyPool(_enemyPrefab, _container, _initialCount);
	}

	private IEnumerator Start()
	{
		while (true)
		{
			yield return new WaitForSeconds(SPAWN_INTERVAL);

			if (_activeEnemiesCount >= _maxActiveEnemiesCount)
				yield break;

			var enemy = _enemyPool.GetFromPool(_worldTransform);
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