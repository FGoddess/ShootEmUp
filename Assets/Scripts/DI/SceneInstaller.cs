using System.Collections.Generic;
using System.Linq;
using Core;
using GameEngine;
using SaveSystem.Repository;
using SaveSystem.SaveLoad;
using Zenject;

namespace DI
{
public class SceneInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<UnitManager>().AsSingle().NonLazy();
		Container.Bind<ResourceService>().AsSingle().NonLazy();

		Container.Bind<List<object>>()
		         .FromMethod(GetAllServices)
		         .AsSingle();
		
		Container.Bind<ServiceContext>().AsSingle().NonLazy();
		Container.Bind<ResourceSaveLoader>().AsSingle().NonLazy();
		Container.Bind<UnitSaveLoader>().AsSingle().NonLazy();
		Container.Bind<GameRepository>().AsSingle().NonLazy();
		Container.Bind<EntryPoint>().FromComponentInHierarchy().AsSingle();
	}

	private List<object> GetAllServices(InjectContext context)
	{
		var serviceTypes = new[]
		{
			typeof(UnitManager),
			typeof(ResourceService)
		};

		return serviceTypes.Select(type => context.Container.Resolve(type)).ToList();
	}
}
}