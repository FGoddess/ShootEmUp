using System.Collections.Generic;
using Level;
using UnityEngine;

namespace Bullets
{
public sealed class BulletSystem : MonoBehaviour
{
	[SerializeField]
	private BulletsPool _bulletsPool;
	[SerializeField]
	private Transform _worldTransform;
	[SerializeField]
	private LevelBounds _levelBounds;
	
	private readonly HashSet<Bullet> _activeBullets = new();
	private readonly List<Bullet>    _cache         = new();

	
	private void FixedUpdate()
	{
		_cache.Clear();
		_cache.AddRange(_activeBullets);

		for (int i = 0, count = _cache.Count; i < count; i++)
		{
			var bullet = _cache[i];
			if (!_levelBounds.InBounds(bullet.transform.position))
				RemoveBullet(bullet);
		}
	}

	public void FlyBulletByArgs(Args args)
	{
		var bullet = _bulletsPool.GetFromPool();
		bullet.transform.SetParent(_worldTransform);
		bullet.Setup(args);

		if (_activeBullets.Add(bullet))
			bullet.OnCollisionEntered += OnBulletCollision;
	}

	private void OnBulletCollision(Bullet bullet, Collision2D collision)
	{
		BulletUtils.DealDamage(bullet, collision.gameObject);
		RemoveBullet(bullet);
	}

	private void RemoveBullet(Bullet bullet)
	{
		if (_activeBullets.Remove(bullet))
		{
			bullet.OnCollisionEntered -= OnBulletCollision;
			_bulletsPool.ReturnToPool(bullet);
		}
	}

	public struct Args
	{
		public Vector2 Position;
		public Vector2 Velocity;
		public Color   Color;
		public int     PhysicsLayer;
		public int     Damage;
		public bool    IsPlayer;
	}
}
}