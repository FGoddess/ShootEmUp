using Atomic.Elements;
using Atomic.Entities;
using Common;
using UnityEngine;

namespace Player
{
public class PlayerInstaller : SceneEntityInstallerBase
{
	[Header("Params")]
	[SerializeField]
	private float _moveSpeed = 4f;
	[SerializeField]
	private float _rotationSpeed = 10f;
	[SerializeField]
	private int _maxBullets = 6;
	[SerializeField]
	private float _bulletReloadTime = 2f;
	[SerializeField]
	private float _shootingCooldown = 0.5f;
	[SerializeField]
	private int _health = 5;

	[Header("Refs")]
	[SerializeField]
	private Transform _root;
	[SerializeField]
	private Transform _rootView;
	[SerializeField]
	private Animator _animator;
	[SerializeField]
	private AnimatorDispatcher _dispatcher;
	[SerializeField]
	private AudioSource _audioSource;
	[SerializeField]
	private ParticleSystem _damageVFX;

	public override void Install(IEntity entity)
	{
		entity.AddRoot(_root);
		entity.AddRootView(_rootView);
		entity.AddMoveSpeed(_moveSpeed);
		entity.AddInputDir(Vector2.zero);
		entity.AddRotationSpeed(_rotationSpeed);
		entity.AddLookTarget(new Vector3());
		entity.AddBullets(_maxBullets);
		entity.AddMaxBullets(_maxBullets);
		entity.AddHitPoints(_health);
		entity.AddIsShooting(false);
		entity.AddShootingCooldown(_shootingCooldown);
		entity.AddIsShootingPressed(false);
		entity.AddKills(0);
		entity.AddAnimator(_animator);
		entity.AddAnimatorDispatcher(_dispatcher);
		entity.AddDamageRequest(new BaseEvent<int>());
		entity.AddDamageVFX(_damageVFX);
		entity.AddDamageSFX(_audioSource);

		entity.AddBehaviour(new MoveToPlayerInputBehaviour());
		entity.AddBehaviour(new RotationBehaviour());
		entity.AddBehaviour(new WeaponBehaviour());
		entity.AddBehaviour(new TakeDamageRequestBehaviour());
		entity.AddBehaviour(new DamageVFXRequestBehaviour());
		entity.AddBehaviour(new DamageSFXRequestBehaviour());

		var bulletReloadTimer = new Timer(_bulletReloadTime, true);
		bulletReloadTimer.OnEnded += () =>
		{
			if (entity.GetBullets().Value >= entity.GetMaxBullets())
				return;

			entity.GetBullets().Value++;
		};
		
		entity.WhenUpdate(bulletReloadTimer.Tick);
		bulletReloadTimer.Play();
	}
}
}