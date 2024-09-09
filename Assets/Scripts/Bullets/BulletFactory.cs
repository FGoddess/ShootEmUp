using UnityEngine;
using Zenject;

namespace Bullets
{
public class BulletFactory : IFactory<Transform, Bullet>
{
	private readonly DiContainer _container;
	private readonly Bullet      _bulletPrefab;

	public BulletFactory(DiContainer container, Bullet bulletPrefab)
	{
		_container   = container;
		_bulletPrefab = bulletPrefab;
	}
	
	public Bullet Create(Transform parent)
	{
		return _container.InstantiatePrefabForComponent<Bullet>(_bulletPrefab, parent);
	}
}
}