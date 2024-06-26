﻿using System;
using Components;
using UnityEngine;

namespace Enemy.Agents
{
public class EnemyAgent : MonoBehaviour
{
	[SerializeField]
	private EnemyAttackAgent _attackAgent;
	[SerializeField]
	private EnemyMoveAgent _moveAgent;
	[SerializeField]
	private HitPointsComponent _hitPointsComponent;
	
	public event Action<EnemyAgent> Died;

	public EnemyAttackAgent AttackAgent => _attackAgent;

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
		if (_moveAgent.IsReached)
			_attackAgent.UpdateAttack();
		else
			_moveAgent.UpdateMove();
	}
	
	private void OnDied()
	{
		Died?.Invoke(this);
	}

	public void SetDestination(Vector3 attackPos)
	{
		_moveAgent.SetDestination(attackPos);
	}

	public void SetTarget(HitPointsComponent target)
	{
		_attackAgent.SetTarget(target);
	}
}
}