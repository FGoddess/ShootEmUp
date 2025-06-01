using System;
using UnityEngine;
using Upgrades;

namespace Configs
{
[CreateAssetMenu(menuName = "Upgrades/ProduceTimeConfig", fileName = "ProduceTimeConfig", order = 0)]
public class ProduceTimeConfig : UpgradeConfig
{
	public override EStatType Type => EStatType.ProduceTime;

	public ProduceTimeUpgradesConfig ProduceTimeUpgradesConfig;

	public override UpgradeBase GetNewUpgrade()
	{
		return new ProduceTimeUpgrade(this);
	}

	private void OnValidate()
	{
		if(ProduceTimeUpgradesConfig.TimeByIdx.Length != PricesByIdx.Length)
			Debug.LogError("TimeByIdx.Length != PricesByIdx.Length");
	}
}
}