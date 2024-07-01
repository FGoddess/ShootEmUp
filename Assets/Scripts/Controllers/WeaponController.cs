using System;
using Bullets;
using Common;
using Components;
using UnityEngine;

namespace Controllers
{
public class WeaponController : MonoBehaviour, IGameResumeListener, IGamePauseListener
{
	[SerializeField]
	private WeaponComponent _weaponComponent;
	[SerializeField]
	private BulletSetupSystem _bulletSystem;

	
	public void OnResume()
	{
		_weaponComponent.Fired += _bulletSystem.OnCharacterFired;
	}

	public void OnPause()
	{
		_weaponComponent.Fired -= _bulletSystem.OnCharacterFired;
	}
}
}