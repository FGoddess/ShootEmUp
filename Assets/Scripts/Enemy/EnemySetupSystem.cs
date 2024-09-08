using Components;
using Controllers;
using Enemy.Agents;
using UnityEngine;
using Zenject;

namespace Enemy
{
public class EnemySetupSystem
{
	private readonly HitPointsComponent  _characterHitPoints;
	private readonly EnemyFireController _enemyFireController;
	private readonly EnemyPositions      _enemyPositions;

	public EnemySetupSystem(HitPointsComponent characterHitPoints, EnemyFireController enemyFireController, EnemyPositions enemyPositions)
	{
		_characterHitPoints  = characterHitPoints;
		_enemyFireController = enemyFireController;
		_enemyPositions = enemyPositions;
	}

	
	public void OnEnemySpawned(EnemyAgent enemy)
	{
		var spawnPosition = _enemyPositions.RandomSpawnPosition();
		enemy.transform.position = spawnPosition.position;
		var attackPosition = _enemyPositions.RandomAttackPosition();
		enemy.SetDestination(attackPosition.position);
		
		enemy.SetTarget(_characterHitPoints);
		
		_enemyFireController.OnEnemySpawned(enemy.AttackAgent);
	}
	
	public void OnEnemyDied(EnemyAgent enemy)
	{
		_enemyFireController.OnEnemyDied(enemy.AttackAgent);
	}
}
}