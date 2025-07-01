using System;
using DI.Contexts;
using Money;
using Rewards.Interfaces;

namespace Rewards
{
[Serializable]
public struct HardMoneyReward : IReward
{
	public int HardMoneyAmount;

	public void Apply(IServicesContext servicesContext)
	{
		var moneyService = servicesContext.GetService<MoneyService>();
		moneyService.ChangeHard(HardMoneyAmount);
	}

	public string GetDescription()
	{
		return $"Твёрдая валюта: {HardMoneyAmount}";
	}
}
}