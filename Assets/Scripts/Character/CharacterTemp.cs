using System;
using Bullets;
using Components;
using ShootEmUp;
using UnityEngine;

namespace Character
{
public sealed class CharacterTemp : MonoBehaviour
{
	[SerializeField] private GameManager        _gameManager;
	[SerializeField] private BulletSystem       _bulletSystem;
	[SerializeField] private BulletConfig       _bulletConfig;
	[SerializeField] private HitPointsComponent _hitPointsComponent;
	[SerializeField] private WeaponComponent    _weaponComponent;
	
	public bool FireRequired      { get; private set; }
	public bool IsHitPointsExists => _hitPointsComponent.IsHitPointsExists();

	
	public event Action<Vector2, Vector2> Fired;
	

	private void OnEnable()
	{
		_hitPointsComponent.HpEmpty += OnCharacterDeath;
	}

	private void OnDisable()
	{
		_hitPointsComponent.HpEmpty -= OnCharacterDeath;
	}

	private void OnCharacterDeath()
	{
		_gameManager.FinishGame();
	}

	public void SetFireRequired()
	{
		FireRequired = true;
	}

	private void FixedUpdate()
	{
		if (!FireRequired)
			return;
		
		Fired?.Invoke(_weaponComponent.Position, _weaponComponent.Rotation * Vector3.up * _bulletConfig.speed);
		FireRequired = false;
	}
}
}