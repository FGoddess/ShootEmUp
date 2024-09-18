using System.Collections.Generic;
using GameEngine;
using SaveSystem.Repository;
using SaveSystem.SaveLoad;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SaveSystem.Helpers
{
public sealed class SavesHelper : MonoBehaviour
{
	[SerializeField]
	private Transform _unitsContainer;
	[SerializeField]
	private UnitManager _unitManager;
	[SerializeField]
	private ResourceService _resourceService;
	
	
	private ServiceContext    _serviceContext;
	private List<ISaveLoader> _saveLoaders;
	private IGameRepository   _gameRepository;
	

	[Inject]
	public void Construct(IGameRepository   gameRepository,
	                      List<ISaveLoader> saveLoaders,
	                      ServiceContext    serviceContext,
	                      UnitManager       unitManager,
	                      ResourceService   resourceService)
	{
		_gameRepository  = gameRepository;
		_saveLoaders     = saveLoaders;
		_serviceContext  = serviceContext;
		_unitManager     = unitManager;
		_resourceService = resourceService;
	}

	private void Start()
	{
		_unitManager.SetupUnits(FindObjectsOfType<Unit>());
		_resourceService.SetResources(FindObjectsOfType<Resource>());
		_unitManager.SetContainer(_unitsContainer);
	}

	[Button]
	private void SaveGame()
	{
		foreach (var saveLoader in _saveLoaders)
			saveLoader.SaveGame(_serviceContext, _gameRepository);

		_gameRepository.SaveState();
	}

	[Button]
	private void LoadGame()
	{
		foreach (var saveLoader in _saveLoaders)
			saveLoader.LoadGame(_serviceContext, _gameRepository);

		_gameRepository.LoadState();
	}
}
}