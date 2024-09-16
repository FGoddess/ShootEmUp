using Core;
using GameEngine;
using SaveSystem.Repository;
using SaveSystem.SaveLoad;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

//TODO: Удалить этот класс!
//Развернуть архитектуру на Zenject/VContainer/Custom
public sealed class EntryPoint : MonoBehaviour
{
	[SerializeField]
	[Inject]
	private UnitManager unitManager;

	[SerializeField]
	[Inject]
	private ResourceService resourceService;

	
	[Inject]
	private ResourceSaveLoader _resourceSaveLoader;
	[Inject]
	private UnitSaveLoader _unitSaveLoader;
	[Inject]
	private ServiceContext _serviceContext;
	[Inject]
	private GameRepository _gameRepository;

	private void Start()
	{
		unitManager.SetupUnits(FindObjectsOfType<Unit>());
		resourceService.SetResources(FindObjectsOfType<Resource>());
	}

	[Button]
	private void SaveRes()
	{
		_resourceSaveLoader.SaveGame(_serviceContext, _gameRepository);
		_unitSaveLoader.SaveGame(_serviceContext, _gameRepository);
		_gameRepository.SaveState();
	}

	[Button]
	private void LoadRes()
	{
		_gameRepository.LoadState();
		_resourceSaveLoader.LoadGame(_serviceContext, _gameRepository);
		_unitSaveLoader.LoadGame(_serviceContext, _gameRepository);
	}
	
	//[Button]
}