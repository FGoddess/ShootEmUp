using System.Collections.Generic;
using System.Linq;
using GameEngine;
using SaveSystem.Encryption;
using SaveSystem.Helpers;
using SaveSystem.Repository;
using SaveSystem.SaveLoad;
using UnityEngine;
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
		Container.BindInterfacesAndSelfTo<ResourceSaveLoader>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<UnitSaveLoader>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<GameRepository>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<XorEncryptionService>().AsSingle().NonLazy();
		
		Container.Bind<SavesHelper>().FromComponentInHierarchy().AsSingle();
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