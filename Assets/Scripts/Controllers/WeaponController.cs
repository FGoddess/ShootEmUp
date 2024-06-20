using System;
using Bullets;
using Components;
using UnityEngine;

namespace Controllers
{
public class WeaponController : MonoBehaviour
{
	[SerializeField]
	private WeaponComponent _weaponComponent;
	[SerializeField]
	private BulletSetupSystem _bulletSystem;


	private void OnEnable()
	{
		_weaponComponent.Fired += _bulletSystem.OnCharacterFired;
	}

	private void OnDisable()
	{
		_weaponComponent.Fired -= _bulletSystem.OnCharacterFired;
	}
}
}