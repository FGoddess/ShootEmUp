using Components;
using UnityEngine;
using Zenject;

namespace Conveyor
{
public class ConveyorManager
{
	private readonly LoadAreaComponent   _loadAreaComponent;
	private readonly UnloadAreaComponent _unloadAreaComponent;
	private readonly ProduceTimeComponent   _produceTimeComponent;

	public ConveyorManager(LoadAreaComponent loadAreaComponent, UnloadAreaComponent unloadAreaComponent, ProduceTimeComponent produceTimeComponent)
	{
		_loadAreaComponent   = loadAreaComponent;
		_unloadAreaComponent = unloadAreaComponent;
		_produceTimeComponent   = produceTimeComponent;
	}

	public void DebugAllComps()
	{
		Debug.Log($"Load Area capacity: {_loadAreaComponent.Value} units");
		Debug.Log($"Unload Area capacity: {_unloadAreaComponent.Value} units");
		Debug.Log($"Produce Time: {_produceTimeComponent.Value} secs");
	}
}
}