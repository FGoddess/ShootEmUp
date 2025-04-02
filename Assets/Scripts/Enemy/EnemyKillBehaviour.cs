using Atomic.Entities;
using UnityEngine;

namespace Enemy
{
public class EnemyKillBehaviour : IEntityInit
{
	private const float DeathDelay = 0.2f;

	public void Init(IEntity entity)
	{
		var hitPoints = entity.GetHitPoints();

		hitPoints.Subscribe(hp =>
		{
			if (hp > 0f)
				return;
			
			Object.Destroy(entity.GetRoot().gameObject, DeathDelay);
		});
	}
}
}