using System;
using Character;
using Components;
using ShootEmUp;
using UnityEngine;

namespace Enemy.Agents
{
public class EnemyAgent : MonoBehaviour
{
	[SerializeField] private MoveComponent      _moveComponent;
	[SerializeField] private WeaponComponent    weaponComponent;
	[SerializeField] private HitPointsComponent _hitPointsComponent;
	[SerializeField] private float              countdown;


	public event Action<Vector2, Vector2> Fired;
	public event Action<EnemyAgent>       Died;


	private Vector2 _destination;
	private bool    _isReached;

	private CharacterTemp _target;
	private float         _currentTime;

	private const float DESTINATION_TOLERANCE = 0.25f;


	private void OnEnable()
	{
		_hitPointsComponent.HpEmpty += OnDied;
	}

	private void OnDied()
	{
		Died?.Invoke(this);
	}

	public void SetDestination(Vector2 endPoint)
	{
		_destination = endPoint;
		_isReached   = false;
	}

	private void FixedUpdate()
	{
		if (_isReached)
			UpdateAttack();
		else
			UpdateMove();
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


	public void SetTarget(CharacterTemp target)
	{
		_target = target;
	}

	public void Reset()
	{
		_currentTime = countdown;
	}

	private void UpdateAttack()
	{
		if (!_target.IsHitPointsExists)
			return;

		_currentTime -= Time.fixedDeltaTime;
		if (_currentTime <= 0)
		{
			Fire();
			_currentTime += countdown;
		}
	}

	private void Fire()
	{
		var startPosition = weaponComponent.Position;
		var vector        = (Vector2)_target.transform.position - startPosition;
		var direction     = vector.normalized;
		Fired?.Invoke(startPosition, direction);
	}
}
}