using Atomic.Elements;
using Atomic.Entities;
using Common;
using Player;
using UnityEngine;

namespace Enemy
{
public class EnemyInstaller : SceneEntityInstallerBase
{
	[Header("Params")]
	[SerializeField]
	private float _moveSpeed = 2f;
	[SerializeField]
	private float _rotationSpeed = 10f;
	[SerializeField]
	private int _health = 1;
	
	[Header("Refs")]
	[SerializeField]
	private Transform _rootView;
	[SerializeField]
	private Animator _animator;
	[SerializeField]
	private AnimatorDispatcher _dispatcher;
	[SerializeField]
	private AudioSource _damageAudioSource;
	[SerializeField]
	private ParticleSystem _damageVFX;

	public override void Install(IEntity entity)
	{
		entity.AddRoot(transform);
		entity.AddRootView(_rootView);
		entity.AddMoveSpeed(_moveSpeed);
		entity.AddRotationSpeed(_rotationSpeed);
		entity.AddHitPoints(_health);
		entity.AddLookTarget(Vector3.zero);
		entity.AddAnimator(_animator);
		entity.AddAnimatorDispatcher(_dispatcher);
		entity.AddDamageRequest(new BaseEvent<int>());
		entity.AddDamageVFX(_damageVFX);
		entity.AddDamageSFX(_damageAudioSource);

		entity.AddBehaviour(new MoveToTargetBehaviour());
		entity.AddBehaviour(new RotationBehaviour());
		entity.AddBehaviour(new LookAtTargetBehaviour());
		entity.AddBehaviour(new AttackTargetBehaviour());
		entity.AddBehaviour(new EnemyKillBehaviour());
		entity.AddBehaviour(new DamageVFXRequestBehaviour());
		entity.AddBehaviour(new DamageSFXRequestBehaviour());
		entity.AddBehaviour(new TakeDamageRequestBehaviour());
	}
}
}