using Zenject;

namespace SampleGame
{
public class SignalsInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<LocationsLoader>().FromComponentInHierarchy().AsSingle().NonLazy();
		
		SignalBusInstaller.Install(Container);
		Container.DeclareSignal<ZoneLoadSignal>();

		Container.BindSignal<ZoneLoadSignal>().ToMethod<LocationsLoader>(x => x.OnZoneLoadSignal).FromResolve();
	}
}
}