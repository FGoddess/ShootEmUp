using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SampleGame
{
[CreateAssetMenu(menuName = "LocationsConfig", fileName = "LocationsConfig")]
public class LocationsConfig : ScriptableObject
{
	public AssetReference[] LocationsReferences;
}
}