using Core.Events;
using UnityEngine;
using Zenject;

namespace Core.Tasks
{
public class SelectTargetTask : EventTask
{
	private readonly SignalBus _signalBus;
	
	public SelectTargetTask(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}
	
	protected override void OnStart()
	{
		Debug.Log("start SelectTargetTask");
		_signalBus.Fire<SelectTargetSignal>();
	}

	protected override void OnComplete()
	{
		Debug.Log("complete SelectTargetTask");
	}
}
}