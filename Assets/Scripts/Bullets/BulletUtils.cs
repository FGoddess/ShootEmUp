using Components;
using UnityEngine;

namespace Bullets
{
public static class BulletUtils
{
	public static void DealDamage(Bullet bullet, GameObject other)
	{
		if (!other.TryGetComponent(out TeamComponent team))
			return;
		if (bullet.IsPlayer == team.IsPlayer)
			return;

		if (other.TryGetComponent(out HitPointsComponent hitPoints))
			hitPoints.TakeDamage(bullet.Damage);
	}
}
}