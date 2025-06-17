using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SampleGame
{
[CreateAssetMenu(menuName = "ScenesConfig", fileName = "ScenesConfig")]
public class ScenesConfig : ScriptableObject
{
	public AssetReference MenuScene;
	public AssetReference GameScene;
}
}