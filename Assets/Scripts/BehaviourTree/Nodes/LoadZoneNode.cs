using BehaviourTree.Bots;
using MBT;
using UnityEngine;

namespace BehaviourTree.Nodes
{
[MBTNode("BotAction/LoadZone")]
public class LoadZoneNode : Leaf
{
	[SerializeField]
	private TransformReference _botTransform;
	[SerializeField]
	private BoolReference _hasCargo;

	public override NodeResult Execute()
	{
		if (!_botTransform.Value.TryGetComponent(out LoadResourcesBotData collectResourcesData))
			return NodeResult.failure;

		if (_hasCargo.Value)
			return NodeResult.success;

		collectResourcesData.UpdateFromNode();
		return NodeResult.running;
	}
}
}