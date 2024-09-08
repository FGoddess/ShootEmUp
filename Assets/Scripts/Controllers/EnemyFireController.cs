using Bullets;
using Enemy.Agents;
using UnityEngine;
using Zenject;

namespace Controllers
{
public class EnemyFireController 
{
	private readonly BulletSetupSystem _bulletSetupSystem;

	public EnemyFireController(BulletSetupSystem bulletSetupSystem)
	{
		_bulletSetupSystem = bulletSetupSystem;
	}

	public void OnEnemySpawned(EnemyAttackAgent agent)
	{
		agent.WeaponComponent.Fired += _bulletSetupSystem.OnEnemyFired;
	}

	public void OnEnemyDied(EnemyAttackAgent agent)
	{
		agent.WeaponComponent.Fired -= _bulletSetupSystem.OnEnemyFired;
	}
}
}