using System;
using DI.Contexts;
using Rewards.Interfaces;
using UnityEngine;

namespace Rewards
{
[Serializable]
public struct ExperienceReward : IReward
{
	public int ExperienceAmount;

	public void Apply(IServicesContext servicesContext)
	{
		// Здесь был бы сервис опыта
		Debug.Log($"Получен опыт: {ExperienceAmount} XP");
	}

	public string GetDescription()
	{
		return $"Опыт: {ExperienceAmount} XP";
	}
}
} 