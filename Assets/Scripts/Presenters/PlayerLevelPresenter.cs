using System;
using Models;
using Presenters.Interfaces;
using UnityEngine;
using Views;

namespace Presenters
{
public class PlayerLevelPresenter : IPlayerLevelPresenter, IDisposable
{
	public int  Level              { get; }
	public int  CurrentExperience  { get; }
	public int  RequiredExperience { get; }
	public bool CanLevelUp         { get; }


	private readonly PlayerLevel     _playerLevel;
	private readonly PlayerLevelView _view;


	public PlayerLevelPresenter(PlayerLevel playerLevel, PlayerLevelView view)
	{
		_playerLevel = playerLevel;
		_view        = view;

		Level              = playerLevel.CurrentLevel;
		CurrentExperience  = playerLevel.CurrentExperience;
		RequiredExperience = playerLevel.RequiredExperience;
		CanLevelUp         = playerLevel.CanLevelUp();

		playerLevel.OnLevelUp           += OnLevelUp;
		playerLevel.OnExperienceChanged += OnExperienceChanged;
	}

	private void OnLevelUp()
	{
		_view.SetLevel(_playerLevel.CurrentLevel);
		OnExperienceChanged(_playerLevel.CurrentExperience);
	}

	private void OnExperienceChanged(int experience)
	{
		_view.SetExperienceChanged(experience, _playerLevel.RequiredExperience);
	}

	public void Dispose()
	{
		_playerLevel.OnLevelUp           -= OnLevelUp;
		_playerLevel.OnExperienceChanged -= OnExperienceChanged;
	}
}
}