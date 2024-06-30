using Common;
using Enemy.Agents;
using UnityEngine;

namespace Enemy
{
public sealed class EnemyPool : ObjectPool<EnemyAgent>
{
	public EnemyPool(EnemyAgent prefab, Transform container, int initialCount) : base(prefab, container, initialCount) { }
}
}