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
	public Dictionary<(EUnitType, ETeamColor), UnitData> UnitsDataMap;

	[Serializable]
	public class UnitData
	{
		public UnitView ViewPrefab;
		public Vector2  MinSpawnPosRange;
		public Vector2  MaxSpawnPosRange;
		public int      Health;
		public int      AttackRange;
		public float    AttackCooldown;
		public float    SizeRadius;
		public float    MoveSpeed;
		public int      Damage;
	}
}
}