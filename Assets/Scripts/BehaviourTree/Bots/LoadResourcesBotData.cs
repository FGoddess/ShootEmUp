using BehaviourTree.Zones;
using MBT;
using UnityEngine;
using Zenject;

namespace BehaviourTree.Bots
{
public class LoadResourcesBotData : MonoBehaviour
{
	[SerializeField] private float         _collectTime = 2f;
	[SerializeField] private BoolReference _hasCargo;

	private Bot             _bot;
	private ZonesController _zonesController;

	private float    _waitUntilTime;
	private bool     _isInZone;
	private LoadZone _targetZone;


	[Inject]
	public void Construct(ZonesController zonesController, Bot bot)
	{
		_zonesController = zonesController;
		_bot             = bot;
	}

	public void UpdateFromNode()
	{
		if (_isInZone)
			WaitForCollect();
		else
			MoveToZone();
	}

	private void MoveToZone()
	{
		if (_targetZone == null)
			_targetZone = _zonesController.GetLoadZoneWithTree();

		_bot.PlayerMover.DoMove(_targetZone.InteractPos);

		var dist = _targetZone.InteractPos.position - transform.position;

		if (dist.sqrMagnitude > 0.1f)
			return;

		Debug.Log($"Collecting from {_targetZone.name}");
		_isInZone      = true;
		_waitUntilTime = _collectTime + Time.time;
	}

	private void WaitForCollect()
	{
		if (_waitUntilTime > Time.time)
			return;

		Debug.Log($"Collected from {_targetZone.name}");
		_targetZone.InteractWithBot(_bot.ResourcesStorage);
		_hasCargo.Value = true;
		_targetZone     = null;
		_isInZone       = false;
	}
}
}