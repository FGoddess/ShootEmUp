using System;
using System.Collections.Generic;
using DI.Contexts;
using SaveSystem.Repository;
using Zenject;

namespace SaveSystem.SaveLoad
{
public class SaveLoadingController : IInitializable, IDisposable
{
	private readonly GameRepository    _gameRepository;
	private readonly ServicesContext   _servicesContext;
	private readonly List<ISaveLoader> _saveLoaders;

	public SaveLoadingController(GameRepository gameRepository, ServicesContext servicesContext, List<ISaveLoader> saveLoaders)
	{
		_gameRepository  = gameRepository;
		_servicesContext = servicesContext;
		_saveLoaders     = saveLoaders;
	}

	public void Load()
	{
		_gameRepository.LoadState();

		foreach (var saveLoader in _saveLoaders)
			saveLoader.LoadGame(_servicesContext, _gameRepository);
	}

	public void Save()
	{
		foreach (var saveLoader in _saveLoaders)
			saveLoader.SaveGame(_servicesContext, _gameRepository);

		_gameRepository.SaveState();
	}

	public void Initialize()
	{
		Load();
	}

	public void Dispose()
	{
		Save();
	}
}
}