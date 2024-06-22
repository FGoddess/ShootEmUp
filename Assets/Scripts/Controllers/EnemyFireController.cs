using Bullets;
using Enemy.Agents;
using UnityEngine;

namespace Controllers
{
public class EnemyFireController : MonoBehaviour
{
	[SerializeField]
	private BulletSetupSystem _bulletSetupSystem;

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