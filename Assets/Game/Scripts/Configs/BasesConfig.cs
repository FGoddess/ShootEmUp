using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Types;
using UnityEngine;
using Views;

namespace Configs
{
[CreateAssetMenu(menuName = "BasesConfig", fileName = "BasesConfig")]
public class BasesConfig : SerializedScriptableObject
{
	public Dictionary<ETeamColor, BaseData> BasesPrefabs;

	[Serializable]
	public class BaseData
	{
		public BaseView ViewPrefab;
		public Vector3  SpawnPosition;
	}
}
}