using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Configs
{
[CreateAssetMenu(menuName = "ConfigCharacter", fileName = "ConfigCharacter")]
public class ConfigCharacter : SerializedScriptableObject
{
	[field: SerializeField]
	public string Nickname { get; private set; }
	[field: SerializeField]
	public string Description { get; private set; }
	[field: SerializeField]
	public Sprite Icon { get; private set; }

	[ShowInInspector]
	[SerializeField]
	public Dictionary<string, int> StatsToValue { get; private set; } = new();
}
}