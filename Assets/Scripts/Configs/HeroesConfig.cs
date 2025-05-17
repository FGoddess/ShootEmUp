using UnityEngine;

namespace Configs
{
[CreateAssetMenu(menuName = "HeroesConfig", fileName = "HeroesConfig")]
public class HeroesConfig : ScriptableObject
{
	public HeroConfig[] BluePlayerConfigs;
	public HeroConfig[] RedPlayerConfigs;
}
}