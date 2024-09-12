using System;
using Presenters.Interfaces;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Views
{
public class PlayerLevelView : MonoBehaviour
{
	[SerializeField]
	private LevelUpButton _levelUpButton;
	[SerializeField]
	private TMP_Text _level;
	[SerializeField]
	private TMP_Text _experience;
	[SerializeField]
	private Slider _experienceBar;
	[SerializeField]
	private Image _experienceBarFiller;

	[Space]
	[SerializeField]
	private Sprite _availableExperienceBar;
	[SerializeField]
	private Sprite _lockedExperienceBar;

	private          IPlayerLevelPresenter _presenter;
	private readonly CompositeDisposable   _disposables = new();

	public void Show(IPresenter presenter)
	{
		if (presenter is not IPlayerLevelPresenter characterPresenter)
			throw new ArgumentException("CharacterPopup must implement ICharacterPresenter");

		_presenter = characterPresenter;

		_presenter.Level.Subscribe(SetLevel).AddTo(_disposables);
		_presenter.CurrentExperience.Subscribe(SetExperienceChanged).AddTo(_disposables);
		_presenter.RequiredExperience.Subscribe(SetExperienceChanged).AddTo(_disposables);

		_presenter.LevelUpCommand.BindTo(_levelUpButton.Button).AddTo(_disposables);
	}

	private void SetLevel(int level)
	{
		_level.text = $"Level: {level}";
	}

	private void SetExperienceChanged(int _)
	{
		_experience.text     = $"XP: {_presenter.CurrentExperience}/{_presenter.RequiredExperience.Value}";
		_experienceBar.value = (float)_presenter.CurrentExperience.Value / _presenter.RequiredExperience.Value;
		_levelUpButton.SetAvailable(_presenter.CanLevelUp.Value);
		_experienceBarFiller.sprite = _presenter.CanLevelUp.Value ? _availableExperienceBar : _lockedExperienceBar;
	}

	public void Hide()
	{
		gameObject.SetActive(false);
		_levelUpButton.RemoveAllListeners();
		_disposables.Clear();
	}
}
}