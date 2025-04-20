using Configs;
using Factory;
using Systems;
using Systems.Features;
using UnityEngine;
using Views;

public class GameStartup : MonoBehaviour
{
	[SerializeField]
	private ArrowView _arrowPrefab;

	[Header("Конфиги")]
	[SerializeField]
	private UnitsConfig _unitsConfig;
	[SerializeField]
	private BasesConfig _basesConfig;

	[Header("Контейнеры")]
	[SerializeField]
	private Transform _unitsContainer;
	[SerializeField]
	private Transform _basesContainer;
	[SerializeField]
	private Transform _arrowsContainer;

	private CreateSystems _createSystems;
	private RootSystems   _rootSystems;

	private void Start()
	{
		var unitFactory  = new UnitViewFactory(Contexts.sharedInstance, _unitsConfig, _unitsContainer);
		var baseFactory  = new BaseViewFactory(Contexts.sharedInstance, _basesConfig, _basesContainer);
		var arrowFactory = new ArrowViewFactory(Contexts.sharedInstance, _arrowPrefab, _arrowsContainer);

		_createSystems = new CreateSystems(
			Contexts.sharedInstance,
			unitFactory,
			baseFactory,
			arrowFactory
		);

		_rootSystems = new RootSystems(Contexts.sharedInstance);

		_createSystems.Initialize();
		_rootSystems.Initialize();
	}

	private void Update()
	{
		_rootSystems.Execute();
		_createSystems.Execute();
		_rootSystems.Cleanup();
	}
}