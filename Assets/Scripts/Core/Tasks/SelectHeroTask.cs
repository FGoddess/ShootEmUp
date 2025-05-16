using Core.Events;
using UnityEngine;
using Zenject;

namespace Core.Tasks
{
public class SelectHeroTask : EventTask
{
	private SignalBus _signalBus;
	
	[Inject]
	private void Construct(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}
	
	protected override void OnStart()
	{
		Debug.Log("start");
		_signalBus.Fire<SelectHeroSignal>();
		//Complete();
	}

	protected override void OnComplete()
	{
		Debug.Log("complete");
	}
}
}