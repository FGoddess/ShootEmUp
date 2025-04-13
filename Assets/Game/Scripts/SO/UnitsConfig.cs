using System.Collections.Generic;
using Sirenix.OdinInspector;
using Types;
using UnityEngine;
using Views;

namespace SO
{
[CreateAssetMenu(menuName = "UnitsConfig", fileName = "UnitsConfig")]
public class UnitsConfig : SerializedScriptableObject
{
	public Dictionary<(EUnitType, ETeamColor), UnitView> UnitsPrefabs;
}
}