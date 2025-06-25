using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;

namespace SampleGame
{
[CreateAssetMenu(menuName = "LocationsConfig", fileName = "LocationsConfig")]
public class LocationsConfig : ScriptableObject
{
	[FormerlySerializedAs("LocationsReferences")] 
	public AssetReference[] LocationsReferencesById;
	
	public AssetReference BaseLocation;
}
}