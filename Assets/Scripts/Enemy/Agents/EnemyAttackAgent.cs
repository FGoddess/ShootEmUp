using Components;
using UnityEngine;

namespace Enemy.Agents
{
public class EnemyAttackAgent : MonoBehaviour
{
	[SerializeField]
	private WeaponComponent _weaponComponent;
	[SerializeField]
	private float _cooldown = 2;

	private HitPointsComponent _target;

	private float _currentTime;

	public WeaponComponent WeaponComponent => _weaponComponent;

	
	public void SetTarget(HitPointsComponent target)
	{
		_target = target;
	}
	
	public void UpdateAttack()
	{
		if (!_target.IsHitPointsExists())
			return;

		_currentTime -= Time.fixedDeltaTime;
		if (_currentTime <= 0)
		{
			Fire();
			_currentTime = _cooldown;
		}
	}
	
	private void Fire()
	{
		var vector = (Vector2)_target.transform.position - _weaponComponent.Position;
		_weaponComponent.Fire(vector.normalized);
	}
}
}