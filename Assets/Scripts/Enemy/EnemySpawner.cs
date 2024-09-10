using System;
using Common;
using Enemy.Agents;
using UnityEngine;
using Zenject;

namespace Enemy
{
public sealed class EnemySpawner : IGameStartListener, IGameUpdateListener
{
	private EnemyPool _enemyPool;

	private readonly Transform _container;
	private readonly Transform _worldTransform;
	private readonly int       _initialCount;
	private readonly int       _maxActiveEnemiesCount;

	private readonly EnemyFactory _enemyFactory;

	private float _spawnTimer;
	private int   _activeEnemiesCount;

	private const float SPAWN_INTERVAL = 1f;

	public event Action<EnemyAgent> EnemySpawned;
	public event Action<EnemyAgent> EnemyDied;

	public EnemySpawner(Transform    container,
	                    Transform    worldTransform,
	                    EnemyFactory enemyFactory,
	                    int          initialCount,
	                    int          maxActiveEnemiesCount)
	{
		_container             = container;
		_worldTransform        = worldTransform;
		_enemyFactory          = enemyFactory;
		_initialCount          = initialCount;
		_maxActiveEnemiesCount = maxActiveEnemiesCount;
	}


	public void OnStart()
	{
		_enemyPool = new EnemyPool(_enemyFactory, _container, _initialCount);
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