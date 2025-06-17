using System;
using BehaviourTree.Bots;
using MBT;
using UnityEngine;

namespace BehaviourTree.Zones
{
public class ZonesController : MonoBehaviour
{
	[SerializeField]
	private Bot _bot;
	[SerializeField]
	private BoolReference _hasTree;

	[SerializeField]
	private LoadZone[] _loadZones;
	[SerializeField]
	private UnloadZone _unloadZone;

	public LoadZone[] LoadZones  => _loadZones;
	public UnloadZone UnloadZone => _unloadZone;


	public void OnTreeTaken()
	{
		foreach (var loadZone in _loadZones)
		{
			if (loadZone.IsRegrowing)
				continue;

			_hasTree.Value = true;
			return;
		}

		_hasTree.Value = false;
	}

	public void OnTreeGrown()
	{
		_hasTree.Value = true;
	}

	public LoadZone GetLoadZoneWithTree()
	{
		foreach (var zone in _loadZones)
		{
			if (zone.IsRegrowing)
				continue;

			return zone;
		}

		throw new Exception("LoadZone with trees not found");
	}
}
}