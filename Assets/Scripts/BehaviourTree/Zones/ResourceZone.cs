using BehaviourTree.Resource;
using UnityEngine;

namespace BehaviourTree.Zones
{
public abstract class ResourceZone : MonoBehaviour
{
	[SerializeField]
	protected Transform InteractPosition;

	public Transform InteractPos => InteractPosition;

	public abstract void InteractWithBot(ResourcesStorage botStorage);
}
}