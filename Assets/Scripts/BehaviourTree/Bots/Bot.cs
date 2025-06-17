using BehaviourTree.Resource;
using MBT;
using UnityEngine;

namespace BehaviourTree.Bots
{
public class Bot : MonoBehaviour
{
	[SerializeField]
	private PlayerMover _playerMover;

	private readonly ResourcesStorage _resourcesStorage = new();
	
	public PlayerMover           PlayerMover           => _playerMover;
	public ResourcesStorage ResourcesStorage => _resourcesStorage;
}
}