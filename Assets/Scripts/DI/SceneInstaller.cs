using Configs;
using Managers;
using Presenters;
using UnityEngine;
using Views;
using Zenject;

namespace DI
{
public class SceneInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		InstallFactory();
		InstallViews();
		InstallManagers();
		InstallUi();
	}

	private void InstallFactory()
	{
		Container.Bind<CharacterPresenterFactory>().AsSingle();
	}

	private void InstallViews()
	{
		Container.Bind<CharacterPopup>().FromComponentInHierarchy().AsSingle();
		Container.Bind<CharacterInfoView>().FromComponentInHierarchy().AsSingle();
		Container.Bind<PlayerLevelView>().FromComponentInHierarchy().AsSingle();
		Container.Bind<UserInfoView>().FromComponentInHierarchy().AsSingle();
	}

	private void InstallManagers()
	{
		Container.BindInterfacesAndSelfTo<CharactersManager>().AsSingle().NonLazy();
	}

	private void InstallUi()
	{
		Container.BindInterfacesAndSelfTo<UiCharactersScreen>().FromComponentInHierarchy().AsSingle();

	}
}
}