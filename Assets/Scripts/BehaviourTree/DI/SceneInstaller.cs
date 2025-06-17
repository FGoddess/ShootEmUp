using BehaviourTree.Bots;
using BehaviourTree.DI.Signals;
using BehaviourTree.Zones;
using Zenject;

namespace BehaviourTree.DI
{
public class SceneInstaller : MonoInstaller<SceneInstaller>
{
	public override void InstallBindings()
	{
		Container.Bind<Bot>().FromComponentInHierarchy().AsSingle();
		Container.Bind<ZonesController>().FromComponentInHierarchy().AsSingle();

		InstallSignals();
	}

	private void InstallSignals()
	{
		SignalBusInstaller.Install(Container);

		Container.DeclareSignal<TreeGrownSignal>();
		Container.DeclareSignal<TreeCollectedSignal>();

		Container.BindSignal<TreeGrownSignal>().ToMethod<ZonesController>(x => x.OnTreeGrown).FromResolve();
		Container.BindSignal<TreeCollectedSignal>().ToMethod<ZonesController>(x => x.OnTreeTaken).FromResolve();
	}
}
}