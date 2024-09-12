using System;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Models
{
[Serializable]
public sealed class UserInfo
{
	[ShowInInspector] [ReadOnly]
	public ReactiveProperty<string> Name { get; private set; }

	[ShowInInspector] [ReadOnly]
	public ReactiveProperty<string> Description { get; private set; }

	[ShowInInspector] [ReadOnly]
	public ReactiveProperty<Sprite> Icon { get; private set; }

	public UserInfo(string name, string description, Sprite icon)
	{
		Name        = new ReactiveProperty<string>(name);
		Description = new ReactiveProperty<string>(description);
		Icon        = new ReactiveProperty<Sprite>(icon);
	}

	[Button]
	public void ChangeName(string name)
	{
		Name.Value = name;
	}

	[Button]
	public void ChangeDescription(string description)
	{
		Description.Value = description;
	}

	[Button]
	public void ChangeIcon(Sprite icon)
	{
		Icon.Value = icon;
	}
}
}