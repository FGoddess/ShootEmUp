using System;
using UnityEngine;

namespace Configs
{
[Serializable]
public class AreaUpgradesConfig
{
	public int[] CapacityByIdx;

	public int GetCapacity(int level)
	{
		level = Mathf.Clamp(level - 1, 0, CapacityByIdx.Length - 1);
		return CapacityByIdx[level];
	}
}
}