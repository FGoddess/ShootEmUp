using System;
using Models;
using Presenters.Interfaces;
using UniRx;
using UnityEngine;
using Views;

namespace Presenters
{
public class UserInfoPresenter : IUserInfoPresenter, IDisposable
{
	public ReadOnlyReactiveProperty<string> Nickname    { get; }
	public ReadOnlyReactiveProperty<string> Description { get; }
	public ReadOnlyReactiveProperty<Sprite> Icon        { get; }


	private readonly UserInfo _userInfo;

	public UserInfoPresenter(UserInfo userInfo)
	{
		_userInfo = userInfo;

		Nickname    = new ReadOnlyReactiveProperty<string>(userInfo.Name);
		Description = new ReadOnlyReactiveProperty<string>(userInfo.Description);
		Icon        = new ReadOnlyReactiveProperty<Sprite>(userInfo.Icon);
	}

	/*private void OnNicknameChanged(string nickname)
	{
		_view.ChangeNickname(nickname);
	}

	private void OnDescriptionChanged(string description)
	{
		_view.ChangeDescription(description);
	}

	private void OnIconChanged(Sprite icon)
	{
		_view.ChangeIcon(icon);
	}

	public void Dispose()
	{
		_userInfo.OnNameChanged        -= OnNicknameChanged;
		_userInfo.OnDescriptionChanged -= OnDescriptionChanged;
		_userInfo.OnIconChanged        -= OnIconChanged;
	}*/
	public void Dispose() { }
}
}