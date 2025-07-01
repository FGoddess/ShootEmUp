using System;
using DI.Contexts;
using Rewards.Interfaces;
using UnityEngine;

namespace Rewards
{
[Serializable]
public struct ArtifactReward : IReward
{
	public string ArtifactId;
	public string ArtifactName;

	public void Apply(IServicesContext servicesContext)
	{
		// Здесь был бы сервис артефакта
		Debug.Log($"Добавлен артефакт в инвентарь: {ArtifactName} (ID: {ArtifactId})");
	}

	public string GetDescription()
	{
		return $"Артефакт: {ArtifactName}";
	}
}
}