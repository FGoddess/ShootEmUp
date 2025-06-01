using UnityEngine;
using Upgrades;

namespace Configs
{
[CreateAssetMenu(menuName = "Upgrades/UnloadAreaConfig", fileName = "UnloadAreaConfig")]
public class UnloadAreaConfig : UpgradeConfig
{
	public override EStatType Type => EStatType.UnloadArea;

	public AreaUpgradesConfig AreaUpgradesConfig;
	
	public override UpgradeBase GetNewUpgrade()
	{
		return new UnloadAreaUpgrade(this);
	}
	
	private void OnValidate()
	{
		if (AreaUpgradesConfig.CapacityByIdx.Length != PricesByIdx.Length)
			Debug.LogError("CapacityByIdx.Length != PricesByIdx.Length");
	}
}
}