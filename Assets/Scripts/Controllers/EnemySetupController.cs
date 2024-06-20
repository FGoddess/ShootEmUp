using Bullets;
using Components;
using Enemy;
using Enemy.Agents;
using UnityEngine;

namespace Controllers
{
public class EnemySetupController : MonoBehaviour
{
	[SerializeField]
	private EnemySpawner _enemySpawner;
	[SerializeField]
	private EnemySetupSystem _enemySetupSystem;

	
	private void OnEnable()
	{
		_enemySpawner.EnemySpawned += _enemySetupSystem.OnEnemySpawned;
		_enemySpawner.EnemyDied    += _enemySetupSystem.OnEnemyDied;
	}

	private void OnDisable()
	{
		_enemySpawner.EnemySpawned -= _enemySetupSystem.OnEnemySpawned;
		_enemySpawner.EnemyDied    -= _enemySetupSystem.OnEnemyDied;
	}
}
}