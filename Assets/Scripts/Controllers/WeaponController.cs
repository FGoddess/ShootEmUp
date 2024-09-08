using Bullets;
using Common;
using Components;
using UnityEngine;
using Zenject;

namespace Controllers
{
public class WeaponController : IGameResumeListener, IGamePauseListener
{
	private readonly WeaponComponent   _weaponComponent;
	private readonly BulletSetupSystem _bulletSetupSystem;

	public WeaponController(WeaponComponent weaponComponent, BulletSetupSystem bulletSetupSystem)
	{
		_weaponComponent   = weaponComponent;
		_bulletSetupSystem = bulletSetupSystem;
	}


	public void OnResume()
	{
		_weaponComponent.Fired += _bulletSetupSystem.OnCharacterFired;
	}

	public void OnPause()
	{
		_weaponComponent.Fired -= _bulletSetupSystem.OnCharacterFired;
	}
}
}