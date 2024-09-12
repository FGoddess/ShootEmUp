using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Configs
{
[CreateAssetMenu(menuName = "ConfigCharacters", fileName = "ConfigCharacters")]
public class ConfigCharacters : SerializedScriptableObject
{
	[field: SerializeField]
	public List<ConfigCharacter> Characters { get; private set; }
}
}