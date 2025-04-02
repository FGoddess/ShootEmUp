using Atomic.Entities;
using UnityEngine;

namespace Player
{
public class WeaponBehaviour : IEntityInit, IEntityUpdate
{
	private Transform _root;

	private const float ShootingCooldown = 0.5f;

	private readonly int _state = Animator.StringToHash("State");


	public void Init(IEntity entity)
	{
		_root = entity.GetRootView();

		var animator   = entity.GetAnimator();
		var isShooting = entity.GetIsShootingPressed();

		isShooting.Subscribe(isPress =>
		{
			if (isPress)
			{
				animator.SetFloat(_state, 3f);
				entity.SetIsShooting(true);
			}
			else
			{
				animator.SetFloat(_state, 0f);
				entity.SetIsShooting(false);
			}
		});
	}

	public void OnUpdate(IEntity entity, float deltaTime)
	{
		UpdateCooldown(entity, deltaTime);
		UpdateShooting(entity);
	}

	private static void UpdateCooldown(IEntity entity, float deltaTime)
	{
		float cooldown = entity.GetShootingCooldown();

		if (cooldown <= 0f)
			return;

		entity.SetShootingCooldown(cooldown - deltaTime);
	}

	private void UpdateShooting(IEntity entity)
	{
		if (!entity.GetIsShootingPressed().Value)
			return;
		if (entity.GetShootingCooldown() > 0f)
			return;

		entity.SetIsShooting(true);

		if (entity.GetBullets().Value <= 0)
			return;

		entity.GetBullets().Value -= 1;
		entity.SetShootingCooldown(ShootingCooldown);

		if (!Physics.Raycast(new Ray(_root.position, _root.forward), out var hit, float.MaxValue))
			return;
		if (!hit.collider.TryGetComponent(out SceneEntityProxy enemyEntity))
			return;

		entity.GetKills().Value += 1;
		enemyEntity.GetDamageRequest()?.Invoke(1);
	}
}
}