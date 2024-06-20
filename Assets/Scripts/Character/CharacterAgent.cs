using System;
using Components;
using UnityEngine;

namespace Character
{
public sealed class CharacterAgent : MonoBehaviour
{
	[SerializeField]
	private WeaponComponent _weaponComponent;
	
	
	public void SetFireRequired()
	{
		_weaponComponent.Fire(_weaponComponent.Rotation * Vector3.up);
	}
}
}