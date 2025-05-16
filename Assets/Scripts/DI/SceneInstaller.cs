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
		InstallSignalBus(Container);

		//Container.Bind<EventBus>().AsSingle();

		Container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().AsSingle();
		Container.BindInterfacesAndSelfTo<TurnPipelineRunner>().AsSingle();

		Container.Bind<TurnPipeline>().AsSingle();

		Container.Bind<PlayerService>().AsSingle();
		
		Container.Bind<UIService>().FromComponentInHierarchy().AsSingle();
	}

	private void InstallSignalBus(DiContainer container)
	{
		SignalBusInstaller.Install(container);

		container.DeclareSignal<SelectHeroSignal>();

		container.Bind<SelectHeroTask>().AsSingle();
		container.Bind<DealDamageTask>().AsSingle();
		container.Bind<SelectHeroHandler>().AsSingle();

		container.BindSignal<SelectHeroSignal>().ToMethod<SelectHeroHandler>(x => x.WaitHeroSelectionAsync).FromResolve();
	}
}
}