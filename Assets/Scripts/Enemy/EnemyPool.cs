using System.Collections.Generic;
using Character;
using Enemy.Agents;
using ShootEmUp;
using UnityEngine;

namespace Enemy
{
public sealed class EnemyPool : MonoBehaviour
{
	[Header("Spawn")]
	[SerializeField]
	private EnemyPositions enemyPositions;

	[SerializeField]
	private CharacterTemp _character;

	[SerializeField]
	private Transform worldTransform;

	[Header("Pool")]
	[SerializeField]
	private Transform container;

	[SerializeField]
	private EnemyAgent _prefab;

	[SerializeField]
	private int _initialEnemiesCount = 7;

	private readonly Queue<EnemyAgent> _enemyPool = new();

	private void Awake()
	{
		for (var i = 0; i < _initialEnemiesCount; i++)
		{
			var enemy = Instantiate(_prefab, container);
			_enemyPool.Enqueue(enemy);
		}
	}

	public EnemyAgent SpawnEnemy()
	{
		if (!_enemyPool.TryDequeue(out var enemy))
			return null;

		enemy.transform.SetParent(worldTransform);

		var spawnPosition = enemyPositions.RandomSpawnPosition();
		enemy.transform.position = spawnPosition.position;

		var attackPosition = enemyPositions.RandomAttackPosition();
		enemy.SetDestination(attackPosition.position);
		enemy.SetTarget(_character);
		return enemy;
	}

	public void ReturnToPool(EnemyAgent enemy)
	{
		enemy.transform.SetParent(container);
		_enemyPool.Enqueue(enemy);
	}
}
}