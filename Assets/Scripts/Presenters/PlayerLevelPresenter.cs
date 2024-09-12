using System;
using Models;
using Presenters.Interfaces;
using UniRx;

namespace Presenters
{
public class PlayerLevelPresenter : IPlayerLevelPresenter, IDisposable
{
	public ReadOnlyReactiveProperty<int>  Level              { get; }
	public ReadOnlyReactiveProperty<int>  CurrentExperience  { get; }
	public ReadOnlyReactiveProperty<int>  RequiredExperience { get; }
	public ReadOnlyReactiveProperty<bool> CanLevelUp         { get; }
	public ReactiveCommand                LevelUpCommand     { get; }

	private readonly PlayerLevel _playerLevel;

	private readonly CompositeDisposable _disposables = new();


	public PlayerLevelPresenter(PlayerLevel playerLevel)
	{
		_playerLevel = playerLevel;

		Level              = new ReadOnlyReactiveProperty<int>(_playerLevel.CurrentLevel);
		CurrentExperience  = new ReadOnlyReactiveProperty<int>(_playerLevel.CurrentExperience);
		RequiredExperience = new ReadOnlyReactiveProperty<int>(_playerLevel.RequiredExperience);
		CanLevelUp         = new ReadOnlyReactiveProperty<bool>(_playerLevel.CanLevelUp);

		LevelUpCommand = new ReactiveCommand(CanLevelUp);
		LevelUpCommand.Subscribe(OnLevelUpCommand).AddTo(_disposables);
	}

	private void OnLevelUpCommand(Unit _)
	{
		LevelUp();
	}

	public void LevelUp()
	{
		_playerLevel.LevelUp();
	}

	public void Dispose()
	{
		_disposables.Dispose();
	}
}
}