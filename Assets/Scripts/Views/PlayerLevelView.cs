using System;
using Presenters.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
public class PlayerLevelView : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _level;
	[SerializeField]
	private TMP_Text _xp;
	[SerializeField]
	private Slider _slider;

	public void Show(IPresenter presenter)
	{
		if (presenter is not IPlayerLevelPresenter characterPresenter)
			throw new ArgumentException("CharacterPopup must implement ICharacterPresenter");

		SetLevel(characterPresenter.Level);
		SetExperienceChanged(characterPresenter.CurrentExperience, characterPresenter.RequiredExperience);
	}

	public void SetLevel(int level)
	{
		_level.text = $"Level: {level}";
	}

	public void SetExperienceChanged(int currExperience, int requiredExperience)
	{
		_xp.text      = $"XP: {currExperience}/{requiredExperience}";
		_slider.value = (float)currExperience / requiredExperience;
	}
}
}