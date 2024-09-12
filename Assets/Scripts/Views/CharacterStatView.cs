using System;
using Presenters.Interfaces;
using TMPro;
using UniRx;
using UnityEngine;

namespace Views
{
public class CharacterStatView : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _statName;
	[SerializeField]
	private TMP_Text _statValue;
	
	private ICharacterStatPresenter _presenter;
	private IDisposable             _disposable;

	public ICharacterStatPresenter Presenter => _presenter;


	public void Show(IPresenter presenter)
	{
		if (presenter is not ICharacterStatPresenter characterStatPresenter)
			throw new ArgumentException("CharacterPopup must implement ICharacterPresenter");

		_presenter = characterStatPresenter;

		SetName(_presenter.Name);
		_disposable = _presenter.Value.Subscribe(SetValue);
	}

	private void SetName(string statName)
	{
		_statName.text = $"{statName}:";
	}

	private void SetValue(int statValue)
	{
		_statValue.text = $"{statValue}";
	}

	public void Hide()
	{
		_disposable.Dispose();
	}
}
}