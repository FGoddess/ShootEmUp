using System;
using Presenters.Interfaces;
using TMPro;
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

	public void Show(IPresenter presenter)
	{
		if (presenter is not IUserInfoPresenter userInfoPresenter)
			throw new ArgumentException("CharacterPopup must implement ICharacterPresenter");


		_nickname.text    = "@" + userInfoPresenter.Nickname;
		_description.text = userInfoPresenter.Description;
		_icon.sprite      = userInfoPresenter.Icon;
	}

	public void ChangeNickname(string nickname)
	{
		_nickname.text = nickname;
	}

	public void ChangeDescription(string description)
	{
		_description.text = description;
	}

	public void ChangeIcon(Sprite icon)
	{
		_icon.sprite = icon;
	}
}
}