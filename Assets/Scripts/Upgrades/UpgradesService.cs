using System;
using System.Collections.Generic;
using Configs;
using Money;
using UnityEngine;
using Zenject;

namespace Upgrades
{
[Serializable]
public class UpgradesService
{
	private readonly MoneyService _moneyService;

	private readonly Dictionary<EStatType, UpgradeBase> _upgradesMap = new();

	[Inject]
	public UpgradesService(UpgradesConfig upgradesConfig, MoneyService moneyService, DiContainer diContainer)
	{
		_moneyService = moneyService;

		foreach (var upgradeConfig in upgradesConfig.Upgrades)
		{
			var upgrade = upgradeConfig.GetNewUpgrade();
			diContainer.Inject(upgrade);
			_upgradesMap.Add(upgrade.Type, upgrade);
		}
	}

	public bool TryUpgrade(EStatType type)
	{
		if (!_upgradesMap.TryGetValue(type, out var upgrade))
		{
			Debug.LogWarning($"There is no upgrade for {type}");
			return false;
		}

		if (!TryUpgrade(upgrade, out int price))
			return false;

		_moneyService.SpendMoney(price);
		upgrade.IncreaseLevel();

		return true;
	}

	private bool TryUpgrade(UpgradeBase upgrade, out int price)
	{
		price = default;

		if (upgrade.IsMaxLevel)
		{
			Debug.LogWarning($"{upgrade} - max level");
			return false;
		}

		price = upgrade.NextLevelPrice;

		if (!_moneyService.CanSpendMoney(price))
		{
			Debug.LogWarning($"Not enough money to purch {upgrade}, price = {price}!");
			return false;
		}

		return true;
	}
}
}