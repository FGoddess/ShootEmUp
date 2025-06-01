using System;
using UnityEngine;

namespace Configs
{
[Serializable]
public class ProduceTimeUpgradesConfig
{
	public float[] TimeByIdx;

	public float GetTime(int level)
	{
		level = Mathf.Clamp(level - 1, 0, TimeByIdx.Length - 1);
		return TimeByIdx[level];
	}
}
}