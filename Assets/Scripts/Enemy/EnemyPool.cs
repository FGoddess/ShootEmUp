using Common;
using Enemy.Agents;
using UnityEngine;
using Zenject;

namespace Enemy
{
public sealed class EnemyPool : ObjectPool<EnemyAgent>
{
	public EnemyPool(IFactory<Transform, EnemyAgent> factory, Transform container, int initialCount) : base(
		factory,
		container,
		initialCount) { }
}
}