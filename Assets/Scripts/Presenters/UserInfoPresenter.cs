using System;
using Models;
using Presenters.Interfaces;
using UnityEngine;
using Views;

namespace Presenters
{
public class UserInfoPresenter : IUserInfoPresenter, IDisposable
{
	public string Nickname    { get; }
	public string Description { get; }
	public Sprite Icon        { get; }


	private readonly UserInfo     _userInfo;
	private readonly UserInfoView _view;

	public UserInfoPresenter(UserInfo userInfo, UserInfoView view)
	{
		_userInfo = userInfo;
		_view     = view;

		Nickname    = userInfo.Name;
		Description = userInfo.Description;
		Icon        = userInfo.Icon;

		userInfo.OnNameChanged        += HandleNicknameChanged;
		userInfo.OnDescriptionChanged += HandleDescriptionChanged;
		userInfo.OnIconChanged        += HandleIconChanged;
	}

	private void HandleNicknameChanged(string nickname)
	{
		_view.ChangeNickname(nickname);
	}

	private void HandleDescriptionChanged(string description)
	{
		_view.ChangeDescription(description);
	}

	private void HandleIconChanged(Sprite icon)
	{
		_view.ChangeIcon(icon);
	}

	public void Dispose()
	{
		_userInfo.OnNameChanged        -= HandleNicknameChanged;
		_userInfo.OnDescriptionChanged -= HandleDescriptionChanged;
		_userInfo.OnIconChanged        -= HandleIconChanged;
	}
}
}