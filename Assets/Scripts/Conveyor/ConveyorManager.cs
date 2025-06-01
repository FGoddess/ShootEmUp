using Comps;
using UnityEngine;
using Zenject;

namespace Conveyor
{
public class ConveyorManager
{
	private readonly LoadAreaComp   _loadAreaComp;
	private readonly UnloadAreaComp _unloadAreaComp;
	private readonly ProduceTimeComp   _produceTimeComp;

	public ConveyorManager(LoadAreaComp loadAreaComp, UnloadAreaComp unloadAreaComp, ProduceTimeComp produceTimeComp)
	{
		_loadAreaComp   = loadAreaComp;
		_unloadAreaComp = unloadAreaComp;
		_produceTimeComp   = produceTimeComp;
	}

	public void DebugAllComps()
	{
		Debug.Log($"Load Area capacity: {_loadAreaComp.Value} units");
		Debug.Log($"Unload Area capacity: {_unloadAreaComp.Value} units");
		Debug.Log($"Produce Time: {_produceTimeComp.Value} secs");
	}
}
}