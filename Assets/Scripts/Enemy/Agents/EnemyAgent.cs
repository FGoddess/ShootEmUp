using System;
using Character;
using Components;
using UnityEngine;

namespace Enemy.Agents
{
public class EnemyAgent : MonoBehaviour
{
	[SerializeField]
	private MoveComponent _moveComponent;
	[SerializeField]
	private WeaponComponent _weaponComponent;
	[SerializeField]
	private HitPointsComponent _hitPointsComponent;
	[SerializeField]
	private float _cooldown;
	
	
	public event Action<EnemyAgent> Died;

	private Vector2 _destination;
	private bool    _isReached;

	private HitPointsComponent _target;
	private float              _currentTime;

	private const float DESTINATION_TOLERANCE = 0.25f;

	public WeaponComponent WeaponComponent => _weaponComponent;
	
	
	private void OnEnable()
	{
		_hitPointsComponent.HpEmpty += OnDied;
	}

	private void OnDisable()
	{
		_hitPointsComponent.HpEmpty += OnDied;
	}

	private void FixedUpdate()
	{
		if (_isReached)
			UpdateAttack();
		else
			UpdateMove();
	}

	public void SetTarget(HitPointsComponent target)
	{
		_target = target;
	}

	public void SetDestination(Vector2 endPoint)
	{
		_destination = endPoint;
		_isReached   = false;
	}

	public void Reset()
	{
		_currentTime = _cooldown;
	}

	private void UpdateAttack()
	{
		if (!_target.IsHitPointsExists())
			return;

		_currentTime -= Time.fixedDeltaTime;
		if (_currentTime <= 0)
		{
			Fire();
			_currentTime += _cooldown;
		}
	}

	private void UpdateMove()
	{
		var vector = _destination - (Vector2)transform.position;
		if (vector.magnitude <= DESTINATION_TOLERANCE)
		{
			_isReached = true;
			return;
		}

		var direction = vector.normalized;
		_moveComponent.MoveByRigidbodyVelocity(direction);
	}

	private void Fire()
	{
		var vector = (Vector2)_target.transform.position - _weaponComponent.Position;
		_weaponComponent.Fire(vector.normalized);
	}

	private void OnDied()
	{
		Died?.Invoke(this);
	}
}
}