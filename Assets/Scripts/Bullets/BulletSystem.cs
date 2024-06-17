using System.Collections.Generic;
using ShootEmUp;
using UnityEngine;

namespace Bullets
{
public sealed class BulletSystem : MonoBehaviour
{
	[SerializeField]
	private int initialCount = 50;

	[SerializeField] private Transform   container;
	[SerializeField] private Bullet      prefab;
	[SerializeField] private Transform   worldTransform;
	[SerializeField] private LevelBounds levelBounds;

	private readonly Queue<Bullet>   _bulletPool    = new();
	private readonly HashSet<Bullet> _activeBullets = new();
	private readonly List<Bullet>    _cache         = new();

	private void Awake()
	{
		for (var i = 0; i < initialCount; i++)
		{
			var bullet = Instantiate(prefab, container);
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
			if (!levelBounds.InBounds(bullet.transform.position))
				RemoveBullet(bullet);
		}
	}

	public void FlyBulletByArgs(Args args)
	{
		Debug.Log("da)");
		if (_bulletPool.TryDequeue(out var bullet))
			bullet.transform.SetParent(worldTransform);
		else
			bullet = Instantiate(prefab, worldTransform);

		bullet.SetPosition(args.position);
		bullet.SetColor(args.color);
		bullet.SetPhysicsLayer(args.physicsLayer);
		bullet.damage   = args.damage;
		bullet.isPlayer = args.isPlayer;
		bullet.SetVelocity(args.velocity);

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
			bullet.transform.SetParent(container);
			_bulletPool.Enqueue(bullet);
		}
	}

	public struct Args
	{
		public Vector2 position;
		public Vector2 velocity;
		public Color   color;
		public int     physicsLayer;
		public int     damage;
		public bool    isPlayer;
	}
}
}