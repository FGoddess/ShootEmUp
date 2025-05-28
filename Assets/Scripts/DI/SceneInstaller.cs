using Core;
using Core.Events;
using Core.Handlers;
using Core.Hero;
using Core.Services;
using Core.Tasks;
using Core.Tasks.Hero;
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
		InstallUI();

		Container.BindInterfacesAndSelfTo<HeroesSetupSystem>().AsSingle();
	}

	private void InstallSignals()
	{
		SignalBusInstaller.Install(Container);

		Container.DeclareSignal<SelectHeroSignal>();
		Container.DeclareSignal<SelectTargetSignal>();
		Container.DeclareSignal<DealDamageSignal>();
		Container.DeclareSignal<DamageDealtSignal>();
		Container.DeclareSignal<HeroDeathSignal>();

		Container.Bind<SelectHeroTask>().AsSingle();
		Container.Bind<SelectTargetTask>().AsSingle();
		Container.Bind<StartHeroActionsPipelineTask>().AsSingle();
		Container.Bind<StartHeroesTurnEndPipelineTask>().AsSingle();
		Container.Bind<CleanupTask>().AsSingle();

		Container.Bind<SelectHeroHandler>().AsSingle();
		Container.Bind<SelectTargetHandler>().AsSingle();
		Container.Bind<DealDamageHandler>().AsSingle();
		Container.Bind<DamageAllHandler>().AsSingle();
		Container.Bind<HeroDeathHandler>().AsSingle();
		Container.Bind<GameEndHandler>().AsSingle();

		Container.BindSignal<SelectHeroSignal>().ToMethod<SelectHeroHandler>(x => x.SetupHeroSelection).FromResolve();
		Container.BindSignal<SelectTargetSignal>().ToMethod<SelectTargetHandler>(x => x.SetupTargetSelection).FromResolve();
		Container.BindSignal<DealDamageSignal>().ToMethod<DealDamageHandler>(x => x.DealDamage).FromResolve();
		Container.BindSignal<DamageDealtSignal>().ToMethod<DamageAllHandler>(x => x.DamageAll).FromResolve();
		Container.BindSignal<DamageDealtSignal>().ToMethod<HeroDeathHandler>(x => x.OnDamageDealt).FromResolve();
		Container.BindSignal<HeroDeathSignal>().ToMethod<GameEndHandler>(x => x.OnHeroDeath).FromResolve();
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

	private void InstallUI()
	{
		Container.Bind<UiWinScreen>().FromComponentInHierarchy().AsSingle();
	}
}
}