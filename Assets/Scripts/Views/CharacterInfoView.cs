using System;
using Presenters.Interfaces;
using TMPro;
using UnityEngine;

namespace Views
{
public class CharacterInfoView : MonoBehaviour
{
	[SerializeField]
	private TMP_Text[] _stats;


	public void Show(IPresenter presenter)
	{
		if (presenter is not ICharacterInfoPresenter characterInfoPresenter)
			throw new ArgumentException("CharacterPopup must implement ICharacterPresenter");

		/*if (_stats.Length != characterInfoPresenter.Stats.Length)
			throw new ArgumentException("CharacterPopup must have the same number of stats");
		
		for (var i = 0; i < _stats.Length; i++)
			_stats[i].text = $"{characterInfoPresenter.Stats[i].Name}: {characterInfoPresenter.Stats[i].Value}";*/
	}

	public void Hide()
	{
		
	}
}
}