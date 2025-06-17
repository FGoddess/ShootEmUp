using System.Collections;
using BehaviourTree.DI.Signals;
using BehaviourTree.Resource;
using UnityEngine;
using Zenject;

namespace BehaviourTree.Zones
{
public class LoadZone : ResourceZone
{
	[SerializeField]
	private Transform[] _trees;
	[SerializeField]
	private float _treeGrowthTime = 5f;

	public bool IsRegrowing { get; private set; }


	private SignalBus _signalBus;

	[Inject]
	public void Construct(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public override void InteractWithBot(ResourcesStorage botStorage)
	{
		foreach (var tree in _trees)
			tree.gameObject.SetActive(false);

		if (!IsRegrowing)
			StartCoroutine(RegrowTrees());

		botStorage.Set(_trees.Length);

		_signalBus.Fire<TreeCollectedSignal>();
	}

	private IEnumerator RegrowTrees()
	{
		IsRegrowing = true;

		yield return new WaitForSeconds(_treeGrowthTime);

		foreach (var tree in _trees)
			tree.gameObject.SetActive(true);

		IsRegrowing = false;

		_signalBus.Fire<TreeGrownSignal>();
	}
}
}