using Enemy.Agents;
using UnityEngine;
using Zenject;

namespace Enemy
{
public class EnemyFactory : IFactory<Transform, EnemyAgent>
{
	private readonly DiContainer _container;
	private readonly EnemyAgent  _enemyPrefab;

	public EnemyFactory(DiContainer container, EnemyAgent enemyPrefab)
	{
		_container   = container;
		_enemyPrefab = enemyPrefab;
	}
	
	public EnemyAgent Create(Transform parent)
	{
		return _container.InstantiatePrefabForComponent<EnemyAgent>(_enemyPrefab, parent);
	}
}
}