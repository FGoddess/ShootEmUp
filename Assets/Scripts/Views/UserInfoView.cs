using System;
using Presenters.Interfaces;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
public class UserInfoView : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _nickname;
	[SerializeField]
	private TMP_Text _description;
	[SerializeField]
	private Image _icon;

	private          IUserInfoPresenter  _userInfoPresenter;
	private readonly CompositeDisposable _disposables = new();


	public void Show(IPresenter presenter)
	{
		if (presenter is not IUserInfoPresenter userInfoPresenter)
			throw new ArgumentException("CharacterPopup must implement ICharacterPresenter");

		_userInfoPresenter = userInfoPresenter;

		_userInfoPresenter.Nickname.Subscribe(ChangeNickname).AddTo(_disposables);
		_userInfoPresenter.Description.Subscribe(ChangeDescription).AddTo(_disposables);
		_userInfoPresenter.Icon.Subscribe(ChangeIcon).AddTo(_disposables);
	}

	private void ChangeNickname(string nickname)
	{
		_nickname.text = "@" + nickname;
	}

	private void ChangeDescription(string description)
	{
		_description.text = description;
	}

	private void ChangeIcon(Sprite icon)
	{
		_icon.sprite = icon;
	}

	public void Hide()
	{
		gameObject.SetActive(false);
		_disposables.Clear();
	}
}
}