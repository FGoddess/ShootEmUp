using System;
using System.Collections;
using System.Collections.Generic;
using Bullets;
using Components;
using Enemy.Agents;
using ShootEmUp;
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

	private IEnumerator Start()
	{
		while (true)
		{
			yield return new WaitForSeconds(SPAWN_INTERVAL);
			var enemy = _enemyPool.SpawnEnemy();
			if (enemy == null)
				yield break;
			
			EnemySpawned?.Invoke(enemy);
			enemy.Died  += HitPointsComponentOnHpEmpty;
			enemy.Fired += _bulletSetupSystem.OnEnemyFired;
		}
	}

	private void HitPointsComponentOnHpEmpty(EnemyAgent enemy)
	{
		enemy.Died  -= HitPointsComponentOnHpEmpty;
		enemy.Fired -= _bulletSetupSystem.OnEnemyFired;
		_enemyPool.ReturnToPool(enemy);
	}
}
}