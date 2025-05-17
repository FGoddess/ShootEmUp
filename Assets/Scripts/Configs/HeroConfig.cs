using UnityEngine;

namespace Configs
{
[CreateAssetMenu(menuName = "HeroConfig", fileName = "HeroConfig")]
public class HeroConfig : ScriptableObject
{
	public int MaxHealth;
	public int Damage;

	public Sprite Sprite;
}
}