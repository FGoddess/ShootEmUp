using Components;
using UnityEngine;
using Zenject;

namespace Character
{
public sealed class CharacterAgent
{
	private WeaponComponent _weaponComponent;

	[Inject]
	private void Construct(WeaponComponent weaponComponent)
	{
		_weaponComponent = weaponComponent;
	}

	public void SetFireRequired()
	{
		_weaponComponent.Fire(_weaponComponent.Rotation * Vector3.up);
	}
}
}