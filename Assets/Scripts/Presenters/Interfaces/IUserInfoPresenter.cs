using System;
using UniRx;
using UnityEngine;

namespace Presenters.Interfaces
{
public interface IUserInfoPresenter : IPresenter
{
	public ReadOnlyReactiveProperty<string> Nickname    { get; }
	public ReadOnlyReactiveProperty<string> Description { get; }
	public ReadOnlyReactiveProperty<Sprite> Icon        { get; }
}
}