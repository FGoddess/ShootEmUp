using System;
using Sirenix.OdinInspector;
using UnityEngine;

public sealed class PlayerLevel : MonoBehaviour
{
	public event Action      OnLevelUp;
	public event Action<int> OnExperienceChanged;

	[ShowInInspector] [ReadOnly]
	public int CurrentLevel { get; private set; } = 1;

	[ShowInInspector] [ReadOnly]
	public int CurrentExperience { get; private set; }

	[ShowInInspector] [ReadOnly]
	public int RequiredExperience => 100 * (CurrentLevel + 1);

	[Button]
	public void AddExperience(int range)
	{
		int xp = Math.Min(CurrentExperience + range, RequiredExperience);
		CurrentExperience = xp;
		OnExperienceChanged?.Invoke(xp);
	}

	[Button]
	public void LevelUp()
	{
		if (CanLevelUp())
		{
			CurrentExperience = 0;
			CurrentLevel++;
			OnLevelUp?.Invoke();
		}
	}

	public bool CanLevelUp()
	{
		return CurrentExperience == RequiredExperience;
	}
}