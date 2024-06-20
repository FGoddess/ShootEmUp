using System;
using UnityEngine;

namespace Components
{
public sealed class HitPointsComponent : MonoBehaviour
{
	[SerializeField] 
	private int _hitPoints;

	public event Action HpEmpty;


	public bool IsHitPointsExists()
	{
		return _hitPoints > 0;
	}

	public void TakeDamage(int damage)
	{
		_hitPoints -= damage;
		if (_hitPoints <= 0)
			HpEmpty?.Invoke();
	}
}
}