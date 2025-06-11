using Rewards.Interfaces;
using UnityEngine;

namespace Chests.Configs
{
[CreateAssetMenu(fileName = "ChestConfig", menuName = "Configs/Chest")]
public class ChestConfig : ScriptableObject
{
	public string Id;
	public string Name;
	public Sprite Icon;
	public float  OpenTimeMins;

	[SerializeReference] 
	public IReward[] Rewards;
}
}