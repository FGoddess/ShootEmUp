using Bullets;
using Components;
using Enemy.Agents;
using UnityEngine;

namespace Enemy
{
public class EnemySetupSystem : MonoBehaviour
{
	[SerializeField]
	private BulletSetupSystem _bulletSetupSystem;
	[SerializeField]
	private EnemyPositions _enemyPositions;
	[SerializeField]
	private HitPointsComponent _characterHitPoints;
	
	
	public void OnEnemySpawned(EnemyAgent enemy)
	{
		var spawnPosition = _enemyPositions.RandomSpawnPosition();
		enemy.transform.position = spawnPosition.position;
		var attackPosition = _enemyPositions.RandomAttackPosition();
		enemy.SetDestination(attackPosition.position);
		
		enemy.SetTarget(_characterHitPoints);
		enemy.WeaponComponent.Fired += _bulletSetupSystem.OnEnemyFired;
	}
	
	public void OnEnemyDied(EnemyAgent enemy)
	{
		enemy.WeaponComponent.Fired -= _bulletSetupSystem.OnEnemyFired;
	}
}
}