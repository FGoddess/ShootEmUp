using Character;
using Components;
using Enemy;
using UnityEngine;

namespace Bullets
{
public class BulletSetupSystem : MonoBehaviour
{
	[SerializeField]
	private BulletSystem _bulletSystem;
	[SerializeField]
	private BulletConfig _enemyConfig;
	[SerializeField]
	private BulletConfig _playerConfig;


	public void OnCharacterFired(Vector2 position, Vector2 direction)
	{
		Fire(true, position, direction);
	}

	public void OnEnemyFired(Vector2 position, Vector2 direction)
	{
		Fire(false, position, direction);
	}

	private void Fire(bool isPlayer, Vector2 position, Vector2 direction)
	{
		var config = isPlayer ? _playerConfig : _enemyConfig;

		_bulletSystem.FlyBulletByArgs(new BulletSystem.Args
		{
			IsPlayer     = isPlayer,
			PhysicsLayer = (int)config.PhysicsLayer,
			Color        = config.Color,
			Damage       = config.Damage,
			Position     = position,
			Velocity     = direction * config.Speed
		});
	}
}
}