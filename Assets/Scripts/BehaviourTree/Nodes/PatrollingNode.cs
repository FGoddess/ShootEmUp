using BehaviourTree.Bots;
using MBT;
using UnityEngine;

namespace BehaviourTree.Nodes
{
[AddComponentMenu("")]
[MBTNode("BotAction/PatrollingNode")]
public class PatrollingNode : Leaf
{
	[SerializeField]
	private TransformReference _botTransform;

	public override NodeResult Execute()
	{
		if (!_botTransform.Value.TryGetComponent(out PatrollingData patrollingData))
			return NodeResult.failure;

		patrollingData.UpdateFromNode();
		return NodeResult.success;
	}
}
}