using Configs;
using Factory;
using Sirenix.OdinInspector;
using Systems;
using UnityEngine;

public class GameStartup : SerializedMonoBehaviour
{
	[SerializeField]
	private UnitsConfig _unitsConfig;
	[SerializeField]
	private BasesConfig _basesConfig;

	private RootSystems _rootSystems;

	private void Start()
	{
		var unitFactory = new UnitViewFactory(Contexts.sharedInstance, _unitsConfig);
		var baseFactory = new BaseViewFactory(Contexts.sharedInstance, _basesConfig);

		_rootSystems = new RootSystems(Contexts.sharedInstance, unitFactory, baseFactory);

		_rootSystems.Initialize();
	}

	private void Update()
	{
		_rootSystems.Execute();
	}
}