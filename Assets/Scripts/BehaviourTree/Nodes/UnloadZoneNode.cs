using System;
using BehaviourTree.Bots;
using MBT;
using UnityEngine;

namespace BehaviourTree.Nodes
{
[MBTNode("BotAction/UnloadZone")]
public class UnloadZoneNode : Leaf
{
	[SerializeField]
	private TransformReference _botTransform;
	[SerializeField]
	private BoolReference _hasCargo;


	public override NodeResult Execute()
	{
		if (!_botTransform.Value.TryGetComponent(out UnloadResourcesBotData unloadResourcesBotData))
			return NodeResult.failure;

		if (!_hasCargo.Value)
			return NodeResult.success;

		unloadResourcesBotData.UpdateFromNode();
		return NodeResult.running;
	}
}
}