using System.Collections.Generic;
using Level;
using ShootEmUp;
using UnityEngine;

namespace Bullets
{
public sealed class BulletSystem : MonoBehaviour
{
	[SerializeField]
	private Transform _container;
	[SerializeField]
	private Bullet _prefab;
	[SerializeField]
	private Transform _worldTransform;
	[SerializeField]
	private LevelBounds _levelBounds;
	[SerializeField]
	private int _initialCount = 50;


	private readonly Queue<Bullet>   _bulletPool    = new();
	private readonly HashSet<Bullet> _activeBullets = new();
	private readonly List<Bullet>    _cache         = new();


	private void Awake()
	{
		for (var i = 0; i < _initialCount; i++)
		{
			var bullet = Instantiate(_prefab, _container);
			_bulletPool.Enqueue(bullet);
		}
	}

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
		if (_bulletPool.TryDequeue(out var bullet))
			bullet.transform.SetParent(_worldTransform);
		else
			bullet = Instantiate(_prefab, _worldTransform);

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
			bullet.transform.SetParent(_container);
			_bulletPool.Enqueue(bullet);
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