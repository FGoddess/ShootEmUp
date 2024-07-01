using System.Collections.Generic;
using Common;
using Components;
using Level;
using UnityEngine;

namespace Bullets
{
public sealed class BulletSystem : MonoBehaviour, IGameStartListener, IGameFixedUpdateListener, IGamePauseListener, IGameResumeListener
{
	[SerializeField]
	private Transform _container;
	[SerializeField]
	private Transform _worldTransform;
	[SerializeField]
	private Bullet _bulletPrefab;
	[SerializeField]
	private int _initialCount = 10;
	[SerializeField]
	private LevelBounds _levelBounds;


	private BulletsPool _bulletsPool;

	private readonly List<Bullet> _activeBullets = new();


	public void OnStart()
	{
		_bulletsPool = new BulletsPool(_bulletPrefab, _container, _initialCount);
	}

	public void OnFixedUpdate()
	{
		for (var i = 0; i < _activeBullets.Count; i++)
			if (!_levelBounds.InBounds(_activeBullets[i].transform.position))
				RemoveBullet(_activeBullets[i]);
	}

	public void FlyBulletByArgs(Args args)
	{
		var bullet = _bulletsPool.GetFromPool(_worldTransform);
		bullet.Setup(args);

		_activeBullets.Add(bullet);
		bullet.OnCollisionEntered += OnBulletCollision;
	}

	private void OnBulletCollision(Bullet bullet, Collision2D collision)
	{
		DealDamage(bullet, collision.gameObject);
		RemoveBullet(bullet);
	}

	private void DealDamage(Bullet bullet, GameObject other)
	{
		if (!other.TryGetComponent(out TeamComponent team))
			return;
		if (bullet.IsPlayer == team.IsPlayer)
			return;

		if (other.TryGetComponent(out HitPointsComponent hitPoints))
			hitPoints.TakeDamage(bullet.Damage);
	}

	private void RemoveBullet(Bullet bullet)
	{
		_activeBullets.Remove(bullet);
		bullet.OnCollisionEntered -= OnBulletCollision;
		_bulletsPool.ReturnToPool(bullet);
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

	public void OnPause()
	{
		foreach (var bullet in _activeBullets)
			bullet.OnPause();
	}

	public void OnResume()
	{
		foreach (var bullet in _activeBullets)
			bullet.OnResume();
	}
}
}