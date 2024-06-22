using Components;
using Controllers;
using Enemy.Agents;
using UnityEngine;

namespace Enemy
{
public class EnemySetupSystem : MonoBehaviour
{
	[SerializeField]
	private EnemyPositions _enemyPositions;
	[SerializeField]
	private HitPointsComponent _characterHitPoints;
	[SerializeField]
	private EnemyFireController _enemyFireController;
	
	
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