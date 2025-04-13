using Factory;
using Sirenix.OdinInspector;
using SO;
using Systems;
using UnityEngine;

public class GameStartup : SerializedMonoBehaviour
{
	[SerializeField]
	private UnitsConfig _unitsConfig;

	private RootSystems _rootSystems;

	private void Start()
	{
		var unitFactory = new UnitUnitViewFactory(Contexts.sharedInstance, _unitsConfig.UnitsPrefabs);

		_rootSystems = new RootSystems(Contexts.sharedInstance, unitFactory);

		_rootSystems.Initialize();
	}

	private void Update()
	{
		_rootSystems.Execute();
	}
}