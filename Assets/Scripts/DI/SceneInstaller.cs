using Chests;
using Chests.View;
using DI.Contexts;
using Money;
using Rewards;
using SaveSystem.Encryption;
using SaveSystem.Repository;
using SaveSystem.SaveLoad;
using Session;
using Session.Views;
using Time;
using Zenject;

namespace DI
{
public class SceneInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.BindInterfacesAndSelfTo<ServicesContext>().AsSingle().NonLazy();

		Container.BindInterfacesAndSelfTo<MoneyService>().AsSingle();

		Container.BindInterfacesAndSelfTo<SessionDurationView>().FromComponentInHierarchy().AsCached();
		Container.BindInterfacesAndSelfTo<SessionLogTimeView>().FromComponentInHierarchy().AsCached();
		Container.BindInterfacesAndSelfTo<ChestListView>().FromComponentInHierarchy().AsCached();

		Container.BindInterfacesAndSelfTo<ServerTimeController>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<SessionDurationController>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<SessionLogTimeService>().AsSingle().NonLazy();

		Container.BindInterfacesAndSelfTo<RewardsApplyController>().AsSingle();
		Container.BindInterfacesAndSelfTo<ChestsService>().AsSingle();

		InstallSaveContext();
	}

	private void InstallSaveContext()
	{
		Container.BindInterfacesAndSelfTo<GameRepository>().AsSingle().NonLazy();

		Container.BindInterfacesAndSelfTo<XorEncryptionService>().AsSingle().NonLazy();

		Container.BindInterfacesAndSelfTo<LogTimeSaveLoader>().AsCached();
		Container.BindInterfacesAndSelfTo<ChestsSaveLoader>().AsCached();

		Container.BindInterfacesAndSelfTo<SaveLoadingController>().AsSingle().NonLazy();
	}
}
}