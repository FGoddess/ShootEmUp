using UnityEngine;
using Upgrades;

namespace Configs
{
[CreateAssetMenu(menuName = "Upgrades/LoadAreaConfig", fileName = "LoadAreaConfig")]
public class LoadAreaConfig : UpgradeConfig
{
	public override EStatType Type => EStatType.LoadArea;

	public AreaUpgradesConfig AreaUpgradesConfig;

	public override UpgradeBase GetNewUpgrade()
	{
		return new LoadAreaUpgrade(this);
	}

	private void OnValidate()
	{
		if (AreaUpgradesConfig.CapacityByIdx.Length != PricesByIdx.Length)
			Debug.LogError("CapacityByIdx.Length != PricesByIdx.Length");
	}
}
}