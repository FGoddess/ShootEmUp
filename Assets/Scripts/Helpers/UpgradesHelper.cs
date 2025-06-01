using Conveyor;
using Sirenix.OdinInspector;
using UnityEngine;
using Upgrades;
using Zenject;

namespace Helpers
{
public class UpgradesHelper : MonoBehaviour
{
	private UpgradesService  _upgradesService;
	private ConveyorManager _conveyorManager;

	[Inject]
	public void Construct(UpgradesService upgradesService, ConveyorManager conveyorManager)
	{
		_upgradesService  = upgradesService;
		_conveyorManager = conveyorManager;
	}

	[Button]
	public void LevelUpLoadCapacity()
	{
		_upgradesService.TryUpgrade(EStatType.LoadArea);
	}

	[Button]
	public void LevelUpUnloadCapacity()
	{
		_upgradesService.TryUpgrade(EStatType.UnloadArea);
	}

	[Button]
	public void LevelUpProduceTime()
	{
		_upgradesService.TryUpgrade(EStatType.ProduceTime);
	}

	[Button]
	public void DebugAllComps()
	{
		_conveyorManager.DebugAllComps();
	}
}
}