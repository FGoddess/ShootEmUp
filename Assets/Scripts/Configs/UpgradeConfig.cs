using Sirenix.OdinInspector;
using UnityEngine;
using Upgrades;

namespace Configs
{
public abstract class UpgradeConfig : ScriptableObject
{
	public abstract EStatType Type { get; }

	public int[] PricesByIdx;

	public virtual int GetPrice(int level)
	{
		level = Mathf.Clamp(level - 1, 0, PricesByIdx.Length - 1);
		return PricesByIdx[level];
	}

	public abstract UpgradeBase GetNewUpgrade();
}
}