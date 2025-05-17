using Core;
using Core.Events;
using Core.Handlers;
using Core.Services;
using Core.Tasks;
using UI;
using Zenject;

namespace DI
{
public class SceneInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		InstallSignals();
		InstallPipelines();
		InstallServices();

		Container.BindInterfacesAndSelfTo<HeroesCreator>().AsSingle();
	}

	private void InstallSignals()
	{
		SignalBusInstaller.Install(Container);

		Container.DeclareSignal<SelectHeroSignal>();
		Container.DeclareSignal<SelectTargetSignal>();

		Container.Bind<SelectHeroTask>().AsSingle();
		Container.Bind<SelectTargetTask>().AsSingle();
		Container.Bind<DealDamageTask>().AsSingle();

		Container.Bind<SelectHeroHandler>().AsSingle();
		Container.Bind<SelectTargetHandler>().AsSingle();

		Container.BindSignal<SelectHeroSignal>().ToMethod<SelectHeroHandler>(x => x.SetupHeroSelection).FromResolve();
		Container.BindSignal<SelectTargetSignal>().ToMethod<SelectTargetHandler>(x => x.SetupTargetSelection).FromResolve();
	}

	private void InstallPipelines()
	{
		Container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().AsSingle();
		Container.BindInterfacesAndSelfTo<TurnPipelineRunner>().AsSingle();

		Container.Bind<TurnPipeline>().AsSingle();
	}

	private void InstallServices()
	{
		Container.Bind<PlayerService>().AsSingle();

		Container.Bind<UIService>().FromComponentInHierarchy().AsSingle();
	}
}
}