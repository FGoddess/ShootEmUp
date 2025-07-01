using System;
using DI.Contexts;
using Money;
using Rewards.Interfaces;

namespace Rewards
{
[Serializable]
public struct SoftMoneyReward : IReward
{
	public int SoftMoneyAmount;

	public void Apply(IServicesContext servicesContext)
	{
		var moneyService = servicesContext.GetService<MoneyService>();
		moneyService.ChangeSoft(SoftMoneyAmount);
	}

	public string GetDescription()
	{
		return $"Мягкая валюта: {SoftMoneyAmount}";
	}
}
}