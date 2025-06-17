using BehaviourTree.Zones;
using MBT;
using UnityEngine;
using Zenject;

namespace BehaviourTree.Bots
{
public class UnloadResourcesBotData : MonoBehaviour
{
	[SerializeField] private BoolReference _hasCargo;

	private Bot        _bot;
	private UnloadZone _targetZone;


	[Inject]
	public void Construct(ZonesController zonesController, Bot bot)
	{
		_targetZone = zonesController.UnloadZone;
		_bot        = bot;
	}

	public void UpdateFromNode()
	{
		_bot.PlayerMover.DoMove(_targetZone.InteractPos);

		var dist = _targetZone.InteractPos.position - transform.position;

		if (dist.sqrMagnitude > 0.1f)
			return;

		_targetZone.InteractWithBot(_bot.ResourcesStorage);
		_hasCargo.Value = false;
	}
}
}