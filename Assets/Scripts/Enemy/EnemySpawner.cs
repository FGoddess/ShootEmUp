using System;
using Common;
using Enemy.Agents;
using UnityEngine;

namespace Enemy
{
public sealed class EnemySpawner : MonoBehaviour, IGameStartListener, IGameUpdateListener
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

	private float _spawnTimer;
	private int   _activeEnemiesCount;

	private const float SPAWN_INTERVAL = 1f;

	public event Action<EnemyAgent> EnemySpawned;
	public event Action<EnemyAgent> EnemyDied;
	

	public void OnStart()
	{
		_enemyPool = new EnemyPool(_enemyPrefab, _container, _initialCount);
	}

	public void OnUpdate()
	{
		if (_spawnTimer < SPAWN_INTERVAL)
		{
			_spawnTimer += Time.deltaTime;
			return;
		}

		_spawnTimer = 0f;

		if (_activeEnemiesCount >= _maxActiveEnemiesCount)
			return;
		
		var enemy = _enemyPool.GetFromPool(_worldTransform);
		enemy.Died += OnEnemyDied;
		EnemySpawned?.Invoke(enemy);

		_activeEnemiesCount++;
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