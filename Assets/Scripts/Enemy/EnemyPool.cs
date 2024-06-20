using System.Collections.Generic;
using Enemy.Agents;
using UnityEngine;

namespace Enemy
{
public sealed class EnemyPool : MonoBehaviour
{
	[Header("Spawn")]
	[SerializeField]
	private Transform _worldTransform;

	[Header("Pool")]
	[SerializeField]
	private Transform _container;
	[SerializeField]
	private EnemyAgent _prefab;
	[SerializeField]
	private int _initialEnemiesCount = 7;


	private readonly Queue<EnemyAgent> _enemyPool = new();

	private void Awake()
	{
		for (var i = 0; i < _initialEnemiesCount; i++)
		{
			var enemy = Instantiate(_prefab, _container);
			_enemyPool.Enqueue(enemy);
		}
	}

	public EnemyAgent SpawnEnemy()
	{
		if (!_enemyPool.TryDequeue(out var enemy))
			return null;

		enemy.transform.SetParent(_worldTransform);
		return enemy;
	}

	public void ReturnToPool(EnemyAgent enemy)
	{
		enemy.transform.SetParent(_container);
		_enemyPool.Enqueue(enemy);
	}
}
}