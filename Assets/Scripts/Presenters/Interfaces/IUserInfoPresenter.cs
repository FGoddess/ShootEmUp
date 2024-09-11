using System;
using UnityEngine;

namespace Presenters.Interfaces
{
public interface IUserInfoPresenter : IPresenter
{
	public string Nickname    { get; }
	public string Description { get; }
	public Sprite Icon        { get; }
}
}