using Character;
using Enemy;
using UnityEngine;

namespace Bullets
{
public class BulletSetupSystem : MonoBehaviour
{
	[SerializeField]
	private CharacterTemp _characterTemp;
	[SerializeField]
	private EnemySpawner _enemySpawner;
	[SerializeField]
	private BulletSystem _bulletSystem;
	[SerializeField]
	private BulletConfig _enemyConfig;
	[SerializeField]
	private BulletConfig _playerConfig;


	private void OnEnable()
	{
		_characterTemp.Fired += OnCharacterFired;
	}
	
	private void OnDisable()
	{
		_characterTemp.Fired -= OnCharacterFired;
	}

	private void OnCharacterFired(Vector2 position, Vector2 direction)
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
			isPlayer     = false,
			physicsLayer = (int)config.physicsLayer,
			color        = config.color,
			damage       = config.damage,
			position     = position,
			velocity     = direction * _enemyConfig.speed
		});
	}
}
}