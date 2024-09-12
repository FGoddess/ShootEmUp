using System;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Models
{
[Serializable]
public sealed class PlayerLevel
{
	[ShowInInspector] [ReadOnly]
	public ReactiveProperty<int> CurrentLevel { get; private set; } = new(1);

	[ShowInInspector] [ReadOnly]
	public ReactiveProperty<int> CurrentExperience { get; private set; } = new(0);

	[ShowInInspector] [ReadOnly]
	public IReadOnlyReactiveProperty<int> RequiredExperience { get; private set; }
	[ShowInInspector] [ReadOnly]
	public IReadOnlyReactiveProperty<bool> CanLevelUp { get; private set; }

	public PlayerLevel()
	{
		RequiredExperience = CurrentLevel
		                     .Select(level => 100 * (level + 1))
		                     .ToReactiveProperty();

		CanLevelUp = CurrentExperience.CombineLatest(RequiredExperience, (current, required) => current == required)
		                              .ToReactiveProperty();
	}

	[Button]
	public void AddExperience(int range)
	{
		int xp = Math.Min(CurrentExperience.Value + range, RequiredExperience.Value);
		CurrentExperience.SetValueAndForceNotify(xp);
	}

	[Button]
	public void LevelUp()
	{
		if (!CanLevelUp.Value)
			return;

		CurrentExperience.SetValueAndForceNotify(0);
		CurrentLevel.SetValueAndForceNotify(CurrentLevel.Value + 1);
	}
}
}