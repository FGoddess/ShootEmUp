using BehaviourTree.Resource;
using UnityEngine;

namespace BehaviourTree.Zones
{
public class UnloadZone : ResourceZone
{
	private readonly ResourcesStorage _resourcesStorage = new();

	public override void InteractWithBot(ResourcesStorage botStorage)
	{
		_resourcesStorage.Change(botStorage.Value);
		botStorage.Set(0);

		Debug.Log($"UnloadZone Resources = {_resourcesStorage.Value}");
	}
}
}