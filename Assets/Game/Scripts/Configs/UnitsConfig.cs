using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Types;
using UnityEngine;
using Views;

namespace Configs
{
[CreateAssetMenu(menuName = "UnitsConfig", fileName = "UnitsConfig")]
public class UnitsConfig : SerializedScriptableObject
{
	public Dictionary<(EUnitType, ETeamColor), UnitData> UnitsPrefabs;
	
	[Serializable]
	public class UnitData
	{
		public UnitView ViewPrefab;
		public Vector3  SpawnPosition;
	}
}
}