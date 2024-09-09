using Common;
using UnityEngine;
using Zenject;

namespace Bullets
{
public sealed class BulletSetupSystem
{
	private readonly BulletConfig _enemyConfig;
	private readonly BulletConfig _playerConfig;
	private readonly BulletSystem _bulletSystem;

	private BulletSetupSystem([Inject(Id = DiHelper.PLAYER_BULLET_CONFIG)] BulletConfig playerConfig,
	                          [Inject(Id = DiHelper.ENEMY_BULLET_CONFIG)]
	                          BulletConfig enemyConfig,
	                          BulletSystem bulletSystem)
	{
		_playerConfig = playerConfig;
		_enemyConfig  = enemyConfig;
		_bulletSystem = bulletSystem;
	}


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